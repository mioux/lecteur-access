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
        /// Nom de la base de données (champs privé).
        /// </summary>

        private string _dbName = string.Empty;
        private const string _conStringTemplate = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User Id=admin;Password=;";
        private string _conString = string.Empty;

        /// <summary>
        /// Nom de la base de données.
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
        /// Lancer une requête.
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

                txtErr.Text = string.Format("{0} lignes retournées", data.Rows.Count);
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
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Aucun argument.</param>

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenBase();
        }

        /// <summary>
        /// Ouverture d'une BDD.
        /// </summary>

        private void OpenBase()
        {
            dgvResults.AutoGenerateColumns = true;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                OpenDB(ofd.FileName);
        }

        /// <summary>
        /// Exécuter une requête.
        /// </summary>
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Aucun argument.</param>

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Go();
        }

        /// <summary>
        /// Table des clefs.
        /// </summary>
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Aucun argument.</param>

        private void btnKeys_Click(object sender, EventArgs e)
        {
            ViewKeys();
        }

        /// <summary>
        /// Affichage de la table des clefs.
        /// </summary>

        private void ViewKeys()
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
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Aucun argument.</param>

        private void btnRelations_Click(object sender, EventArgs e)
        {
            ViewRelations();
        }

        /// <summary>
        /// Affichage de la table des relations.
        /// </summary>

        private void ViewRelations()
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
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Aucun argument.</param>

        private void btnIndexes_Click(object sender, EventArgs e)
        {
            ViewIndexes();
        }

        /// <summary>
        /// Affichage de la table des index.
        /// </summary>

        private void ViewIndexes()
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
        /// Sélection des données d'une table depuis le combobox.
        /// </summary>
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Aucun argument.</param>

        private void cbxTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuery.Text = string.Format(@"SELECT  *
FROM    [{0}]", cbxTableList.SelectedItem.ToString());
            Go();
        }

        /// <summary>
        /// Drop d'un élément sur la fenêtre.
        /// </summary>
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Argument de drag&drop.</param>

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length == 1 && File.Exists(files[0]))
                OpenDB(files[0]);
            else if (files.Length > 1)
                MessageBox.Show("Un seul fichier à la fois s'il vous plait.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Effets du Drag&Drop.
        /// </summary>
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Argument de drag&drop.</param>

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
        /// <param name="dbName">Fichier à ouvrir.</param>

        public void OpenDB(string dbName)
        {
            DbName = dbName;

            Go();

            Catalog cat = new Catalog();
            cat.let_ActiveConnection(_conString);

            cbxTableList.Items.Clear();
            foreach (Table tbl in cat.Tables)
                cbxTableList.Items.Add(tbl.Name);
        }

        /// <summary>
        /// Raccourcis clavier.
        /// </summary>
        /// <param name="sender">Elément déclencheur.</param>
        /// <param name="e">Argument de la touche pressée.</param>

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            // C-e ou F5 => Exécuter.
            if (e.KeyData == (System.Windows.Forms.Keys.E | System.Windows.Forms.Keys.Control)
                ||
                e.KeyData == System.Windows.Forms.Keys.F5)
            {
                Go();
            }

            // C-o => Ouvrir.
            if (e.KeyData == (System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Control))
                OpenBase();

            // C-k => Affichage des clefs.
            if (e.KeyData == (System.Windows.Forms.Keys.K | System.Windows.Forms.Keys.Control))
                ViewKeys();

            // C-i => Affichage des index.
            if (e.KeyData == (System.Windows.Forms.Keys.I | System.Windows.Forms.Keys.Control))
                ViewIndexes();

            // C-r => Affichage des relations.
            if (e.KeyData == (System.Windows.Forms.Keys.R | System.Windows.Forms.Keys.Control))
                ViewRelations();
        }
    }
}