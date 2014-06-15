namespace WU_Einteilung
{
    partial class ConfigFrm
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
            this.lbl_names = new System.Windows.Forms.Label();
            this.lbl_firstnames = new System.Windows.Forms.Label();
            this.lbl_classes = new System.Windows.Forms.Label();
            this.lbl_teacher = new System.Windows.Forms.Label();
            this.lbl_first = new System.Windows.Forms.Label();
            this.lbl_second = new System.Windows.Forms.Label();
            this.lbl_third = new System.Windows.Forms.Label();
            this.tbx_names = new System.Windows.Forms.TextBox();
            this.tbx_classes = new System.Windows.Forms.TextBox();
            this.tbx_first = new System.Windows.Forms.TextBox();
            this.tbx_third = new System.Windows.Forms.TextBox();
            this.tbx_firstnames = new System.Windows.Forms.TextBox();
            this.tbx_teachers = new System.Windows.Forms.TextBox();
            this.tbx_second = new System.Windows.Forms.TextBox();
            this.tbx_assignments = new System.Windows.Forms.TextBox();
            this.lbl_assignments = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_names
            // 
            this.lbl_names.AutoSize = true;
            this.lbl_names.Location = new System.Drawing.Point(14, 36);
            this.lbl_names.Name = "lbl_names";
            this.lbl_names.Size = new System.Drawing.Size(68, 13);
            this.lbl_names.TabIndex = 0;
            this.lbl_names.Text = "Nachnamen:";
            // 
            // lbl_firstnames
            // 
            this.lbl_firstnames.AutoSize = true;
            this.lbl_firstnames.Location = new System.Drawing.Point(143, 36);
            this.lbl_firstnames.Name = "lbl_firstnames";
            this.lbl_firstnames.Size = new System.Drawing.Size(58, 13);
            this.lbl_firstnames.TabIndex = 1;
            this.lbl_firstnames.Text = "Vornamen:";
            // 
            // lbl_classes
            // 
            this.lbl_classes.AutoSize = true;
            this.lbl_classes.Location = new System.Drawing.Point(14, 65);
            this.lbl_classes.Name = "lbl_classes";
            this.lbl_classes.Size = new System.Drawing.Size(47, 13);
            this.lbl_classes.TabIndex = 2;
            this.lbl_classes.Text = "Klassen:";
            // 
            // lbl_teacher
            // 
            this.lbl_teacher.AutoSize = true;
            this.lbl_teacher.Location = new System.Drawing.Point(143, 65);
            this.lbl_teacher.Name = "lbl_teacher";
            this.lbl_teacher.Size = new System.Drawing.Size(73, 13);
            this.lbl_teacher.TabIndex = 3;
            this.lbl_teacher.Text = "Klassenlehrer:";
            // 
            // lbl_first
            // 
            this.lbl_first.AutoSize = true;
            this.lbl_first.Location = new System.Drawing.Point(14, 96);
            this.lbl_first.Name = "lbl_first";
            this.lbl_first.Size = new System.Drawing.Size(62, 13);
            this.lbl_first.TabIndex = 4;
            this.lbl_first.Text = "Erstwahlen:";
            // 
            // lbl_second
            // 
            this.lbl_second.AutoSize = true;
            this.lbl_second.Location = new System.Drawing.Point(143, 96);
            this.lbl_second.Name = "lbl_second";
            this.lbl_second.Size = new System.Drawing.Size(70, 13);
            this.lbl_second.TabIndex = 5;
            this.lbl_second.Text = "Zweitwahlen:";
            // 
            // lbl_third
            // 
            this.lbl_third.AutoSize = true;
            this.lbl_third.Location = new System.Drawing.Point(14, 127);
            this.lbl_third.Name = "lbl_third";
            this.lbl_third.Size = new System.Drawing.Size(63, 13);
            this.lbl_third.TabIndex = 6;
            this.lbl_third.Text = "Drittwahlen:";
            // 
            // tbx_names
            // 
            this.tbx_names.Location = new System.Drawing.Point(89, 33);
            this.tbx_names.Name = "tbx_names";
            this.tbx_names.Size = new System.Drawing.Size(48, 20);
            this.tbx_names.TabIndex = 7;
            this.tbx_names.TextChanged += new System.EventHandler(this.tbx_names_TextChanged);
            // 
            // tbx_classes
            // 
            this.tbx_classes.Location = new System.Drawing.Point(89, 62);
            this.tbx_classes.Name = "tbx_classes";
            this.tbx_classes.Size = new System.Drawing.Size(48, 20);
            this.tbx_classes.TabIndex = 8;
            this.tbx_classes.TextChanged += new System.EventHandler(this.tbx_classes_TextChanged);
            // 
            // tbx_first
            // 
            this.tbx_first.Location = new System.Drawing.Point(89, 93);
            this.tbx_first.Name = "tbx_first";
            this.tbx_first.Size = new System.Drawing.Size(48, 20);
            this.tbx_first.TabIndex = 9;
            this.tbx_first.TextChanged += new System.EventHandler(this.tbx_first_TextChanged);
            // 
            // tbx_third
            // 
            this.tbx_third.Location = new System.Drawing.Point(89, 124);
            this.tbx_third.Name = "tbx_third";
            this.tbx_third.Size = new System.Drawing.Size(48, 20);
            this.tbx_third.TabIndex = 10;
            this.tbx_third.TextChanged += new System.EventHandler(this.tbx_third_TextChanged);
            // 
            // tbx_firstnames
            // 
            this.tbx_firstnames.Location = new System.Drawing.Point(224, 33);
            this.tbx_firstnames.Name = "tbx_firstnames";
            this.tbx_firstnames.Size = new System.Drawing.Size(48, 20);
            this.tbx_firstnames.TabIndex = 11;
            this.tbx_firstnames.TextChanged += new System.EventHandler(this.tbx_firstnames_TextChanged);
            // 
            // tbx_teachers
            // 
            this.tbx_teachers.Location = new System.Drawing.Point(224, 62);
            this.tbx_teachers.Name = "tbx_teachers";
            this.tbx_teachers.Size = new System.Drawing.Size(48, 20);
            this.tbx_teachers.TabIndex = 12;
            this.tbx_teachers.TextChanged += new System.EventHandler(this.tbx_teachers_TextChanged);
            // 
            // tbx_second
            // 
            this.tbx_second.Location = new System.Drawing.Point(224, 93);
            this.tbx_second.Name = "tbx_second";
            this.tbx_second.Size = new System.Drawing.Size(48, 20);
            this.tbx_second.TabIndex = 13;
            this.tbx_second.TextChanged += new System.EventHandler(this.tbx_second_TextChanged);
            // 
            // tbx_assignments
            // 
            this.tbx_assignments.Location = new System.Drawing.Point(224, 124);
            this.tbx_assignments.Name = "tbx_assignments";
            this.tbx_assignments.Size = new System.Drawing.Size(48, 20);
            this.tbx_assignments.TabIndex = 15;
            this.tbx_assignments.TextChanged += new System.EventHandler(this.tbx_assignments_TextChanged);
            // 
            // lbl_assignments
            // 
            this.lbl_assignments.AutoSize = true;
            this.lbl_assignments.Location = new System.Drawing.Point(143, 127);
            this.lbl_assignments.Name = "lbl_assignments";
            this.lbl_assignments.Size = new System.Drawing.Size(74, 13);
            this.lbl_assignments.TabIndex = 14;
            this.lbl_assignments.Text = "Zuordnungen:";
            // 
            // ConfigFrm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbx_assignments);
            this.Controls.Add(this.lbl_assignments);
            this.Controls.Add(this.tbx_second);
            this.Controls.Add(this.tbx_teachers);
            this.Controls.Add(this.tbx_firstnames);
            this.Controls.Add(this.tbx_third);
            this.Controls.Add(this.tbx_first);
            this.Controls.Add(this.tbx_classes);
            this.Controls.Add(this.tbx_names);
            this.Controls.Add(this.lbl_third);
            this.Controls.Add(this.lbl_second);
            this.Controls.Add(this.lbl_first);
            this.Controls.Add(this.lbl_teacher);
            this.Controls.Add(this.lbl_classes);
            this.Controls.Add(this.lbl_firstnames);
            this.Controls.Add(this.lbl_names);
            this.Name = "ConfigFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_names;
        private System.Windows.Forms.Label lbl_firstnames;
        private System.Windows.Forms.Label lbl_classes;
        private System.Windows.Forms.Label lbl_teacher;
        private System.Windows.Forms.Label lbl_first;
        private System.Windows.Forms.Label lbl_second;
        private System.Windows.Forms.Label lbl_third;
        private System.Windows.Forms.TextBox tbx_names;
        private System.Windows.Forms.TextBox tbx_classes;
        private System.Windows.Forms.TextBox tbx_first;
        private System.Windows.Forms.TextBox tbx_third;
        private System.Windows.Forms.TextBox tbx_firstnames;
        private System.Windows.Forms.TextBox tbx_teachers;
        private System.Windows.Forms.TextBox tbx_second;
        private System.Windows.Forms.TextBox tbx_assignments;
        private System.Windows.Forms.Label lbl_assignments;
    }
}