namespace WU_Einteilung
{
    partial class MainFrm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbx_path = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbx_path
            // 
            this.tbx_path.Location = new System.Drawing.Point(346, 26);
            this.tbx_path.Name = "tbx_path";
            this.tbx_path.Size = new System.Drawing.Size(238, 20);
            this.tbx_path.TabIndex = 1;
            this.tbx_path.Text = "D:\\Users\\Johannes\\Desktop\\test";
            this.tbx_path.TextChanged += new System.EventHandler(this.tbx_path_TextChanged);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 476);
            this.Controls.Add(this.tbx_path);
            this.Controls.Add(this.button1);
            this.Name = "MainFrm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbx_path;
    }
}

