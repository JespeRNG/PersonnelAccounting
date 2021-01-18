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
using System.Text.RegularExpressions;
using MySqlX.XDevAPI.Relational;
using System.CodeDom;
using System.Reflection;

namespace DataBase_uchet
{
    public partial class MainForm : Form
    {
        Form fm;
        string user;
        DataTable DT;
        DB db = new DB();
        DataView DV = new DataView();
        Validation valInp = new Validation();
        string s;
        TextBox innerTextBox;
        DataGridViewCell cellCurr;
        public MainForm(string user, Form fm)
        {
            this.fm = fm;
            this.user = user;
            InitializeComponent();
            SetDoubleBuffered(dataGridView1, true);
        }
        public void SetDoubleBuffered(Control c, bool value)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(c, value, null);

                MethodInfo mi = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                if (mi != null)
                    mi.Invoke(c, new object[] { ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true });

                mi = typeof(Control).GetMethod("UpdateStyles", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                if (mi != null)
                    mi.Invoke(c, null);
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.ShowDialog(this);
            TextBox[] tb = new TextBox[] { lNameInp, fNameInp, mNameInp, dobInp, depInp, posInp,
                rankInp, phoneInp, addInp, mailInp, ndayInp, dupdInp, hiredInp };
            foreach (TextBox t in tb)
                t.Text = "";
            deletingBtns();
            LoadInfo();
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
                    btnn.CellTemplate.Style.BackColor = Color.SteelBlue;
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
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[11].HeaderText = "Date Of Update";
            dataGridView1.Columns[12].HeaderText = "Current Address";

            addBtns();

            // Positioning Inputs
            lNameInp.Width = dataGridView1.GetCellDisplayRectangle(1, 0, false).Width - 10;
            lNameInp.Left = (dataGridView1.GetCellDisplayRectangle(1, 0, false).X + lNameInp.Width / 2) - lNameInp.Width / 2 + 5;

            fNameInp.Width = dataGridView1.GetCellDisplayRectangle(2, 0, false).Width - 10;
            fNameInp.Left = (dataGridView1.GetCellDisplayRectangle(2, 0, false).X + fNameInp.Width / 2) - fNameInp.Width / 2 + 5;

            mNameInp.Width = dataGridView1.GetCellDisplayRectangle(3, 0, false).Width - 10;
            mNameInp.Left = (dataGridView1.GetCellDisplayRectangle(3, 0, false).X + mNameInp.Width / 2) - mNameInp.Width / 2 + 5;

            dobInp.Width = dataGridView1.GetCellDisplayRectangle(4, 0, false).Width - 10;
            dobInp.Left = (dataGridView1.GetCellDisplayRectangle(4, 0, false).X + dobInp.Width / 2) - dobInp.Width / 2 + 5;

            ndayInp.Width = dataGridView1.GetCellDisplayRectangle(5, 0, false).Width - 10;
            ndayInp.Left = (dataGridView1.GetCellDisplayRectangle(5, 0, false).X + ndayInp.Width / 2) - ndayInp.Width / 2 + 5;

            hiredInp.Width = dataGridView1.GetCellDisplayRectangle(6, 0, false).Width - 10;
            hiredInp.Left = (dataGridView1.GetCellDisplayRectangle(6, 0, false).X + hiredInp.Width / 2) - hiredInp.Width / 2 + 5;

            depInp.Width = dataGridView1.GetCellDisplayRectangle(7, 0, false).Width - 10;
            depInp.Left = (dataGridView1.GetCellDisplayRectangle(7, 0, false).X + depInp.Width / 2) - depInp.Width / 2 + 5;

            posInp.Width = dataGridView1.GetCellDisplayRectangle(8, 0, false).Width - 10;
            posInp.Left = (dataGridView1.GetCellDisplayRectangle(8, 0, false).X + posInp.Width / 2) - posInp.Width / 2 + 5;

            rankInp.Width = dataGridView1.GetCellDisplayRectangle(9, 0, false).Width - 10;
            rankInp.Left = (dataGridView1.GetCellDisplayRectangle(9, 0, false).X + rankInp.Width / 2) - rankInp.Width / 2 + 5;

            phoneInp.Width = dataGridView1.GetCellDisplayRectangle(10, 0, false).Width - 10;
            phoneInp.Left = (dataGridView1.GetCellDisplayRectangle(10, 0, false).X + phoneInp.Width / 2) - phoneInp.Width / 2 + 5;

            dupdInp.Width = dataGridView1.GetCellDisplayRectangle(11, 0, false).Width - 10;
            dupdInp.Left = (dataGridView1.GetCellDisplayRectangle(11, 0, false).X + dupdInp.Width / 2) - dupdInp.Width / 2 + 5;

            addInp.Width = dataGridView1.GetCellDisplayRectangle(12, 0, false).Width - 10;
            addInp.Left = (dataGridView1.GetCellDisplayRectangle(12, 0, false).X + addInp.Width / 2) - addInp.Width / 2 + 5;

            mailInp.Width = dataGridView1.GetCellDisplayRectangle(13, 0, false).Width - 10;
            mailInp.Left = (dataGridView1.GetCellDisplayRectangle(13, 0, false).X + mailInp.Width / 2) - mailInp.Width / 2 + 5;
            // Positioning Inputs
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
            foreach (TextBox t in tb)
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
                    nickf.ShowDialog(this);
                }
            if(editCheck.Checked && (e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9))
            {
                ComboBoxForm cbf = new ComboBoxForm(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                cbf.ShowDialog(this);
                deletingBtns();
                LoadInfo();
            }
            if (editCheck.Checked && (e.ColumnIndex == 5 || e.ColumnIndex == 11 || e.ColumnIndex == 6 || e.ColumnIndex == 4))
            {
                DateUpdate du = new DateUpdate(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(), e.ColumnIndex);
                du.ShowDialog(this);
                deletingBtns();
                LoadInfo();
            }
            if (user != "admin")
                if (e.ColumnIndex == 14)
                    if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "...")
                    {
                        Nicknames nickf = new Nicknames(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                           dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " +
                           dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + " " +
                           dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), user);
                        nickf.Show();
                    }
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

