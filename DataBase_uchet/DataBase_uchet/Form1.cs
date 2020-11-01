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
        int triesToEnter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 fm = new Form1();

            login.Left = (fm.Width/2) - (login.Width/2);
            pass.Left = (fm.Width / 2) - (pass.Width / 2);
            loginBtn.Left = (fm.Width / 2) - (loginBtn.Width / 2);
            pass.UseSystemPasswordChar = true;
            passVisible.Left = pass.Left + pass.Width + 10;
            label1.Left = (fm.Width / 2) - (label1.Width / 2);
            label2.Left = (fm.Width / 2) - (label2.Width / 2);
            label2.Hide();

            fm.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand cmd = new MySqlCommand("SELECT `AbleToLogin` FROM `users` WHERE Login = @login AND Pass= @pass",db.GetConnection());
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass.Text;
            cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;

            db.openConnection();

            string ableToLogin = (string)cmd.ExecuteScalar();

            if(ableToLogin == "yes")
            {
                MainForm mf = new MainForm(login.Text);
                mf.Show();
                this.Hide();
            }
            else
            {
                if (ableToLogin == "yes")
                {
                    if (login.Text == "hrmanager")
                    {
                        triesToEnter++;
                        if (triesToEnter > 2)
                        {
                            MessageBox.Show("The login for HR Manager has been locked!");
                            cmd.CommandText = "UPDATE `users` SET `AbleToLogin`=@able WHERE `Login`=\"hrmanager\"";
                            cmd.Parameters.Add("@able", MySqlDbType.VarChar).Value = "no";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    if(login.Text == "hrmanager")
                        label2.Text = "Login has been blocked for HR Manager!";
                    else
                        label2.Text = "Wrong credentials!";
                }
                label2.Left = (this.Width / 2) - (label2.Width / 2);
                label2.Show();
            }

            db.closeConnection();
        }

        private void passVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (passVisible.Checked == true)
                pass.UseSystemPasswordChar = false;
            else
                pass.UseSystemPasswordChar = true;
        }
    }
}