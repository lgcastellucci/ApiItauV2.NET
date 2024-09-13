namespace Api_Itau_V2
{
    partial class FPrincipall
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGerarCertificado = new Button();
            lbClientID = new Label();
            tbClientID = new TextBox();
            tbClientOwner = new TextBox();
            lbClientOwner = new Label();
            btnValidade = new Button();
            tbValidade = new TextBox();
            lbValidade = new Label();
            btnEnviarCertificado = new Button();
            statusStrip1 = new StatusStrip();
            lbStatus = new ToolStripStatusLabel();
            tbTokenTemporario = new TextBox();
            lbTokenTemporario = new Label();
            tbClientSecret = new TextBox();
            lbClientSecret = new Label();
            btnRequisitarTokenTransacional = new Button();
            tbTokenTransacional = new TextBox();
            lbTokenTransacional = new Label();
            btnRenovarCertificado = new Button();
            tbClientCity = new TextBox();
            lbClientCity = new Label();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGerarCertificado
            // 
            btnGerarCertificado.Location = new Point(585, 49);
            btnGerarCertificado.Name = "btnGerarCertificado";
            btnGerarCertificado.Size = new Size(203, 23);
            btnGerarCertificado.TabIndex = 0;
            btnGerarCertificado.Text = "Gerar Certificado";
            btnGerarCertificado.UseVisualStyleBackColor = true;
            btnGerarCertificado.Click += btnGerarCertificado_Click;
            // 
            // lbClientID
            // 
            lbClientID.AutoSize = true;
            lbClientID.BackColor = SystemColors.Control;
            lbClientID.Location = new Point(12, 31);
            lbClientID.Name = "lbClientID";
            lbClientID.Size = new Size(58, 15);
            lbClientID.TabIndex = 1;
            lbClientID.Text = "Cliente ID";
            // 
            // tbClientID
            // 
            tbClientID.Location = new Point(12, 49);
            tbClientID.Name = "tbClientID";
            tbClientID.Size = new Size(236, 23);
            tbClientID.TabIndex = 2;
            // 
            // tbClientOwner
            // 
            tbClientOwner.Location = new Point(263, 49);
            tbClientOwner.Name = "tbClientOwner";
            tbClientOwner.Size = new Size(178, 23);
            tbClientOwner.TabIndex = 4;
            // 
            // lbClientOwner
            // 
            lbClientOwner.AutoSize = true;
            lbClientOwner.Location = new Point(263, 31);
            lbClientOwner.Name = "lbClientOwner";
            lbClientOwner.Size = new Size(82, 15);
            lbClientOwner.TabIndex = 3;
            lbClientOwner.Text = "Cliente Owner";
            // 
            // btnValidade
            // 
            btnValidade.Location = new Point(225, 266);
            btnValidade.Name = "btnValidade";
            btnValidade.Size = new Size(141, 23);
            btnValidade.TabIndex = 5;
            btnValidade.Text = "Checar Validade";
            btnValidade.UseVisualStyleBackColor = true;
            btnValidade.Click += btnValidade_Click;
            // 
            // tbValidade
            // 
            tbValidade.Location = new Point(12, 266);
            tbValidade.Name = "tbValidade";
            tbValidade.Size = new Size(207, 23);
            tbValidade.TabIndex = 7;
            // 
            // lbValidade
            // 
            lbValidade.AutoSize = true;
            lbValidade.Location = new Point(12, 248);
            lbValidade.Name = "lbValidade";
            lbValidade.Size = new Size(51, 15);
            lbValidade.TabIndex = 6;
            lbValidade.Text = "Validade";
            // 
            // btnEnviarCertificado
            // 
            btnEnviarCertificado.Location = new Point(585, 98);
            btnEnviarCertificado.Name = "btnEnviarCertificado";
            btnEnviarCertificado.Size = new Size(203, 23);
            btnEnviarCertificado.TabIndex = 8;
            btnEnviarCertificado.Text = "Enviar Certificado";
            btnEnviarCertificado.UseVisualStyleBackColor = true;
            btnEnviarCertificado.Click += btnEnviarCertificado_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbStatus });
            statusStrip1.Location = new Point(0, 366);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(754, 17);
            lbStatus.Spring = true;
            lbStatus.Text = "lbStatus";
            // 
            // tbTokenTemporario
            // 
            tbTokenTemporario.Location = new Point(8, 99);
            tbTokenTemporario.Name = "tbTokenTemporario";
            tbTokenTemporario.Size = new Size(571, 23);
            tbTokenTemporario.TabIndex = 11;
            // 
            // lbTokenTemporario
            // 
            lbTokenTemporario.AutoSize = true;
            lbTokenTemporario.Location = new Point(8, 81);
            lbTokenTemporario.Name = "lbTokenTemporario";
            lbTokenTemporario.Size = new Size(101, 15);
            lbTokenTemporario.TabIndex = 10;
            lbTokenTemporario.Text = "Token Temporario";
            // 
            // tbClientSecret
            // 
            tbClientSecret.Location = new Point(12, 212);
            tbClientSecret.Name = "tbClientSecret";
            tbClientSecret.Size = new Size(236, 23);
            tbClientSecret.TabIndex = 13;
            // 
            // lbClientSecret
            // 
            lbClientSecret.AutoSize = true;
            lbClientSecret.Location = new Point(12, 194);
            lbClientSecret.Name = "lbClientSecret";
            lbClientSecret.Size = new Size(72, 15);
            lbClientSecret.TabIndex = 12;
            lbClientSecret.Text = "client_secret";
            // 
            // btnRequisitarTokenTransacional
            // 
            btnRequisitarTokenTransacional.Location = new Point(585, 327);
            btnRequisitarTokenTransacional.Name = "btnRequisitarTokenTransacional";
            btnRequisitarTokenTransacional.Size = new Size(203, 23);
            btnRequisitarTokenTransacional.TabIndex = 14;
            btnRequisitarTokenTransacional.Text = "Requisitar TokenTransacional";
            btnRequisitarTokenTransacional.UseVisualStyleBackColor = true;
            btnRequisitarTokenTransacional.Click += btnRequisitarTokenTransacional_Click;
            // 
            // tbTokenTransacional
            // 
            tbTokenTransacional.Location = new Point(12, 327);
            tbTokenTransacional.Name = "tbTokenTransacional";
            tbTokenTransacional.Size = new Size(567, 23);
            tbTokenTransacional.TabIndex = 16;
            // 
            // lbTokenTransacional
            // 
            lbTokenTransacional.AutoSize = true;
            lbTokenTransacional.Location = new Point(12, 309);
            lbTokenTransacional.Name = "lbTokenTransacional";
            lbTokenTransacional.Size = new Size(106, 15);
            lbTokenTransacional.TabIndex = 15;
            lbTokenTransacional.Text = "Token Transacional";
            // 
            // btnRenovarCertificado
            // 
            btnRenovarCertificado.Location = new Point(585, 152);
            btnRenovarCertificado.Name = "btnRenovarCertificado";
            btnRenovarCertificado.Size = new Size(203, 23);
            btnRenovarCertificado.TabIndex = 17;
            btnRenovarCertificado.Text = "Renovar Certificado";
            btnRenovarCertificado.UseVisualStyleBackColor = true;
            btnRenovarCertificado.Click += btnRenovarCertificado_Click;
            // 
            // tbClientCity
            // 
            tbClientCity.Location = new Point(447, 49);
            tbClientCity.Name = "tbClientCity";
            tbClientCity.Size = new Size(132, 23);
            tbClientCity.TabIndex = 19;
            // 
            // lbClientCity
            // 
            lbClientCity.AutoSize = true;
            lbClientCity.Location = new Point(447, 31);
            lbClientCity.Name = "lbClientCity";
            lbClientCity.Size = new Size(68, 15);
            lbClientCity.TabIndex = 18;
            lbClientCity.Text = "Cliente City";
            // 
            // FPrincipall
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 388);
            Controls.Add(tbClientCity);
            Controls.Add(lbClientCity);
            Controls.Add(btnRenovarCertificado);
            Controls.Add(tbTokenTransacional);
            Controls.Add(lbTokenTransacional);
            Controls.Add(btnRequisitarTokenTransacional);
            Controls.Add(tbClientSecret);
            Controls.Add(lbClientSecret);
            Controls.Add(tbTokenTemporario);
            Controls.Add(lbTokenTemporario);
            Controls.Add(statusStrip1);
            Controls.Add(btnEnviarCertificado);
            Controls.Add(tbValidade);
            Controls.Add(lbValidade);
            Controls.Add(btnValidade);
            Controls.Add(tbClientOwner);
            Controls.Add(lbClientOwner);
            Controls.Add(tbClientID);
            Controls.Add(lbClientID);
            Controls.Add(btnGerarCertificado);
            Name = "FPrincipall";
            Text = "Principal";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGerarCertificado;
        private Label lbClientID;
        private TextBox tbClientID;
        private TextBox tbClientOwner;
        private Label lbClientOwner;
        private Button btnValidade;
        private TextBox tbValidade;
        private Label lbValidade;
        private Button btnEnviarCertificado;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbStatus;
        private TextBox tbTokenTemporario;
        private Label lbTokenTemporario;
        private TextBox tbClientSecret;
        private Label lbClientSecret;
        private Button btnRequisitarTokenTransacional;
        private TextBox tbTokenTransacional;
        private Label lbTokenTransacional;
        private Button btnRenovarCertificado;
        private TextBox tbClientCity;
        private Label lbClientCity;
    }
}
