﻿namespace WU_Einteilung
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
            this.btn_files = new System.Windows.Forms.Button();
            this.btn_conf = new System.Windows.Forms.Button();
            this.btn_klist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_zon
            // 
            this.btn_zon.Location = new System.Drawing.Point(15, 218);
            this.btn_zon.Name = "btn_zon";
            this.btn_zon.Size = new System.Drawing.Size(122, 48);
            this.btn_zon.TabIndex = 0;
            this.btn_zon.Text = "Zuordnen";
            this.btn_zon.UseVisualStyleBackColor = true;
            this.btn_zon.Click += new System.EventHandler(this.btn_zon_Click);
            // 
            // tbx_path
            // 
            this.tbx_path.Location = new System.Drawing.Point(112, 12);
            this.tbx_path.Name = "tbx_path";
            this.tbx_path.Size = new System.Drawing.Size(373, 20);
            this.tbx_path.TabIndex = 1;
            this.tbx_path.Text = "Pfad";
            // 
            // btn_list
            // 
            this.btn_list.Location = new System.Drawing.Point(143, 218);
            this.btn_list.Name = "btn_list";
            this.btn_list.Size = new System.Drawing.Size(122, 48);
            this.btn_list.TabIndex = 2;
            this.btn_list.Text = "Kurslisten erstellen";
            this.btn_list.UseVisualStyleBackColor = true;
            this.btn_list.Click += new System.EventHandler(this.btn_list_Click);
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
            this.lbx_log.Size = new System.Drawing.Size(505, 173);
            this.lbx_log.TabIndex = 4;
            // 
            // btn_files
            // 
            this.btn_files.Image = global::WU_Einteilung.Properties.Resources.folder_closed_white;
            this.btn_files.Location = new System.Drawing.Point(491, 10);
            this.btn_files.Name = "btn_files";
            this.btn_files.Size = new System.Drawing.Size(29, 22);
            this.btn_files.TabIndex = 5;
            this.btn_files.UseVisualStyleBackColor = true;
            this.btn_files.Click += new System.EventHandler(this.btn_files_Click);
            // 
            // btn_conf
            // 
            this.btn_conf.Location = new System.Drawing.Point(398, 218);
            this.btn_conf.Name = "btn_conf";
            this.btn_conf.Size = new System.Drawing.Size(122, 48);
            this.btn_conf.TabIndex = 6;
            this.btn_conf.Text = "Einstellungen";
            this.btn_conf.UseVisualStyleBackColor = true;
            this.btn_conf.Click += new System.EventHandler(this.btn_conf_Click);
            // 
            // btn_klist
            // 
            this.btn_klist.Location = new System.Drawing.Point(270, 218);
            this.btn_klist.Name = "btn_klist";
            this.btn_klist.Size = new System.Drawing.Size(122, 48);
            this.btn_klist.TabIndex = 7;
            this.btn_klist.Text = "Klassenlisten erstellen";
            this.btn_klist.UseVisualStyleBackColor = true;
            this.btn_klist.Click += new System.EventHandler(this.btn_klist_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 280);
            this.Controls.Add(this.btn_klist);
            this.Controls.Add(this.btn_conf);
            this.Controls.Add(this.btn_files);
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
        private System.Windows.Forms.Button btn_files;
        private System.Windows.Forms.Button btn_conf;
        private System.Windows.Forms.Button btn_klist;
    }
}

