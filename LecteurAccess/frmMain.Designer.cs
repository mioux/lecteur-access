namespace LectureAccess
{
    partial class frmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnKeys = new System.Windows.Forms.Button();
            this.btnRelations = new System.Windows.Forms.Button();
            this.btnIndexes = new System.Windows.Forms.Button();
            this.txtErr = new System.Windows.Forms.TextBox();
            this.cbxTableList = new System.Windows.Forms.ComboBox();
            this.lblOpenDB = new System.Windows.Forms.Label();
            this.sptQueryData = new System.Windows.Forms.SplitContainer();
            this.sptDataErr = new System.Windows.Forms.SplitContainer();
            this.btnCompression = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.sptQueryData.Panel1.SuspendLayout();
            this.sptQueryData.Panel2.SuspendLayout();
            this.sptQueryData.SuspendLayout();
            this.sptDataErr.Panel1.SuspendLayout();
            this.sptDataErr.Panel2.SuspendLayout();
            this.sptDataErr.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToOrderColumns = true;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(615, 210);
            this.dgvResults.TabIndex = 0;
            this.dgvResults.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvResults_CellFormatting);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "&Ouvrir";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.Location = new System.Drawing.Point(84, 3);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuery.Size = new System.Drawing.Size(528, 110);
            this.txtQuery.TabIndex = 2;
            this.txtQuery.Text = "SELECT 1 AS DATA";
            this.txtQuery.WordWrap = false;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(3, 32);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "&Exécuter";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnKeys
            // 
            this.btnKeys.Location = new System.Drawing.Point(3, 61);
            this.btnKeys.Name = "btnKeys";
            this.btnKeys.Size = new System.Drawing.Size(75, 23);
            this.btnKeys.TabIndex = 4;
            this.btnKeys.Text = "Clefs (&K)";
            this.btnKeys.UseVisualStyleBackColor = true;
            this.btnKeys.Click += new System.EventHandler(this.btnKeys_Click);
            // 
            // btnRelations
            // 
            this.btnRelations.Location = new System.Drawing.Point(3, 90);
            this.btnRelations.Name = "btnRelations";
            this.btnRelations.Size = new System.Drawing.Size(75, 23);
            this.btnRelations.TabIndex = 5;
            this.btnRelations.Text = "&Relations";
            this.btnRelations.UseVisualStyleBackColor = true;
            this.btnRelations.Click += new System.EventHandler(this.btnRelations_Click);
            // 
            // btnIndexes
            // 
            this.btnIndexes.Location = new System.Drawing.Point(3, 119);
            this.btnIndexes.Name = "btnIndexes";
            this.btnIndexes.Size = new System.Drawing.Size(75, 23);
            this.btnIndexes.TabIndex = 6;
            this.btnIndexes.Text = "&Index";
            this.btnIndexes.UseVisualStyleBackColor = true;
            this.btnIndexes.Click += new System.EventHandler(this.btnIndexes_Click);
            // 
            // txtErr
            // 
            this.txtErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErr.Location = new System.Drawing.Point(0, 0);
            this.txtErr.Multiline = true;
            this.txtErr.Name = "txtErr";
            this.txtErr.ReadOnly = true;
            this.txtErr.Size = new System.Drawing.Size(615, 130);
            this.txtErr.TabIndex = 7;
            // 
            // cbxTableList
            // 
            this.cbxTableList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTableList.FormattingEnabled = true;
            this.cbxTableList.Location = new System.Drawing.Point(3, 149);
            this.cbxTableList.Name = "cbxTableList";
            this.cbxTableList.Size = new System.Drawing.Size(609, 21);
            this.cbxTableList.TabIndex = 8;
            this.cbxTableList.SelectedIndexChanged += new System.EventHandler(this.cbxTableList_SelectedIndexChanged);
            // 
            // lblOpenDB
            // 
            this.lblOpenDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOpenDB.AutoSize = true;
            this.lblOpenDB.Location = new System.Drawing.Point(84, 124);
            this.lblOpenDB.Name = "lblOpenDB";
            this.lblOpenDB.Size = new System.Drawing.Size(171, 13);
            this.lblOpenDB.TabIndex = 9;
            this.lblOpenDB.Text = "Aucune base de données ouverte.";
            // 
            // sptQueryData
            // 
            this.sptQueryData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptQueryData.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptQueryData.Location = new System.Drawing.Point(0, 0);
            this.sptQueryData.Name = "sptQueryData";
            this.sptQueryData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptQueryData.Panel1
            // 
            this.sptQueryData.Panel1.Controls.Add(this.btnCompression);
            this.sptQueryData.Panel1.Controls.Add(this.btnOpen);
            this.sptQueryData.Panel1.Controls.Add(this.cbxTableList);
            this.sptQueryData.Panel1.Controls.Add(this.lblOpenDB);
            this.sptQueryData.Panel1.Controls.Add(this.btnExecute);
            this.sptQueryData.Panel1.Controls.Add(this.btnKeys);
            this.sptQueryData.Panel1.Controls.Add(this.btnRelations);
            this.sptQueryData.Panel1.Controls.Add(this.txtQuery);
            this.sptQueryData.Panel1.Controls.Add(this.btnIndexes);
            this.sptQueryData.Panel1MinSize = 175;
            // 
            // sptQueryData.Panel2
            // 
            this.sptQueryData.Panel2.Controls.Add(this.sptDataErr);
            this.sptQueryData.Size = new System.Drawing.Size(615, 523);
            this.sptQueryData.SplitterDistance = 175;
            this.sptQueryData.TabIndex = 10;
            // 
            // sptDataErr
            // 
            this.sptDataErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptDataErr.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sptDataErr.Location = new System.Drawing.Point(0, 0);
            this.sptDataErr.Name = "sptDataErr";
            this.sptDataErr.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptDataErr.Panel1
            // 
            this.sptDataErr.Panel1.Controls.Add(this.dgvResults);
            // 
            // sptDataErr.Panel2
            // 
            this.sptDataErr.Panel2.Controls.Add(this.txtErr);
            this.sptDataErr.Size = new System.Drawing.Size(615, 344);
            this.sptDataErr.SplitterDistance = 210;
            this.sptDataErr.TabIndex = 1;
            // 
            // btnCompression
            // 
            this.btnCompression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompression.Location = new System.Drawing.Point(528, 119);
            this.btnCompression.Name = "btnCompression";
            this.btnCompression.Size = new System.Drawing.Size(75, 23);
            this.btnCompression.TabIndex = 10;
            this.btnCompression.Text = "Compresser";
            this.btnCompression.UseVisualStyleBackColor = true;
            this.btnCompression.Click += new System.EventHandler(this.btnCompression_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 523);
            this.Controls.Add(this.sptQueryData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "frmMain";
            this.Text = "Lecture de base Access";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.sptQueryData.Panel1.ResumeLayout(false);
            this.sptQueryData.Panel1.PerformLayout();
            this.sptQueryData.Panel2.ResumeLayout(false);
            this.sptQueryData.ResumeLayout(false);
            this.sptDataErr.Panel1.ResumeLayout(false);
            this.sptDataErr.Panel2.ResumeLayout(false);
            this.sptDataErr.Panel2.PerformLayout();
            this.sptDataErr.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnKeys;
        private System.Windows.Forms.Button btnRelations;
        private System.Windows.Forms.Button btnIndexes;
        private System.Windows.Forms.TextBox txtErr;
        private System.Windows.Forms.ComboBox cbxTableList;
        private System.Windows.Forms.Label lblOpenDB;
        private System.Windows.Forms.SplitContainer sptQueryData;
        private System.Windows.Forms.SplitContainer sptDataErr;
        private System.Windows.Forms.Button btnCompression;
    }
}

