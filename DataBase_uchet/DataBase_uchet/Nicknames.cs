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
        public Nicknames(string id)
        {
            InitializeComponent();

            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.GetConnection();
            
            db.openConnection();

            cmd.CommandText = "SELECT `Telegram` FROM `networks` WHERE `ID`=" + id;
            telegram.Text += (string)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT `Instagram` FROM `networks` WHERE `ID`=" + id;
            insta.Text += (string)cmd.ExecuteScalar();
            cmd.CommandText = "SELECT `Twitter` FROM `networks` WHERE `ID`=" + id;
            twitter.Text += (string)cmd.ExecuteScalar();

            db.closeConnection();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
