﻿namespace DataBase_uchet
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.fNameInp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rfrshBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lNameInp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editCheck = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.updBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.fNameInp);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rfrshBtn);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lNameInp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1575, 100);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(895, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "First Name";
            // 
            // fNameInp
            // 
            this.fNameInp.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fNameInp.Location = new System.Drawing.Point(868, 49);
            this.fNameInp.Name = "fNameInp";
            this.fNameInp.Size = new System.Drawing.Size(116, 24);
            this.fNameInp.TabIndex = 10;
            this.fNameInp.TextChanged += new System.EventHandler(this.fNameInp_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1518, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Refresh";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // rfrshBtn
            // 
            this.rfrshBtn.BackColor = System.Drawing.Color.Transparent;
            this.rfrshBtn.BackgroundImage = global::DataBase_uchet.Properties.Resources.refreshPNG;
            this.rfrshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rfrshBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rfrshBtn.FlatAppearance.BorderSize = 0;
            this.rfrshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rfrshBtn.ForeColor = System.Drawing.Color.DarkCyan;
            this.rfrshBtn.Location = new System.Drawing.Point(1495, 72);
            this.rfrshBtn.Name = "rfrshBtn";
            this.rfrshBtn.Size = new System.Drawing.Size(20, 20);
            this.rfrshBtn.TabIndex = 8;
            this.rfrshBtn.UseVisualStyleBackColor = false;
            this.rfrshBtn.Click += new System.EventHandler(this.rfrshBtn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1547, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(754, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name";
            // 
            // lNameInp
            // 
            this.lNameInp.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNameInp.Location = new System.Drawing.Point(727, 49);
            this.lNameInp.Name = "lNameInp";
            this.lNameInp.Size = new System.Drawing.Size(116, 24);
            this.lNameInp.TabIndex = 3;
            this.lNameInp.TextChanged += new System.EventHandler(this.lNameInp_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Neo Sans", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Base Table";
            // 
            // editCheck
            // 
            this.editCheck.AutoSize = true;
            this.editCheck.Enabled = false;
            this.editCheck.Location = new System.Drawing.Point(1489, 732);
            this.editCheck.Name = "editCheck";
            this.editCheck.Size = new System.Drawing.Size(74, 17);
            this.editCheck.TabIndex = 5;
            this.editCheck.Text = "Edit Table";
            this.editCheck.UseVisualStyleBackColor = true;
            this.editCheck.Visible = false;
            this.editCheck.CheckedChanged += new System.EventHandler(this.editCheck_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 761);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1575, 100);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Neo Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1042, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(521, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Copyright © 2020 Fediuk Inc. All rights reserved.            Ukraine";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1575, 620);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(0, 717);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(125, 45);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add a personnel";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updBtn
            // 
            this.updBtn.Enabled = false;
            this.updBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updBtn.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updBtn.Location = new System.Drawing.Point(131, 717);
            this.updBtn.Name = "updBtn";
            this.updBtn.Size = new System.Drawing.Size(125, 45);
            this.updBtn.TabIndex = 3;
            this.updBtn.Text = "Update";
            this.updBtn.UseVisualStyleBackColor = true;
            this.updBtn.Visible = false;
            this.updBtn.Click += new System.EventHandler(this.updBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1575, 861);
            this.Controls.Add(this.updBtn);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.editCheck);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lNameInp;
        private System.Windows.Forms.CheckBox editCheck;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button rfrshBtn;
        private System.Windows.Forms.Button updBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fNameInp;
    }
}