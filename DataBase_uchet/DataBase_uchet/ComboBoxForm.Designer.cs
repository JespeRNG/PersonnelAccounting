namespace DataBase_uchet
{
    partial class ComboBoxForm
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
            this.header = new System.Windows.Forms.Label();
            this.updBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.depBox = new System.Windows.Forms.ComboBox();
            this.rankBox = new System.Windows.Forms.ComboBox();
            this.posBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Neo Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(30, 20);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(0, 26);
            this.header.TabIndex = 0;
            // 
            // updBtn
            // 
            this.updBtn.Location = new System.Drawing.Point(507, 292);
            this.updBtn.Name = "updBtn";
            this.updBtn.Size = new System.Drawing.Size(75, 35);
            this.updBtn.TabIndex = 1;
            this.updBtn.Text = "Update";
            this.updBtn.UseVisualStyleBackColor = true;
            this.updBtn.Click += new System.EventHandler(this.updBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(588, 292);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 35);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // depBox
            // 
            this.depBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.depBox.FormattingEnabled = true;
            this.depBox.Items.AddRange(new object[] {
            "iOS",
            "Android",
            "Desktop",
            "Cloud",
            "Front-end",
            "Back-end",
            "Design",
            "Tester"});
            this.depBox.Location = new System.Drawing.Point(30, 140);
            this.depBox.Name = "depBox";
            this.depBox.Size = new System.Drawing.Size(175, 24);
            this.depBox.TabIndex = 3;
            // 
            // rankBox
            // 
            this.rankBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rankBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rankBox.FormattingEnabled = true;
            this.rankBox.Items.AddRange(new object[] {
            "Low junior",
            "Junior",
            "High junior",
            "Low middle",
            "Middle",
            "High middle",
            "Low senior",
            "Senior",
            "High senior",
            "Other"});
            this.rankBox.Location = new System.Drawing.Point(470, 140);
            this.rankBox.Name = "rankBox";
            this.rankBox.Size = new System.Drawing.Size(175, 24);
            this.rankBox.TabIndex = 4;
            // 
            // posBox
            // 
            this.posBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.posBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.posBox.FormattingEnabled = true;
            this.posBox.Items.AddRange(new object[] {
            "Development",
            "Team-Lead",
            "Project Manager",
            "Other"});
            this.posBox.Location = new System.Drawing.Point(250, 140);
            this.posBox.Name = "posBox";
            this.posBox.Size = new System.Drawing.Size(175, 24);
            this.posBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rank";
            // 
            // ComboBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(675, 339);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.posBox);
            this.Controls.Add(this.rankBox);
            this.Controls.Add(this.depBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updBtn);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ComboBoxForm";
            this.ShowIcon = false;
            this.Text = "Working information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComboBoxForm_FormClosing);
            this.Load += new System.EventHandler(this.ComboBoxForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Button updBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox depBox;
        private System.Windows.Forms.ComboBox rankBox;
        private System.Windows.Forms.ComboBox posBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}