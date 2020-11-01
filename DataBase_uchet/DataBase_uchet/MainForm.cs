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
    public partial class MainForm : Form
    {
        string lName = "";
        string user;
        DataTable DT;
        DB db = new DB();
        public MainForm()
        {
        }
        public MainForm(string user)
        {
            this.user = user;
            InitializeComponent();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.ShowDialog(this);
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            label1.Text = "HR Manager";
            if (user == "admin")
            {
                label1.Text = "Administrator";
                editCheck.Visible = true;
                editCheck.Enabled = true;
                addButton.Visible = true;
                addButton.Enabled = true;
            }

            LoadInfo();
        }

        public void LoadInfo()
        {
            db.openConnection();
            MySqlCommand command = new MySqlCommand();

            if (user == "admin")
                command.CommandText = "SELECT * FROM `staff`";
            else
                command.CommandText = "SELECT `ID`,`Last Name`,`First Name`,`Middle Name`,`Date Of Birth`,`Name-Day`,`Hire Date`,`Department`,`Position`,`Rank`,`Phone Number`,`Date Of Number Update`,`Current Living Address`,`eMail` FROM `staff`";
            command.Connection = db.GetConnection();

            DT = new DataTable();
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = command;
            ad.Fill(DT);

            db.closeConnection();

            dataGridView1.DataSource = DT;

            if (user == "admin")
            {
                if (dataGridView1.Columns.Count < 17)
                {
                    DataGridViewButtonColumn btnrm = new DataGridViewButtonColumn();
                    btnrm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnrm.HeaderText = "Remove";
                    btnrm.Text = "Remove";
                    btnrm.UseColumnTextForButtonValue = true;
                    btnrm.FlatStyle = FlatStyle.Flat;
                    btnrm.CellTemplate.Style.BackColor = Color.Tomato;
                    btnrm.CellTemplate.Style.ForeColor = Color.White;
                    dataGridView1.Columns.Add(btnrm);

                    DataGridViewButtonColumn btnn = new DataGridViewButtonColumn();
                    btnn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnn.HeaderText = "Nicknames";
                    btnn.Text = "...";
                    btnn.UseColumnTextForButtonValue = true;
                    btnn.FlatStyle = FlatStyle.Flat;
                    btnn.CellTemplate.Style.BackColor = Color.SkyBlue;
                    btnn.CellTemplate.Style.ForeColor = Color.White;
                    dataGridView1.Columns.Add(btnn);
                }
            }
            else
            {
                if (dataGridView1.Columns.Count < 16)
                {
                    DataGridViewButtonColumn btnn = new DataGridViewButtonColumn();
                    btnn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnn.HeaderText = "Nicknames";
                    btnn.Text = "...";
                    btnn.UseColumnTextForButtonValue = true;
                    btnn.FlatStyle = FlatStyle.Flat;
                    btnn.CellTemplate.Style.BackColor = Color.SkyBlue;
                    btnn.CellTemplate.Style.ForeColor = Color.White;
                    dataGridView1.Columns.Add(btnn);
                }
            }
        }

        private void editCheck_CheckedChanged(object sender, EventArgs e)
        {

            if (editCheck.Checked == true)
            {
                dataGridView1.ReadOnly = false;
                updBtn.Visible = true;
                updBtn.Enabled = true;
            }
            else
            {
                dataGridView1.ReadOnly = true;
                updBtn.Visible = false;

            }
        }
        private void lNameInp_KeyPress(object sender, KeyPressEventArgs e)
        {
            lName = lNameInp.Text;
            Request();
        }
        private void Request()
        {
            DataView DV = new DataView(DT);
            DV.RowFilter = string.Format("`Last Name` LIKE '%{0}%'", lName);
            dataGridView1.DataSource = DV;
        }

        //FormClose Button
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Refresh Button
        private void rfrshBtn_Click(object sender, EventArgs e)
        {
            if(user == "admin")
            {
                dataGridView1.Columns.RemoveAt(14);
                dataGridView1.Columns.RemoveAt(14);
            }
            else
                dataGridView1.Columns.RemoveAt(14);
            LoadInfo();
        }

        //Function to remove a personnel
        private bool PersonRemoval(int id)
        {
            MySqlCommand DeleteCommand = new MySqlCommand("DELETE FROM `staff` WHERE ID = @ID", db.GetConnection());
            MySqlCommand DeleteNetCommand = new MySqlCommand("DELETE FROM `networks` WHERE ID = @ID", db.GetConnection());
            DeleteCommand.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            DeleteNetCommand.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

            db.openConnection();
            if (DeleteCommand.ExecuteNonQuery() == 1 && DeleteNetCommand.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }

            return false;
        }

        //Function to find the remove button in a table
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
                if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "Remove")
                {
                    if (MessageBox.Show("Are you sure you want to remove\n" +
                       dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + ' ' +
                           dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + ' ' +
                               dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                                "Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (PersonRemoval(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())))
                        {
                            MessageBox.Show("Successfuly removed " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() +
                                ' ' + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + ' ' +
                                    dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                            dataGridView1.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            if (e.ColumnIndex == 15)
                if (dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString() == "...")
                {
                    Nicknames nickf = new Nicknames(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " +
                           dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + " " +
                           dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    nickf.Show();
                }
            if(user != "admin")
                if (e.ColumnIndex == 14)
                    if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "...")
                    {
                        Nicknames nickf = new Nicknames(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                           dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()+ " " +
                           dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()+ " " +
                           dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                        nickf.Show();
                    }
        }

        private void updBtn_Click(object sender, EventArgs e)
        {
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string Lname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            string Fname = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            string Mname = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            string columnName = dataGridView1.CurrentCell.OwningColumn.HeaderText;
            string value = dataGridView1.CurrentCell.Value.ToString();

            /* if (columnName == "Date Of Birth")
             {
                 string [] array1 = new string[3];
                 array1 = value.Split('.',)
             }*/

            //19.02.2002 = 2002-02-19

            db.openConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `staff` SET `" + columnName + "`= '" + value + "' WHERE " +
                " `ID` = " + id + "", db.GetConnection());

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Successfully updated " + columnName + " for " + Lname + " " + Fname + " " + Mname);

            db.closeConnection();
        }
    }
}