            if (sb.Length == 0)
                sb.Append(column + " LIKE '" + inp + "%'");
            if (lNameInp.Text.Length > 0 && lNameInp.Name != sender)
                sb.Append(" AND `Last Name` LIKE '" + lNameInp.Text + "%'");
            if (fNameInp.Text.Length > 0 && fNameInp.Name != sender)
                sb.Append(" AND `First Name` LIKE '" + fNameInp.Text + "%'");
            if (mNameInp.Text.Length > 0 && mNameInp.Name != sender)
                sb.Append(" AND `Middle Name` LIKE '" + mNameInp.Text + "%'");
            if (dobInp.Text.Length > 0 && dobInp.Name != sender)
                sb.Append(" AND `Date Of Birth` LIKE '" + dobInp.Text + "%'");
            if (depInp.Text.Length > 0 && depInp.Name != sender)
                sb.Append(" AND `Department` LIKE '" + depInp.Text + "%'");
            if (posInp.Text.Length > 0 && posInp.Name != sender)
                sb.Append(" AND `Position` LIKE '" + posInp.Text + "%'");
            if (rankInp.Text.Length > 0 && rankInp.Name != sender)
                sb.Append(" AND `Rank` LIKE '" + rankInp.Text + "%'");
            if (phoneInp.Text.Length > 0 && phoneInp.Name != sender)
                sb.Append(" AND `Phone Number` LIKE '" + phoneInp.Text + "%'");
            if (mailInp.Text.Length > 0 && mailInp.Name != sender)
                sb.Append(" AND `eMail` LIKE '" + mailInp.Text + "%'");
            if (addInp.Text.Length > 0 && addInp.Name != sender)
                sb.Append(" AND `Current Living Address` LIKE '" + addInp.Text + "%'");
            if (hiredInp.Text.Length > 0 && hiredInp.Name != sender)
                sb.Append(" AND `Hire Date` LIKE '" + hiredInp.Text + "%'");
            if (ndayInp.Text.Length > 0 && ndayInp.Name != sender)
                sb.Append(" AND `Name-Day` LIKE '" + ndayInp.Text + "%'");
            if (dupdInp.Text.Length > 0 && dupdInp.Name != sender)
                sb.Append(" AND `Date Of Number Update` LIKE '" + dupdInp.Text + "%'");

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
        Validation val = new Validation();
        private void updBtn_Click(object sender, EventArgs e)
        {
            bool check = true;
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string Lname = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            string Fname = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            string Mname = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            string columnName = dataGridView1.CurrentCell.OwningColumn.Name;
            string value = dataGridView1.CurrentCell.Value.ToString();
            //MessageBox.Show(columnName);

            /*if (columnName == "Date Of Birth" || columnName == "Date Of Number Update" || columnName == "Hire Date")
            {
                if (columnName == "Date Of Birth" && !val.checkDate(value, "dob"))
                    check = false;
                if (columnName == "Date Of Number Update" && !val.checkDate(value, "dupd"))
                    check = false;
                if (columnName == "Hire Date" && !val.checkDate(value, "hd"))
                    check = false;
            }
            if (columnName == "Name-Day")
                if (Regex.Matches(value, @"[,./+{};:-]").Count > 0)
                {
                    MessageBox.Show("Symbols aren't available!");
                    check = false;
                }*/
            if (columnName == "eMail")
                if (!val.isMailCorrect(value))
                {
                    MessageBox.Show("Incorrect value");
                    check = false;
                }
            if (columnName == "First Name" || columnName == "Last Name" || columnName == "Middle Name")
                if (!val.isSymbolic(value, 3, 16))
                {
                    MessageBox.Show("Incorrect value");
                    check = false;
                }
            if (columnName == "Current Living Address")
                if (!val.isValidAddres(value))
                {
                    MessageBox.Show("Incorrect value");
                    check = false;
                }
            if (columnName == "Phone Number")
                if (!val.isNumeric(value))
                {
                    MessageBox.Show("Incorrect value");
                    check = false;
                }
            if (check == true)
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("UPDATE `staff` SET `" + columnName + "`= '" + value + "' WHERE " +
                    " `ID` = " + id + "", db.GetConnection());
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Successfully updated " + columnName + " for " + Lname + " " + Fname + " " + Mname);
                db.closeConnection();
            }
            else
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT `"+ columnName + "` FROM `staff` WHERE `id` = " + id, db.GetConnection());
                dataGridView1.CurrentCell.Value = command.ExecuteScalar();
                db.closeConnection();
            }
        }
        /*private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (cellCurr == dataGridView1.CurrentCell)
            {
                if (e.Control is TextBox)
                {
                    innerTextBox = e.Control as TextBox;
                    s = innerTextBox.Text;
                    innerTextBox.KeyPress += innerTextBox_KeyPress;
                }
            }
            else
            {
                if (e.Control is TextBox)
                {
                    innerTextBox = e.Control as TextBox;
                    s = innerTextBox.Text;
                    innerTextBox.KeyPress -= innerTextBox_KeyPress;
                    innerTextBox.KeyPress += innerTextBox_KeyPress;
                }
            }
            cellCurr = dataGridView1.CurrentCell;
        }*/
        /*private void innerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            string clmn = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].OwningColumn.Name;
            if (clmn == "First Name" || clmn == "Last Name" || clmn == "Middle Name" || clmn == "Rank" 
                || clmn == "Department" || clmn == "Position")
            {
                if (s.Length < 16 && valInp.isSymbolicPress(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 8)
                {
                    if (Convert.ToInt32(e.KeyChar) == 8 && s.Length > 0)
                        s = s.Remove(s.Length - 1);
                    else
                        s += e.KeyChar;
                    e.Handled = false;
                    dataGridView1.CurrentCell.Value = s;
                }
            }
            if (clmn == "Phone Number")
            {
                if (Regex.Matches(dataGridView1.CurrentCell.Value.ToString(), @"[,]").Count == 1)
                    e.Handled = false;
                else if (s.Length < 13 && valInp.isNumericPress(e.KeyChar, dataGridView1.CurrentCell.Value.ToString()) ||
                            Convert.ToInt32(e.KeyChar) == 8)
                {
                    if (Convert.ToInt32(e.KeyChar) == 8 && s.Length > 0)
                    {
                        s = s.Remove(s.Length - 1);
                    }
                    else
                    {
                        s += e.KeyChar;
                    }
                    e.Handled = false;
                    dataGridView1.CurrentCell.Value = s;
                }
            }
            else if(clmn == "Current Living Address")
            {
                if (s.Length < 16 && (valInp.isCombinedPress(e.KeyChar)
                     || e.KeyChar == ' ') || Convert.ToInt32(e.KeyChar) == 8)
                {
                    if (Convert.ToInt32(e.KeyChar) == 8 && s.Length > 0)
                    {
                        s = s.Remove(s.Length - 1);
                    }
                    else
                    {
                        s += e.KeyChar;
                    }
                    e.Handled = false;
                    dataGridView1.CurrentCell.Value = s;
                }
            }
            else if (clmn == "eMail" || clmn == "Date Of Birth" || clmn == "Name-Day" || clmn == "Hire Date" 
                || clmn == "Date Of Number Update")
                e.Handled = false;
        }*/
    }   
}