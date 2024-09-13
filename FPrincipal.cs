using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net.Http.Headers;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.OpenSsl;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Parameters;
using Newtonsoft.Json.Linq;

namespace Api_Itau_V2
{
    public partial class FPrincipall : Form
    {
        public FPrincipall()
        {
            InitializeComponent();

            try
            {
                // Carregar configurações do arquivo appsettings.json
                var builder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                var configuration = builder.Build();

                tbClientOwner.Text = configuration["ClientOwner"];
                tbClientID.Text = configuration["ClientID"];
                tbClientSecret.Text = configuration["ClientSecret"];
                tbClientCity.Text = configuration["ClientCity"];
                tbTokenTemporario.Text = configuration["TokenTemporario"];
            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Erro ao carregar configurações: {ex.Message}";
            }

        }

        private void btnGerarCertificado_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            try
            {
                // Gerar chave privada
                var keyGenerationParameters = new KeyGenerationParameters(new SecureRandom(new CryptoApiRandomGenerator()), 2048);
                var keyPairGenerator = new RsaKeyPairGenerator();
                keyPairGenerator.Init(keyGenerationParameters);
                var keyPair = keyPairGenerator.GenerateKeyPair();

                // Converter a chave privada para o formato PKCS#8
                var privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(keyPair.Private);
                var serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetEncoded();


                // Definir informações do certificado
                var subject = new X509Name("CN=" + tbClientID.Text + ", OU=" + tbClientOwner.Text + ", L=" + tbClientCity.Text + ", ST=SÃO PAULO, C=BR");
                var csr = new Pkcs10CertificationRequest("SHA512WITHRSA", subject, keyPair.Public, null, keyPair.Private);


                // Salvar CSR em arquivo
                using (var writer = new StreamWriter(tbClientOwner.Text + "_ITAU_REQUEST_CERTIFICADO.csr"))
                {
                    var pemWriter = new PemWriter(writer);
                    pemWriter.WriteObject(csr);
                }

                // Salvar chave privada em arquivo
                using (var writer = new StreamWriter(tbClientOwner.Text + "_ITAU_CHAVE_PRIVADA_RSA.key"))
                {
                    var pemWriter = new PemWriter(writer);
                    pemWriter.WriteObject(keyPair.Private);
                }

                // Salvar chave privada em formato PKCS#8 em arquivo
                using (var writer = new StreamWriter(tbClientOwner.Text + "_ITAU_CHAVE_PRIVADA.key"))
                {
                    writer.WriteLine("-----BEGIN PRIVATE KEY-----");
                    writer.WriteLine(Convert.ToBase64String(serializedPrivateBytes, Base64FormattingOptions.InsertLineBreaks));
                    writer.WriteLine("-----END PRIVATE KEY-----");
                }

                lbStatus.Text = "Certificado e chave privada gerados com sucesso!";

            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Erro ao gerar certificado: {ex.Message}";
            }
        }

