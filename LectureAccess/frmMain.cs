using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using ADOX;

namespace LectureAccess
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Nom de la base de données (champs privé).
        /// </summary>

        private string dbName = string.Empty;

        /// <summary>
        /// Nom de la base de données.
        /// </summary>

        public string DbName
        {
            get { return dbName; }
            set { dbName = value; }
        }

        /// <summary>
        /// Constructeur.
        /// </summary>

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>

        private void Go()
        {
            txtErr.Text = string.Empty;

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbName + ";User Id=admin;Password=;");
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand(txtQuery.Text, con);
                DataTable data = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                adapter.Fill(data);

                dgvResults.DataSource = data;
            }
            catch (Exception ex)
            {
                txtErr.Text = ex.Message;
            }

            try
            {
                con.Close();
            }
            catch
            {

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dgvResults.AutoGenerateColumns = true;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dbName = ofd.FileName;
                Go();

                Catalog cat = new Catalog();
                cat.let_ActiveConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbName + ";User Id=admin;Password=;");

                cbxTableList.Items.Clear();
                foreach (Table tbl in cat.Tables)
                    cbxTableList.Items.Add(tbl.Name);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Go();
        }

        private void btnKeys_Click(object sender, EventArgs e)
        {
            Catalog cat = new Catalog();
            cat.let_ActiveConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbName + ";User Id=admin;Password=;");
            try
            {
                DataTable tblData = new DataTable();
                tblData.Columns.Add("Table");
                tblData.Columns.Add("Key");

                foreach (Table data in cat.Tables)
                {
                    foreach (Key dataKey in data.Keys)
                        tblData.Rows.Add(data.Name, dataKey.Name);
                }

                dgvResults.DataSource = tblData;
            }
            catch (Exception ex)
            {
                txtErr.Text = ex.Message;
            }
        }

        private void btnRelations_Click(object sender, EventArgs e)
        {
            txtErr.Text = string.Empty;

            Catalog cat = new Catalog();
            cat.let_ActiveConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbName + ";User Id=admin;Password=;");

            DataTable tblData = new DataTable();
            tblData.Columns.Add("Table");
            tblData.Columns.Add("Key");
            tblData.Columns.Add("RelatedTable");
            tblData.Columns.Add("Column");

            foreach (Table data in cat.Tables)
            {
                foreach (Key dataKey in data.Keys)
                {
                    DataRow tblDataRow = tblData.Rows.Add(data.Name, dataKey.Name, dataKey.RelatedTable);
                    string cols = string.Empty;
                    try
                    {
                        foreach (Column dataKeyColumn in dataKey.Columns)
                            cols += dataKeyColumn.Name + " ";
                    }
                    catch
                    {

                    }

                    tblDataRow["Column"] = cols;
                }
            }

            dgvResults.DataSource = tblData;
        }

        private void btnIndexes_Click(object sender, EventArgs e)
        {
            txtErr.Text = string.Empty;

            Catalog cat = new Catalog();
            cat.let_ActiveConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbName + ";User Id=admin;Password=;");

            DataTable tblData = new DataTable();
            tblData.Columns.Add("Table");
            tblData.Columns.Add("Index");
            tblData.Columns.Add("Column");

            foreach (Table data in cat.Tables)
            {
                foreach (Index dataIndex in data.Indexes)
                {
                    DataRow tblDataRow = tblData.Rows.Add(data.Name, dataIndex.Name);
                    string cols = string.Empty;
                    try
                    {
                        foreach (Column dataKeyColumn in dataIndex.Columns)
                            cols += dataKeyColumn.Name + " ";
                    }
                    catch
                    {

                    }

                    tblDataRow["Column"] = cols;
                }
            }

            dgvResults.DataSource = tblData;
        }

        private void cbxTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuery.Text = @"SELECT  *
FROM    " + cbxTableList.SelectedItem.ToString();
            Go();
        }
    }
}