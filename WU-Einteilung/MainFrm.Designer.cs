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
            this.btn_zon = new System.Windows.Forms.Button();
            this.tbx_path = new System.Windows.Forms.TextBox();
            this.btn_list = new System.Windows.Forms.Button();
            this.lbl_path = new System.Windows.Forms.Label();
            this.lbx_log = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_zon
            // 
            this.btn_zon.Location = new System.Drawing.Point(12, 108);
            this.btn_zon.Name = "btn_zon";
            this.btn_zon.Size = new System.Drawing.Size(234, 48);
            this.btn_zon.TabIndex = 0;
            this.btn_zon.Text = "Zuordnen";
            this.btn_zon.UseVisualStyleBackColor = true;
            this.btn_zon.Click += new System.EventHandler(this.btn_zon_Click);
            // 
            // tbx_path
            // 
            this.tbx_path.Location = new System.Drawing.Point(112, 12);
            this.tbx_path.Name = "tbx_path";
            this.tbx_path.Size = new System.Drawing.Size(408, 20);
            this.tbx_path.TabIndex = 1;
            this.tbx_path.Text = "Pfad";
            // 
            // btn_list
            // 
            this.btn_list.Location = new System.Drawing.Point(286, 108);
            this.btn_list.Name = "btn_list";
            this.btn_list.Size = new System.Drawing.Size(234, 48);
            this.btn_list.TabIndex = 2;
            this.btn_list.Text = "Kurslisten erstellen";
            this.btn_list.UseVisualStyleBackColor = true;
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Location = new System.Drawing.Point(12, 15);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(97, 13);
            this.lbl_path.TabIndex = 3;
            this.lbl_path.Text = "Pfad der WU Liste:";
            // 
            // lbx_log
            // 
            this.lbx_log.Location = new System.Drawing.Point(15, 40);
            this.lbx_log.Name = "lbx_log";
            this.lbx_log.Size = new System.Drawing.Size(505, 56);
            this.lbx_log.TabIndex = 4;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 168);
            this.Controls.Add(this.lbx_log);
            this.Controls.Add(this.lbl_path);
            this.Controls.Add(this.btn_list);
            this.Controls.Add(this.tbx_path);
            this.Controls.Add(this.btn_zon);
            this.Name = "MainFrm";
            this.Text = "WU-Einteilung";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_zon;
        private System.Windows.Forms.TextBox tbx_path;
        private System.Windows.Forms.Button btn_list;
        private System.Windows.Forms.Label lbl_path;
        private System.Windows.Forms.ListBox lbx_log;
    }
}

