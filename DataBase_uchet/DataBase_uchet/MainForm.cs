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
        Form fm;
        string user;
        DataTable DT;
        DB db = new DB();
        DataView DV = new DataView();
        public MainForm()
        {
        }
        public MainForm(string user, Form fm)
        {
            this.fm = fm;
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
        public void addBtns()
        {
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

            addBtns();
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

        //FormClose Button
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deletingBtns()
        {
            if (user == "admin")
            {
                dataGridView1.Columns.RemoveAt(14);
                dataGridView1.Columns.RemoveAt(14);
            }
            else
                dataGridView1.Columns.RemoveAt(14);
        }
        //Refresh Button
        private void rfrshBtn_Click(object sender, EventArgs e)
        {
            deletingBtns();
            LoadInfo();
            TextBox[] tb = new TextBox[] { lNameInp, fNameInp, mNameInp, dobInp, depInp, posInp,
                rankInp, phoneInp, addInp, mailInp, ndayInp, dupdInp, hiredInp };
            foreach(TextBox t in tb)
                t.Text = "";
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
            db.closeConnection();
            return false;
        }

        //Function to find the remove button in a table
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex.ToString());
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
                           dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), user);
                    nickf.Show();
                }
            if(user != "admin")
                if (e.ColumnIndex == 14)
                    if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "...")
                    {
                        Nicknames nickf = new Nicknames(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                           dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()+ " " +
                           dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()+ " " +
                           dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), user);
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

            db.openConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `staff` SET `" + columnName + "`= '" + value + "' WHERE " +
                " `ID` = " + id + "", db.GetConnection());

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Successfully updated " + columnName + " for " + Lname + " " + Fname + " " + Mname);

            db.closeConnection();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            rfrshBtn_Click(sender, e);
        }

        StringBuilder sb = new StringBuilder();

        //Finding by fields
        private void Request(string inp, string column, string sender)
        {
            deletingBtns();
            
            DV = new DataView(DT);
            
            if(sb.Length == 0)
                sb.Append(column+ " LIKE '%" + inp + "%'");
            if (lNameInp.Text.Length > 0 && lNameInp.Name != sender)
                sb.Append(" AND `Last Name` LIKE '%" + lNameInp.Text + "%'");
            if (fNameInp.Text.Length > 0 && fNameInp.Name != sender)
                sb.Append(" AND `Last Name` LIKE '%" + fNameInp.Text + "%'");
            if (mNameInp.Text.Length > 0 && mNameInp.Name != sender)
                sb.Append(" AND `Last Name` LIKE '%" + mNameInp.Text + "%'");
            if (dobInp.Text.Length > 0 && dobInp.Name != sender)
                sb.Append(" AND `Last Name` LIKE '%" + dobInp.Text + "%'");
            if (depInp.Text.Length > 0 && depInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + depInp.Text + "%'");
            if (posInp.Text.Length > 0 && posInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + posInp.Text + "%'");
            if (rankInp.Text.Length > 0 && rankInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + rankInp.Text + "%'");
            if (phoneInp.Text.Length > 0 && phoneInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + phoneInp.Text + "%'");
            if (mailInp.Text.Length > 0 && mailInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + mailInp.Text + "%'");
            if (addInp.Text.Length > 0 && addInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + addInp.Text + "%'");
            if (hiredInp.Text.Length > 0 && hiredInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + hiredInp.Text + "%'");
            if (ndayInp.Text.Length > 0 && ndayInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + ndayInp.Text + "%'");
            if (dupdInp.Text.Length > 0 && dupdInp.Name != sender)
                sb.Append(" AND `Department` LIKE '%" + dupdInp.Text + "%'");

            DV.RowFilter = sb.ToString();
            sb.Clear();
            dataGridView1.DataSource = DV;
            addBtns();
        }
        private void lNameInp_TextChanged(object sender, EventArgs e) => Request(lNameInp.Text, "`Last Name`", "lNameInp");
        private void fNameInp_TextChanged(object sender, EventArgs e) => Request(fNameInp.Text, "`First Name`", "fNameInp");
        private void mNameInp_TextChanged(object sender, EventArgs e) => Request(mNameInp.Text, "`Middle Name`", "mNameInp");
        private void dobInp_TextChanged(object sender, EventArgs e) => Request(dobInp.Text, "`Date Of Birth`", "dobInp");
        private void depInp_TextChanged(object sender, EventArgs e) => Request(depInp.Text, "`Department`", "depInp");
        private void posInp_TextChanged(object sender, EventArgs e) => Request(posInp.Text, "`Position`", "posInp");
        private void rankInp_TextChanged(object sender, EventArgs e) => Request(rankInp.Text, "`Rank`", "rankInp");
        private void phoneInp_TextChanged(object sender, EventArgs e) => Request(phoneInp.Text, "`Phone Number`", "phoneInp");
        private void mailInp_TextChanged(object sender, EventArgs e) => Request(mailInp.Text, "`eMail`", "mailInp");
        private void addInp_TextChanged(object sender, EventArgs e) => Request(addInp.Text, "`Current Living Address`", "addInp");
        private void ndayInp_TextChanged(object sender, EventArgs e) => Request(ndayInp.Text, "`Name-Day`", "ndayInp");
        private void hiredInp_TextChanged(object sender, EventArgs e) => Request(hiredInp.Text, "`Hire Date`", "hiredInp");
        private void dupdInp_TextChanged(object sender, EventArgs e) => Request(dupdInp.Text, "`Date Of Number Update`", "dupdInp");
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fm.Show();
            this.Close();
        }
    }
}