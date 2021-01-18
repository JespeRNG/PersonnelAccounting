using Bank;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_uchet
{
    public partial class DateUpdate : Form
    {
        private MySqlCommand cmd = new MySqlCommand();
        private DB db = new DB();
        private string mode, id;
        private int index;
        public DateUpdate(string id, int index)
        {
            this.id = id;
            this.index = index;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            MessageBox.Show(index.ToString());
            switch (index)
            {
                case 4:
                    header.Text = "Birthday of ";
                    dateTimePicker1.CustomFormat = "dd MMMM yyyy";
                    dateTimePicker1.MinDate = new DateTime(1970, 1, 1);
                    dateTimePicker1.MaxDate = new DateTime(2002, 1, 1);
                    break;
                case 5:
                    header.Text = "Name-Day of ";
                    dateTimePicker1.CustomFormat = "MMM dd";
                    dateTimePicker1.MinDate = new DateTime(2020, 1, 1);
                    dateTimePicker1.MaxDate = new DateTime(2020, 12, 31);
                    break;
                case 6:
                    header.Text = "Hiring Date of ";
                    dateTimePicker1.CustomFormat = "MMM dd, yyyy";
                    dateTimePicker1.MinDate = new DateTime(2020, 1, 1);
                    dateTimePicker1.MaxDate = DateTime.Today;
                    break;
                case 11:
                    header.Text = "Date of number update of ";
                    dateTimePicker1.CustomFormat = "dd MMMM yyyy";
                    dateTimePicker1.MinDate = new DateTime(2000, 1, 1);
                    dateTimePicker1.MaxDate = DateTime.Today;
                    break;
                default:
                    break;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DateUpdate_Load(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT `Last Name` FROM `staff` WHERE `id` = " + id;
            cmd.Connection = db.GetConnection();

            db.openConnection();
            header.Text += cmd.ExecuteScalar().ToString() + " ";
            db.closeConnection();
            cmd.CommandText = "SELECT `First Name` FROM `staff` WHERE `id` = " + id;
            db.openConnection();
            header.Text += cmd.ExecuteScalar().ToString() + " ";
            db.closeConnection();
            cmd.CommandText = "SELECT `Middle Name` FROM `staff` WHERE `id` = " + id;
            db.openConnection();
            header.Text += cmd.ExecuteScalar().ToString();
            db.closeConnection();
        }

        private void updBtn_Click(object sender, EventArgs e)
        {
            mode = "upd";
            cmd.Connection = db.GetConnection();
            switch(index)
            {
                case 4:
                    cmd.CommandText = "UPDATE `staff` SET `Date Of Birth` = @dateofb WHERE `id` = " + id;
                    cmd.Parameters.Add("@dateofb", MySqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("dd.MM.yy");
                    break;
                case 5:
                    cmd.CommandText = "UPDATE `staff` SET `Hire Date` = @hiredate WHERE `id` = " + id;
                    cmd.Parameters.Add("@hiredate", MySqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("MMM dd, yyyy");
                    break;
                case 6:
                    cmd.CommandText = "UPDATE `staff` SET `Date Of Number Update` = @dateofu WHERE `id` = " + id;
                    cmd.Parameters.Add("@dateofu", MySqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("dd.MM.yy");
                    break;
                case 11:
                    cmd.CommandText = "UPDATE `staff` SET `Name-Day` = @nameday WHERE `id` = " + id;
                    cmd.Parameters.Add("@nameday", MySqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("MMM dd");
                    break;
                default: 
                    break;
            }

            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                MessageBox.Show("Successfuly update the date!");
                this.Close();
            }
        }

        private void DateUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mode != "upd")
                if (e.CloseReason == CloseReason.UserClosing)
                    e.Cancel = MessageBox.Show("Are you sure you want to close this window ?",
                                               "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }
    }
}
