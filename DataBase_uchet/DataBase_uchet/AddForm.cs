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

namespace DataBase_uchet
{
    public partial class AddForm : Form
    {
        static int cntr = 0;
        Validation val = new Validation();
        public AddForm()
        {
            InitializeComponent();
        }
        private void AddForm_Load(object sender, EventArgs e)
        {
            addButton.BringToFront();
            button2.BringToFront();
        }

        public static void ClearFormControls(Form form)
        {
            foreach (Control control in form.Controls)
                if (control is PictureBox)
                    form.Controls.Remove(control);

            foreach (Control control in form.Controls)
                if (control is PictureBox)
                    form.Controls.Remove(control);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            cntr++;
            if (cntr > 1)
                ClearFormControls(this);

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
                    this.Controls.Add(val.CreateImg(false, (lName.Left + lName.Width) + 5, lName.Top + 3));
                if(val.isSymbolic(fName.Text, 3, 16) == false)
                    this.Controls.Add(val.CreateImg(false, (fName.Left+fName.Width)+5, fName.Top+3));
                if (val.isSymbolic(mName.Text, 3, 16) == false)
                    this.Controls.Add(val.CreateImg(false, (mName.Left + mName.Width) + 5, mName.Top + 3));
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
                        this.Controls.Add(val.CreateImg(false, (phoneNum.Left + phoneNum.Width) + 5, phoneNum.Top + 3));
                    if (val.isNumeric(phoneNum2.Text) == false && !String.IsNullOrEmpty(phoneNum2.Text))
                        this.Controls.Add(val.CreateImg(false, (phoneNum2.Left + phoneNum2.Width) + 5, phoneNum2.Top + 3));
                    isValid = false;
                }
            }
            else
            {
                this.Controls.Add(val.CreateImg(false, (phoneNum.Left + phoneNum.Width) + 5, phoneNum.Top + 3));
                isValid = false;
            }
            if (val.isCombined(address.Text,3,16))
                command.Parameters.Add("@curaddress", MySqlDbType.VarChar).Value = address.Text;
            else
            {
                this.Controls.Add(val.CreateImg(false, (address.Left + address.Width) + 5, address.Top + 3));
                isValid = false;
            }    
            if (val.isMailCorrect(email.Text))
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
            else
            {
                this.Controls.Add(val.CreateImg(false, (email.Left + email.Width) + 5, email.Top + 3));
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
                this.Controls.Add(val.CreateImg(false, (groupBox1.Left + groupBox1.Width) + 5, groupBox1.Top + 55));
                isValid = false;
            }
            if (val.isCombined(instagram.Text, 0, 16))
                netcmd.Parameters.Add("@instagram", MySqlDbType.VarChar).Value = instagram.Text;
            else if (instagram.Text.Length == 0)
                netcmd.Parameters.Add("@instagram", MySqlDbType.VarChar).Value = "-";
            else
            {
                this.Controls.Add(val.CreateImg(false, (groupBox1.Left + groupBox1.Width) + 5, groupBox1.Top + 105));
                isValid = false;
            }
            if (val.isCombined(twitter.Text, 0, 16))
                netcmd.Parameters.Add("@twitter", MySqlDbType.VarChar).Value = twitter.Text;
            else if (twitter.Text.Length == 0)
                netcmd.Parameters.Add("@twitter", MySqlDbType.VarChar).Value = "-";
            else
            {
                this.Controls.Add(val.CreateImg(false, (groupBox1.Left + groupBox1.Width) + 5, groupBox1.Top + 155));
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
                this.Controls.Add(val.CreateImg(false, (depBox.Left + depBox.Width) + 5, depBox.Top + 3));
                isValid = false;
            }
            if (posBox.Text.Length > 0)
                command.Parameters.Add("@position", MySqlDbType.VarChar).Value = posBox.Text;
            else
            {
                this.Controls.Add(val.CreateImg(false, (posBox.Left + posBox.Width) + 5, posBox.Top + 3));
                isValid = false;
            }
            if (rankBox.Text.Length > 0)
                command.Parameters.Add("@rank", MySqlDbType.VarChar).Value = rankBox.Text;
            else
            {
                this.Controls.Add(val.CreateImg(false, (rankBox.Left + rankBox.Width) + 5, rankBox.Top + 3));
                isValid = false;
            }

            //Final validation check
            if (isValid == true)
            {
                db.openConnection();
            
                if (command.ExecuteNonQuery() == 1 && netcmd.ExecuteNonQuery() == 1)
                {
                    db.closeConnection(); 
                    this.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?\nAll the filled fields will be erased!", "Closing", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}