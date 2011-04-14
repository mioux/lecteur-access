using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using ADOX;
using System.IO;

namespace LectureAccess
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Nom de la base de donn�es (champs priv�).
        /// </summary>

        private string _dbName = string.Empty;
        private const string _conStringTemplate = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User Id=admin;Password=;";
        private string _conString = string.Empty;

        /// <summary>
        /// Nom de la base de donn�es.
        /// </summary>

        public string DbName
        {
            get { return _dbName; }
            set
            {
                _dbName = value;
                lblOpenDB.Text = value;
                _conString = string.Format(_conStringTemplate, value);
            }
        }

        /// <summary>
        /// Constructeur.
        /// </summary>

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lancer une requ�te.
        /// </summary>

        private void Go()
        {
            txtErr.Text = string.Empty;

            OleDbConnection con = new OleDbConnection(_conString);
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

        /// <summary>
        /// Bouton ouvrir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dgvResults.AutoGenerateColumns = true;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                OpenDB(ofd.FileName);
        }

        /// <summary>
        /// Ex�cuter une requ�te.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Go();
        }

        /// <summary>
        /// Table des clefs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnKeys_Click(object sender, EventArgs e)
        {
            Catalog cat = new Catalog();
            cat.let_ActiveConnection(_conString);
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

        /// <summary>
        /// Table des relations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnRelations_Click(object sender, EventArgs e)
        {
            txtErr.Text = string.Empty;

            Catalog cat = new Catalog();
            cat.let_ActiveConnection(_conString);

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

        /// <summary>
        /// Table des index.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnIndexes_Click(object sender, EventArgs e)
        {
            txtErr.Text = string.Empty;

            Catalog cat = new Catalog();
            cat.let_ActiveConnection(_conString);

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

        /// <summary>
        /// S�lection des donn�es d'une table depuis le combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cbxTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuery.Text = string.Format(@"SELECT  *
FROM    [{0}]", cbxTableList.SelectedItem.ToString());
            Go();
        }

        /// <summary>
        /// Drop d'un �l�ment sur la fen�tre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length == 1 && File.Exists(files[0]))
                OpenDB(files[0]);
            else if (files.Length > 1)
                MessageBox.Show("Un seul fichier � la fois s'il vous plait.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Effets du Drag&Drop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Ouvrir une BDD
        /// </summary>
        /// <param name="dbName">Fichier � ouvrir.</param>

        private void OpenDB(string dbName)
        {
            DbName = dbName;

            Go();

            Catalog cat = new Catalog();
            cat.let_ActiveConnection(_conString);

            cbxTableList.Items.Clear();
            foreach (Table tbl in cat.Tables)
                cbxTableList.Items.Add(tbl.Name);
        }
    }
}