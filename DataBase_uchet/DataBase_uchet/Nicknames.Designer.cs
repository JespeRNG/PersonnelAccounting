namespace DataBase_uchet
{
    partial class Nicknames
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
            this.telegram = new System.Windows.Forms.Label();
            this.insta = new System.Windows.Forms.Label();
            this.twitter = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.telegBox = new System.Windows.Forms.TextBox();
            this.instaBox = new System.Windows.Forms.TextBox();
            this.twitBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // telegram
            // 
            this.telegram.AutoSize = true;
            this.telegram.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telegram.Location = new System.Drawing.Point(12, 18);
            this.telegram.Name = "telegram";
            this.telegram.Size = new System.Drawing.Size(69, 16);
            this.telegram.TabIndex = 0;
            this.telegram.Text = "Telegram: ";
            // 
            // insta
            // 
            this.insta.AutoSize = true;
            this.insta.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insta.Location = new System.Drawing.Point(12, 56);
            this.insta.Name = "insta";
            this.insta.Size = new System.Drawing.Size(72, 16);
            this.insta.TabIndex = 1;
            this.insta.Text = "Instagram: ";
            // 
            // twitter
            // 
            this.twitter.AutoSize = true;
            this.twitter.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twitter.Location = new System.Drawing.Point(12, 94);
            this.twitter.Name = "twitter";
            this.twitter.Size = new System.Drawing.Size(56, 16);
            this.twitter.TabIndex = 2;
            this.twitter.Text = "Twitter: ";
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(19, 124);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 27);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(128, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // telegBox
            // 
            this.telegBox.Enabled = false;
            this.telegBox.Location = new System.Drawing.Point(87, 17);
            this.telegBox.Name = "telegBox";
            this.telegBox.Size = new System.Drawing.Size(100, 20);
            this.telegBox.TabIndex = 5;
            this.telegBox.Visible = false;
            // 
            // instaBox
            // 
            this.instaBox.Enabled = false;
            this.instaBox.Location = new System.Drawing.Point(87, 56);
            this.instaBox.Name = "instaBox";
            this.instaBox.Size = new System.Drawing.Size(100, 20);
            this.instaBox.TabIndex = 6;
            this.instaBox.Visible = false;
            // 
            // twitBox
            // 
            this.twitBox.Enabled = false;
            this.twitBox.Location = new System.Drawing.Point(87, 90);
            this.twitBox.Name = "twitBox";
            this.twitBox.Size = new System.Drawing.Size(100, 20);
            this.twitBox.TabIndex = 7;
            this.twitBox.Visible = false;
            // 
            // Nicknames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(222, 163);
            this.Controls.Add(this.twitBox);
            this.Controls.Add(this.instaBox);
            this.Controls.Add(this.telegBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.twitter);
            this.Controls.Add(this.insta);
            this.Controls.Add(this.telegram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Nicknames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nicknames";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label telegram;
        private System.Windows.Forms.Label insta;
        private System.Windows.Forms.Label twitter;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox telegBox;
        private System.Windows.Forms.TextBox instaBox;
        private System.Windows.Forms.TextBox twitBox;
    }
}