using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bank
{
    class DB
    {
        MySqlConnection sqlconnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=uchet");
        public void openConnection()
        {
            if (sqlconnection.State == System.Data.ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlconnection.State == System.Data.ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return sqlconnection;
        }
    }
}