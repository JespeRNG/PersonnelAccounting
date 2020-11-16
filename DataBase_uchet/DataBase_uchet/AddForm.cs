using Bank;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DataBase_uchet
{
    public partial class AddForm : Form
    {
        string sndr = "";
        Validation val = new Validation();
        public AddForm()
        {
            InitializeComponent();
        }
        private void AddForm_Load(object sender, EventArgs e)
        {
            addButton.BringToFront();
            button2.BringToFront();
            DateOfBirth.MinDate = new DateTime(1970, 1, 1);
            DateOfBirth.MaxDate = new DateTime(2002, 1, 1);
            hireDate.MinDate = new DateTime(2020, 1, 1);
            hireDate.MaxDate = DateTime.Today;
            dateofupd.MinDate = new DateTime(2000, 1, 1);
            dateofupd.MaxDate = DateTime.Today;
        }

        public static void ClearFormControls(Form form)
        {
            int cb = 0;
            foreach (Control control in form.Controls)
                if (control is PictureBox)
                    cb++;
            while(cb > 0)
                foreach (Control control in form.Controls)
                    if (control is PictureBox)
                    {
                        form.Controls.Remove(control);
                        cb--;
                    }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFormControls(this);
            }
            catch(Exception) { }

            DB db = new DB();
            bool isValid = true;

            MySqlCommand command = new MySqlCommand(
                "INSERT INTO `staff`(`Last Name`,`First Name`,`Middle Name`,`Date Of Birth`,`Name-Day`,`Hire Date`,`Department`,`Position`,`Rank`,"+
                "`Phone Number`,`Date Of Number Update`,`Current Living Address`,`eMail`)"+
                " VALUES (@lname,@fname,@fathname,@dateofb,@nameday,@hiredate,@dep,@position,@rank,@phone,@dateofu,@curaddress,@email);"
                , db.GetConnection());

            //Dates
            command.Parameters.Add("@dateofb", MySqlDbType.VarChar).Value = DateOfBirth.Value.ToString("dd.MM.yyyy");
            command.Parameters.Add("@hiredate", MySqlDbType.VarChar).Value = hireDate.Value.ToString("dd.MM.yyyy");
            command.Parameters.Add("@dateofu", MySqlDbType.VarChar).Value = dateofupd.Value.ToString("dd.MM.yyyy");

            if (val.isSymbolic(lName.Text,3,16)==true && val.isSymbolic(fName.Text,3,16) == true && val.isSymbolic(mName.Text, 3, 16) == true)
            {
                command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lName.Text;
                command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fName.Text;
                command.Parameters.Add("@fathName", MySqlDbType.VarChar).Value = mName.Text;
            }
            else
            {
                if(val.isSymbolic(lName.Text, 3, 16)==false)
                    this.Controls.Add(val.CreateImg((lName.Left + lName.Width) + 5, lName.Top + 3, "lName"));
                if(val.isSymbolic(fName.Text, 3, 16) == false)
                    this.Controls.Add(val.CreateImg((fName.Left+fName.Width)+5, fName.Top+3, "fName"));
                if (val.isSymbolic(mName.Text, 3, 16) == false)
                    this.Controls.Add(val.CreateImg((mName.Left + mName.Width) + 5, mName.Top + 3, "mName"));
                isValid = false;
            }

            if ( !String.IsNullOrEmpty(phoneNum.Text) ) 
            {
                if (!String.IsNullOrEmpty(phoneNum.Text) && val.isNumeric(phoneNum.Text) == true && String.IsNullOrEmpty(phoneNum2.Text))
                    command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phoneNum.Text;
                else if (val.isNumeric(phoneNum2.Text) && String.IsNullOrEmpty(phoneNum.Text))
                    command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phoneNum2.Text;
                else if (val.isNumeric(phoneNum.Text) == true && val.isNumeric(phoneNum2.Text) == true 
                    && !String.IsNullOrEmpty(phoneNum2.Text) && !String.IsNullOrEmpty(phoneNum.Text))
                    command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phoneNum.Text + ", " + phoneNum2.Text;
                else
                {
                    if(val.isNumeric(phoneNum.Text)==false || String.IsNullOrEmpty(phoneNum.Text))
                        this.Controls.Add(val.CreateImg((phoneNum.Left + phoneNum.Width) + 5, phoneNum.Top + 3, "phoneNum"));
                    if (val.isNumeric(phoneNum2.Text) == false && !String.IsNullOrEmpty(phoneNum2.Text))
                        this.Controls.Add(val.CreateImg((phoneNum2.Left + phoneNum2.Width) + 5, phoneNum2.Top + 3, "phoneNum2"));
                    isValid = false;
                }
            }
            else
            {
                this.Controls.Add(val.CreateImg((phoneNum.Left + phoneNum.Width) + 5, phoneNum.Top + 3, "phoneNum"));
                isValid = false;
            }
            if (val.isCombined(address.Text,3,16))
                command.Parameters.Add("@curaddress", MySqlDbType.VarChar).Value = address.Text;
            else
            {
                this.Controls.Add(val.CreateImg((address.Left + address.Width) + 5, address.Top + 3, "address"));
                isValid = false;
            }    
            if (val.isMailCorrect(email.Text))
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
            else
            {
                this.Controls.Add(val.CreateImg((email.Left + email.Width) + 5, email.Top + 3, "eMail"));
                isValid = false;
            }

            MySqlCommand netcmd = new MySqlCommand(
                "INSERT INTO `networks`(`Telegram`,`Instagram`,`Twitter`) VALUES (@telegram,@instagram,@twitter);"
                , db.GetConnection());

            //Social Networks
            if (val.isCombined(telegram.Text, 0, 16))
                netcmd.Parameters.Add("@telegram", MySqlDbType.VarChar).Value = telegram.Text;
            else if (telegram.Text.Length == 0)
                netcmd.Parameters.Add("@telegram", MySqlDbType.VarChar).Value = "-";
            else
            {
                this.Controls.Add(val.CreateImg((groupBox1.Left + groupBox1.Width) + 5, groupBox1.Top + 55, "telegram"));
                isValid = false;
            }
            if (val.isCombined(instagram.Text, 0, 16))
                netcmd.Parameters.Add("@instagram", MySqlDbType.VarChar).Value = instagram.Text;
            else if (instagram.Text.Length == 0)
                netcmd.Parameters.Add("@instagram", MySqlDbType.VarChar).Value = "-";
            else
            {
                this.Controls.Add(val.CreateImg((groupBox1.Left + groupBox1.Width) + 5, groupBox1.Top + 105, "instagram"));
                isValid = false;
            }
            if (val.isCombined(twitter.Text, 0, 16))
                netcmd.Parameters.Add("@twitter", MySqlDbType.VarChar).Value = twitter.Text;
            else if (twitter.Text.Length == 0)
                netcmd.Parameters.Add("@twitter", MySqlDbType.VarChar).Value = "-";
            else
            {
                this.Controls.Add(val.CreateImg((groupBox1.Left + groupBox1.Width) + 5, groupBox1.Top + 155, "twitter"));
                isValid = false;
            }

            //DropDown Boxes
            if(monthBox.Text.Length > 0 && dayBox.Text.Length > 0)
                command.Parameters.Add("@nameday", MySqlDbType.VarChar).Value = dayBox.Text + " " + monthBox.Text;
            else if (monthBox.Text.Length == 0 || dayBox.Text.Length == 0)
                command.Parameters.Add("@nameday", MySqlDbType.VarChar).Value = "-";
            else
            {
                MessageBox.Show("Check name-day area!");
                
                isValid = false;
            }
            if (depBox.Text.Length > 0)
            {
                command.Parameters.Add("@dep", MySqlDbType.VarChar).Value = depBox.Text;
            }
            else
            {
                this.Controls.Add(val.CreateImg((depBox.Left + depBox.Width) + 5, depBox.Top + 3, "depBox"));
                isValid = false;
            }
            if (posBox.Text.Length > 0)
                command.Parameters.Add("@position", MySqlDbType.VarChar).Value = posBox.Text;
            else
            {
                this.Controls.Add(val.CreateImg((posBox.Left + posBox.Width) + 5, posBox.Top + 3, "posBox"));
                isValid = false;
            }
            if (rankBox.Text.Length > 0)
                command.Parameters.Add("@rank", MySqlDbType.VarChar).Value = rankBox.Text;
            else
            {
                this.Controls.Add(val.CreateImg((rankBox.Left + rankBox.Width) + 5, rankBox.Top + 3, "rankBox"));
                isValid = false;
            }

            //Final validation check
            if (isValid == true)
            {
                db.openConnection();
            
                if (command.ExecuteNonQuery() == 1 && netcmd.ExecuteNonQuery() == 1)
                {
                    sndr = "add";
                    db.closeConnection();
                    this.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sndr = "";
            this.Close();
        }
        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sndr != "add")
                if (e.CloseReason == CloseReason.UserClosing)
                    e.Cancel = MessageBox.Show("Are you sure you want to close this window ?\nAll the filled fields will be erased!",
                                               "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }
        private void fName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (fName.Text.Length < 16 && val.isSymbolicPress(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 8)
                e.Handled = false;
        }
        private void lName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (lName.Text.Length < 16 && val.isSymbolicPress(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 8)
                e.Handled = false;
        }
        private void mName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (mName.Text.Length < 16 && val.isSymbolicPress(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 8)
                e.Handled = false;
        }
        private void phoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (val.isNumericPress(e.KeyChar, phoneNum.Text))
                e.Handled = false;
        }
        private void phoneNum2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (val.isNumericPress(e.KeyChar, phoneNum2.Text))
                e.Handled = false;
        }

        private void telegram_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (telegram.Text.Length < 16 && val.isCombinedPress(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 8)
                e.Handled = false;
        }

        private void instagram_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (instagram.Text.Length < 16 && val.isCombinedPress(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 8)
                e.Handled = false;
        }

        private void twitter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (twitter.Text.Length < 16 && val.isCombinedPress(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 8)
                e.Handled = false;
        }

        private void address_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (address.Text.Length < 16 && val.isCombinedPress(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 8 ||
                    e.KeyChar == '/' || e.KeyChar == ' ')
                e.Handled = false;
        }
    }
}