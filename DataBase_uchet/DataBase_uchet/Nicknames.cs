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
using MySql.Data.Types;
using Bank;
using MySqlX.XDevAPI.Relational;
using System.CodeDom;

namespace DataBase_uchet
{
    public partial class Nicknames : Form
    {
        string id, teleg, inst, twit, fio, user;
        DB db = new DB();
        MySqlCommand cmd = new MySqlCommand();
        Validation val = new Validation();

        public static void ClearFormControls(Form form)
        {
            foreach (Control control in form.Controls)
                if (control is PictureBox)
                    form.Controls.Remove(control);

            foreach (Control control in form.Controls)
                if (control is PictureBox)
                    form.Controls.Remove(control);
        }
        public Nicknames(string id, string fio, string user)
        {
            InitializeComponent();
            this.id = id;
            this.user = user;
            this.fio = fio;
            if (user == "hrmanager")
            {
                button1.Visible = false;
                button1.Enabled = false;
                closeBtn.Left = (this.Width / 2) - closeBtn.Width / 2;
            }
            getInfo(id);
        }
        public void getInfo(string id)
        {
            cmd.Connection = db.GetConnection();
            db.openConnection();

            cmd.CommandText = "SELECT `Telegram` FROM `networks` WHERE `ID`=" + id;
            teleg = (string)cmd.ExecuteScalar();
            telegram.Text = "Telegram: " + teleg; 
            cmd.CommandText = "SELECT `Instagram` FROM `networks` WHERE `ID`=" + id;
            inst = (string)cmd.ExecuteScalar();
            insta.Text = "Instagram: " + inst;
            cmd.CommandText = "SELECT `Twitter` FROM `networks` WHERE `ID`=" + id;
            twit = (string)cmd.ExecuteScalar();
            twitter.Text = "Twitter: "+twit;

            db.closeConnection();
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            if(closeBtn.Text == "Back")
            {
                if (twitBox.Text != twit || instaBox.Text != inst || telegBox.Text != teleg)
                {
                    if (MessageBox.Show("Are you sure you want to close this window?\nAll the filled fields will be erased!",
                        "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        twitBox.Visible = false;
                        twitBox.Enabled = false;
                        telegBox.Visible = false;
                        telegBox.Enabled = false;
                        instaBox.Visible = false;
                        instaBox.Enabled = false;
                        getInfo(id);
                        closeBtn.Text = "Close";
                        button1.Text = "Edit";
                    }
                }
                else
                {
                    twitBox.Visible = false;
                    twitBox.Enabled = false;
                    telegBox.Visible = false;
                    telegBox.Enabled = false;
                    instaBox.Visible = false;
                    instaBox.Enabled = false;
                    getInfo(id);
                    closeBtn.Text = "Close";
                    button1.Text = "Edit";
                }
            }
            else
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Edit")
            {
                telegram.Text = "Telegram";
                insta.Text = "Instagram";
                twitter.Text = "Twitter";
                twitBox.Visible = true;
                twitBox.Enabled = true;
                telegBox.Visible = true;
                telegBox.Enabled = true;
                instaBox.Visible = true;
                instaBox.Enabled = true;

                twitBox.Text = twit;
                instaBox.Text = inst;
                telegBox.Text = teleg;

                button1.Text = "Save";
                closeBtn.Text = "Back";
            }
            else
            {
                ClearFormControls(this);
                if (val.isCombined(twitBox.Text, 3, 16) && val.isCombined(instaBox.Text, 3, 16) && val.isCombined(telegBox.Text, 3, 16) && 
                    (twitBox.Text != twit || instaBox.Text != inst || telegBox.Text != teleg))
                {
                    cmd.Connection = db.GetConnection();
                    db.openConnection();

                    cmd.CommandText = "UPDATE `networks` SET `Telegram`='" + telegBox.Text +
                        "', `Instagram`='" + instaBox.Text + "', `Twitter`='" + twitBox.Text + "' WHERE `id`=" + id;

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        twitBox.Visible = false;
                        twitBox.Enabled = false;
                        telegBox.Visible = false;
                        telegBox.Enabled = false;
                        instaBox.Visible = false;
                        instaBox.Enabled = false;
                        button1.Text = "Edit";
                        closeBtn.Text = "Close";
                        MessageBox.Show("Successfuly updated nicknames for \n" + fio);
                    }

                    db.closeConnection();
                    getInfo(id);
                }
                else
                {
                    if (!val.isCombined(twitBox.Text, 3, 16))
                        this.Controls.Add(val.CreateImg(false, (twitBox.Left + twitBox.Width) + 5, twitBox.Top + 3));
                    if (!val.isCombined(instaBox.Text, 3, 16))
                        this.Controls.Add(val.CreateImg(false, (instaBox.Left + instaBox.Width) + 5, instaBox.Top + 3));
                    if (!val.isCombined(telegBox.Text, 3, 16))
                        this.Controls.Add(val.CreateImg(false, (telegBox.Left + telegBox.Width) + 5, telegBox.Top + 3));
                }
            }
        }
    }
}