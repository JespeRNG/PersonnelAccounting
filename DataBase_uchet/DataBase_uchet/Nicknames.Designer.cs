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
            this.closeBtn.Location = new System.Drawing.Point(63, 124);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 27);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // Nicknames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(200, 163);
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
    }
}