namespace RemixTranslate
{
    partial class Translate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.slctIdioma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTraducao = new System.Windows.Forms.TextBox();
            this.bttnTraduzir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // slctIdioma
            // 
            this.slctIdioma.FormattingEnabled = true;
            this.slctIdioma.Items.AddRange(new object[] {
            "Lea-yiokari (Mileni)",
            "Yiokal (Matím)",
            "Yiokari (Jirsaih)",
            "Arconte"});
            this.slctIdioma.Location = new System.Drawing.Point(87, 6);
            this.slctIdioma.Name = "slctIdioma";
            this.slctIdioma.Size = new System.Drawing.Size(179, 21);
            this.slctIdioma.TabIndex = 0;
            this.slctIdioma.SelectedIndexChanged += new System.EventHandler(this.slctIdioma_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Traduzir para";
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(15, 57);
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(251, 104);
            this.txtTexto.TabIndex = 2;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tradução";
            // 
            // txtTraducao
            // 
            this.txtTraducao.Location = new System.Drawing.Point(276, 57);
            this.txtTraducao.Multiline = true;
            this.txtTraducao.Name = "txtTraducao";
            this.txtTraducao.Size = new System.Drawing.Size(251, 104);
            this.txtTraducao.TabIndex = 4;
            // 
            // bttnTraduzir
            // 
            this.bttnTraduzir.Location = new System.Drawing.Point(452, 6);
            this.bttnTraduzir.Name = "bttnTraduzir";
            this.bttnTraduzir.Size = new System.Drawing.Size(75, 23);
            this.bttnTraduzir.TabIndex = 6;
            this.bttnTraduzir.Text = "Traduzir";
            this.bttnTraduzir.UseVisualStyleBackColor = true;
            this.bttnTraduzir.Click += new System.EventHandler(this.bttnTraduzir_Click);
            // 
            // Translate
            // 
            this.ClientSize = new System.Drawing.Size(539, 177);
            this.Controls.Add(this.bttnTraduzir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTraducao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slctIdioma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Translate";
            this.Text = "RemixTranslate";
            this.Load += new System.EventHandler(this.Translate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox slctIdioma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTraducao;
        private System.Windows.Forms.Button bttnTraduzir;
    }
}

