using Bank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace DataBase_uchet
{
    public partial class Form1 : Form
    {
        static int triesToEnter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            label3.Left = Left = (fm.Width / 2) - (label3.Width / 2);
            label4.Left = Left = (fm.Width / 2) - (label4.Width / 2);
            eyeBox.Left = pass.Location.X + pass.Width-20;
            login.Left = (fm.Width/2) - (login.Width/2);
            pass.Left = (fm.Width / 2) - (pass.Width / 2);
            loginBtn.Left = (fm.Width / 2) - (loginBtn.Width / 2);
            pass.UseSystemPasswordChar = true;
            label1.Left = (fm.Width / 2) - (label1.Width / 2);
            label2.Left = (fm.Width / 2) - (label2.Width / 2);
            label2.Hide();

            fm.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("SELECT `AbleToLogin` FROM `users` WHERE Login = @login",db.GetConnection());
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass.Text;
            cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;

            db.openConnection();
            string ableToLogin = (string)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT `Pass` FROM `users` WHERE Login = @login";
            string password = (string)cmd.ExecuteScalar();
            db.closeConnection();
            string err;
            if(ableToLogin == "yes")
            {
                if (pass.Text == password)
                {
                    MainForm mf = new MainForm(login.Text, this);
                    mf.Show();
                    eyeBox.Image = Image.FromFile(@"..\..\imgs\crossedEye.png");
                    pass.UseSystemPasswordChar = true;
                    check = false;
                    this.Hide();

                    triesToEnter = 0;
                    pass.Text = "";
                    login.Text = "";
                    label2.Hide();
                }
                else
                {
                    triesToEnter++;
                    err = "Wrong login or password!";
                    if (triesToEnter > 2)
                    {
                        err = "Authentication has been blocked!";
                        label2.Text = err;
                        MessageBox.Show("Authentication has been blocked\n       after 3 atempts to enter!");
                        cmd.CommandText = "UPDATE `users` SET `AbleToLogin`=\"no\" WHERE 1";
                        db.openConnection();
                        cmd.ExecuteNonQuery();
                        db.closeConnection();
                        label2.Left = (this.Width / 2) - label2.Width / 2;
                        label2.Show();
                    }
                    label2.Text = err;
                    label2.Left = (this.Width / 2) - label2.Width / 2;
                    label2.Show();
                }
            }
            else if (ableToLogin == null)
            {
                label2.Text = "Wrong login or password!";
                label2.Left = (this.Width / 2) - label2.Width / 2;
                label2.Show();
            }
            else 
            {
                label2.Text = "Authentication has been blocked!";
                label2.Left = (this.Width / 2) - label2.Width / 2;
                label2.Show();
            }
        }
        bool check = false;
        private void eyeBox_Click(object sender, EventArgs e)
        {
            if (check == false) check = true; else check = false;
            if (check == false)
            {
                eyeBox.Image = Image.FromFile(@"..\..\imgs\crossedEye.png");
                pass.UseSystemPasswordChar = true;
            }
            else
            {
                eyeBox.Image = Image.FromFile(@"..\..\imgs\eye.png");
                pass.UseSystemPasswordChar = false;
            }
        }
    }
}