using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Bank;

namespace DataBase_uchet
{
    public partial class ComboBoxForm : Form
    {
        private MySqlCommand cmd = new MySqlCommand();
        private DB db = new DB();
        private string id, mode = "";
        public ComboBoxForm(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void ComboBoxForm_Load(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT `Last Name` FROM `staff` WHERE `id` = " + id;
            cmd.Connection = db.GetConnection();

            db.openConnection();
            header.Text = cmd.ExecuteScalar().ToString() + " ";
            db.closeConnection();
            cmd.CommandText = "SELECT `First Name` FROM `staff` WHERE `id` = " + id;
            db.openConnection();
            header.Text += cmd.ExecuteScalar().ToString() + " ";
            db.closeConnection();
            cmd.CommandText = "SELECT `Middle Name` FROM `staff` WHERE `id` = " + id;
            db.openConnection();
            header.Text += cmd.ExecuteScalar().ToString();
            db.closeConnection();

            cmd.CommandText = "SELECT `Department` FROM `staff` WHERE `id` = " + id;
            db.openConnection();
            depBox.Text = cmd.ExecuteScalar().ToString();
            db.closeConnection();

            cmd.CommandText = "SELECT `Rank` FROM `staff` WHERE `id` = " + id;
            db.openConnection();
            rankBox.Text = cmd.ExecuteScalar().ToString();
            db.closeConnection();

            cmd.CommandText = "SELECT `Position` FROM `staff` WHERE `id` = " + id;
            db.openConnection();
            posBox.Text = cmd.ExecuteScalar().ToString();
            db.closeConnection();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ComboBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mode != "upd")
                if (e.CloseReason == CloseReason.UserClosing)
                    e.Cancel = MessageBox.Show("Are you sure you want to close this window ?",
                                               "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }
        private void updBtn_Click(object sender, EventArgs e)
        {
            mode = "upd";
            cmd.CommandText = "UPDATE `staff` SET `Department` = '" + depBox.Text + "', `Position` = '" 
                + posBox.Text + "', `Rank` = '" + rankBox.Text + "' WHERE `id` = " + id;
            cmd.Connection = db.GetConnection();

            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                MessageBox.Show("Successfuly update the working information!");
                this.Close();
            }
        }
    }
}