        private void btnEnviarCertificado_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            try
            {
                // Carregar o certificado a partir do arquivo
                string certPath = tbClientOwner.Text + "_ITAU_REQUEST_CERTIFICADO.csr";
                if (!File.Exists(certPath))
                {
                    lbStatus.Text = "Certificado não encontrado.";
                    return;
                }

                string certContent = File.ReadAllText(certPath);

                // Criar o conteúdo do corpo da requisição
                var content = new StringContent(certContent, Encoding.UTF8, "text/plain");

                using (HttpClient client = new HttpClient())
                {
                    // Adicionar o token Bearer ao cabeçalho de autorização
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tbTokenTemporario.Text);

                    // Enviar a requisição POST
                    HttpResponseMessage response = client.PostAsync("https://sts.itau.com.br/seguranca/v1/certificado/solicitacao", content).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string[] responseLines = responseBody.Split(new[] { '\n' }, 2);
                        string secret = responseLines[0];
                        string newCertContent = responseLines.Length > 1 ? responseLines[1] : string.Empty;

                        // Salvar o secret e o novo certificado
                        File.WriteAllText(tbClientOwner.Text + "_ITAU_SECRET.txt", secret);
                        File.WriteAllText(tbClientOwner.Text + "_ITAU_NOVO_CERTIFICADO.crt", newCertContent);

                        tbClientSecret.Text = secret.Replace("Secret:", "").Trim();

                        lbStatus.Text = "Certificado enviado e resposta processada com sucesso!";

                    }
                    else
                    {
                        lbStatus.Text = $"Erro ao enviar certificado: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Erro ao enviar certificado: {ex.Message}";
            }
        }

        private void btnValidade_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            try
            {
                // Carregar o certificado a partir do arquivo
                string certPath = tbClientOwner.Text + "_ITAU_NOVO_CERTIFICADO.crt"; // Supondo que o certificado assinado esteja neste arquivo
                if (!File.Exists(certPath))
                {
                    lbStatus.Text = "Certificado não encontrado.";
                    return;
                }

                byte[] certBytes = File.ReadAllBytes(certPath);
                var certificate = new X509Certificate2(certBytes);

                // Extrair informações de validade
                DateTime notBefore = certificate.NotBefore;
                DateTime notAfter = certificate.NotAfter;

                // Exibir as informações no TextBox tbValidade
                tbValidade.Text = $"Válido de {notBefore.ToShortDateString()} até {notAfter.ToShortDateString()}";

                lbStatus.Text = "Certificado analisado com sucesso!";

            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Erro ao verificar a validade do certificado: {ex.Message}";
            }
        }

        private void btnRequisitarTokenTransacional_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            try
            {
                // Carregar a chave privada e o novo certificado a partir dos arquivos
                string privateKeyPath = tbClientOwner.Text + "_ITAU_CHAVE_PRIVADA.key";
                string certPath = tbClientOwner.Text + "_ITAU_NOVO_CERTIFICADO.crt";

                if (!File.Exists(privateKeyPath))
                {
                    lbStatus.Text = "Chave privada não encontrados.";
                    return;
                }
                if (!File.Exists(certPath))
                {
                    lbStatus.Text = "Certificado não encontrados.";
                    return;
                }

                var certificate = new X509Certificate2(certPath);
                // Carregar a chave privada usando BouncyCastle
                AsymmetricKeyParameter privateKey;
                using (var reader = File.OpenText(privateKeyPath))
                {
                    var pemReader = new PemReader(reader);
                    privateKey = (AsymmetricKeyParameter)pemReader.ReadObject();
                }

                // Combinar o certificado e a chave privada
                var certWithKey = certificate.CopyWithPrivateKey(DotNetUtilities.ToRSA(privateKey as RsaPrivateCrtKeyParameters));

                // Criar o conteúdo do corpo da requisição
                var values = new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" },
                    { "client_id", tbClientID.Text },
                    { "client_secret", tbClientSecret.Text }
                };
                var content = new FormUrlEncodedContent(values);

                // Configurar o HttpClientHandler
                var handler = new HttpClientHandler();
                handler.ClientCertificates.Add(certWithKey);

                // Criar o HttpClient com o handler configurado
                var client = new HttpClient(handler);

                // Enviar a requisição POST
                var response = client.PostAsync("https://sts.itau.com.br/api/oauth/token", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    JObject dataJson;
                    try
                    {
                        dataJson = JObject.Parse(responseBody);
                    }
                    catch (Exception ex)
                    {
                        lbStatus.Text = $"Erro ao analisar resposta: {ex.Message}";
                        return;
                    }

                    if ((dataJson.SelectToken("access_token") != null) && ((string)dataJson.SelectToken("access_token") != ""))
                    {
                        tbTokenTransacional.Text = dataJson.SelectToken("access_token").ToString();
                        lbStatus.Text = "Token transacional requisitado com sucesso!";
                    }
                    else
                    {
                        lbStatus.Text = "Erro ao processar a resposta: access_token não encontrado.";
                    }
                }
                else
                {
                    lbStatus.Text = $"Erro ao requisitar token transacional: {response.ReasonPhrase}";
                }


            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Erro ao requisitar token transacional: {ex.Message}";
            }
        }

        private void btnRenovarCertificado_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            try
            {
                // Carregar o certificado a partir do arquivo
                string certPath = tbClientOwner.Text + "_ITAU_REQUEST_CERTIFICADO.csr";
                if (!File.Exists(certPath))
                {
                    lbStatus.Text = "Certificado não encontrado.";
                    return;
                }

                string certContent = File.ReadAllText(certPath);

                // Criar o conteúdo do corpo da requisição
                var content = new StringContent(certContent, Encoding.UTF8, "text/plain");

                using (HttpClient client = new HttpClient())
                {
                    // Adicionar o token Bearer ao cabeçalho de autorização
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tbTokenTemporario.Text);

                    // Enviar a requisição POST
                    HttpResponseMessage response = client.PostAsync("https://sts.itau.com.br/seguranca/v1/certificado/renovacao", content).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string[] responseLines = responseBody.Split(new[] { '\n' }, 2);
                        string secret = responseLines[0];
                        string newCertContent = responseLines.Length > 1 ? responseLines[1] : string.Empty;

                        // Salvar o secret e o novo certificado
                        File.WriteAllText(tbClientOwner.Text + "_ITAU_SECRET.txt", secret);
                        File.WriteAllText(tbClientOwner.Text + "_ITAU_NOVO_CERTIFICADO.crt", newCertContent);

                        tbClientSecret.Text = secret.Replace("Secret:", "").Trim();

                        lbStatus.Text = "Certificado enviado e resposta processada com sucesso!";

                    }
                    else
                    {
                        lbStatus.Text = $"Erro ao enviar certificado: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Erro ao enviar certificado: {ex.Message}";
            }
        }



    }
}
