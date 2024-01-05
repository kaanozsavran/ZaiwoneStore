namespace zaiwoneproje
{
    partial class Form24
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form24));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.satislarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zaiwoneDataSet = new zaiwoneproje.zaiwoneDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMusteriID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKupaBardakID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTShirtID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonKilifID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMousePadID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSweatShirtID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToplamFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.search = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.satislarTableAdapter = new zaiwoneproje.zaiwoneDataSetTableAdapters.SatislarTableAdapter();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satislarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaiwoneDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.satislarBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1924, 1055);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // satislarBindingSource
            // 
            this.satislarBindingSource.DataMember = "Satislar";
            this.satislarBindingSource.DataSource = this.zaiwoneDataSet;
            // 
            // zaiwoneDataSet
            // 
            this.zaiwoneDataSet.DataSetName = "zaiwoneDataSet";
            this.zaiwoneDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMusteriID,
            this.colKupaBardakID,
            this.colTShirtID,
            this.colTelefonKilifID,
            this.colMousePadID,
            this.colSweatShirtID,
            this.colMiktar,
            this.colToplamFiyat,
            this.colTarih,
            this.search});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colMusteriID
            // 
            this.colMusteriID.FieldName = "MusteriID";
            this.colMusteriID.MinWidth = 25;
            this.colMusteriID.Name = "colMusteriID";
            this.colMusteriID.Visible = true;
            this.colMusteriID.VisibleIndex = 0;
            this.colMusteriID.Width = 94;
            // 
            // colKupaBardakID
            // 
            this.colKupaBardakID.FieldName = "KupaBardakID";
            this.colKupaBardakID.MinWidth = 25;
            this.colKupaBardakID.Name = "colKupaBardakID";
            this.colKupaBardakID.Visible = true;
            this.colKupaBardakID.VisibleIndex = 1;
            this.colKupaBardakID.Width = 94;
            // 
            // colTShirtID
            // 
            this.colTShirtID.FieldName = "TShirtID";
            this.colTShirtID.MinWidth = 25;
            this.colTShirtID.Name = "colTShirtID";
            this.colTShirtID.Visible = true;
            this.colTShirtID.VisibleIndex = 2;
            this.colTShirtID.Width = 94;
            // 
            // colTelefonKilifID
            // 
            this.colTelefonKilifID.FieldName = "TelefonKilifID";
            this.colTelefonKilifID.MinWidth = 25;
            this.colTelefonKilifID.Name = "colTelefonKilifID";
            this.colTelefonKilifID.Visible = true;
            this.colTelefonKilifID.VisibleIndex = 3;
            this.colTelefonKilifID.Width = 94;
            // 
            // colMousePadID
            // 
            this.colMousePadID.FieldName = "MousePadID";
            this.colMousePadID.MinWidth = 25;
            this.colMousePadID.Name = "colMousePadID";
            this.colMousePadID.Visible = true;
            this.colMousePadID.VisibleIndex = 4;
            this.colMousePadID.Width = 94;
            // 
            // colSweatShirtID
            // 
            this.colSweatShirtID.FieldName = "SweatShirtID";
            this.colSweatShirtID.MinWidth = 25;
            this.colSweatShirtID.Name = "colSweatShirtID";
            this.colSweatShirtID.Visible = true;
            this.colSweatShirtID.VisibleIndex = 5;
            this.colSweatShirtID.Width = 94;
            // 
            // colMiktar
            // 
            this.colMiktar.FieldName = "Miktar";
            this.colMiktar.MinWidth = 25;
            this.colMiktar.Name = "colMiktar";
            this.colMiktar.Visible = true;
            this.colMiktar.VisibleIndex = 6;
            this.colMiktar.Width = 94;
            // 
            // colToplamFiyat
            // 
            this.colToplamFiyat.FieldName = "ToplamFiyat";
            this.colToplamFiyat.MinWidth = 25;
            this.colToplamFiyat.Name = "colToplamFiyat";
            this.colToplamFiyat.Visible = true;
            this.colToplamFiyat.VisibleIndex = 7;
            this.colToplamFiyat.Width = 94;
            // 
            // colTarih
            // 
            this.colTarih.FieldName = "Tarih";
            this.colTarih.MinWidth = 25;
            this.colTarih.Name = "colTarih";
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 8;
            this.colTarih.Width = 94;
            // 
            // search
            // 
            this.search.Caption = "Edit";
            this.search.ColumnEdit = this.repositoryItemButtonEdit1;
            this.search.MinWidth = 25;
            this.search.Name = "search";
            this.search.Visible = true;
            this.search.VisibleIndex = 9;
            this.search.Width = 94;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.Click += new System.EventHandler(this.repositoryItemButtonEdit1_Click);
            // 
            // satislarTableAdapter
            // 
            this.satislarTableAdapter.ClearBeforeFill = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1744, 40);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(1645, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(94, 29);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Geri";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(1545, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Satış Ekle";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form24
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form24";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satışlar";
            this.Load += new System.EventHandler(this.Form24_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satislarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaiwoneDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private zaiwoneDataSet zaiwoneDataSet;
        private System.Windows.Forms.BindingSource satislarBindingSource;
        private zaiwoneDataSetTableAdapters.SatislarTableAdapter satislarTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriID;
        private DevExpress.XtraGrid.Columns.GridColumn colKupaBardakID;
        private DevExpress.XtraGrid.Columns.GridColumn colTShirtID;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonKilifID;
        private DevExpress.XtraGrid.Columns.GridColumn colMousePadID;
        private DevExpress.XtraGrid.Columns.GridColumn colSweatShirtID;
        private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colToplamFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colTarih;
        private DevExpress.XtraGrid.Columns.GridColumn search;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}