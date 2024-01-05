namespace zaiwoneproje
{
    partial class Form15
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form15));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.zaiwoneDataSet = new zaiwoneproje.zaiwoneDataSet();
            this.tShirtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tShirtTableAdapter = new zaiwoneproje.zaiwoneDataSetTableAdapters.TShirtTableAdapter();
            this.colBeden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRenk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTasarim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdeti = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.search = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaiwoneDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShirtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tShirtBindingSource;
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
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBeden,
            this.colRenk,
            this.colTasarim,
            this.colStokAdeti,
            this.colFiyat,
            this.search});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // zaiwoneDataSet
            // 
            this.zaiwoneDataSet.DataSetName = "zaiwoneDataSet";
            this.zaiwoneDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tShirtBindingSource
            // 
            this.tShirtBindingSource.DataMember = "TShirt";
            this.tShirtBindingSource.DataSource = this.zaiwoneDataSet;
            // 
            // tShirtTableAdapter
            // 
            this.tShirtTableAdapter.ClearBeforeFill = true;
            // 
            // colBeden
            // 
            this.colBeden.FieldName = "Beden";
            this.colBeden.MinWidth = 25;
            this.colBeden.Name = "colBeden";
            this.colBeden.Visible = true;
            this.colBeden.VisibleIndex = 0;
            this.colBeden.Width = 94;
            // 
            // colRenk
            // 
            this.colRenk.FieldName = "Renk";
            this.colRenk.MinWidth = 25;
            this.colRenk.Name = "colRenk";
            this.colRenk.Visible = true;
            this.colRenk.VisibleIndex = 1;
            this.colRenk.Width = 94;
            // 
            // colTasarim
            // 
            this.colTasarim.FieldName = "Tasarim";
            this.colTasarim.MinWidth = 25;
            this.colTasarim.Name = "colTasarim";
            this.colTasarim.Visible = true;
            this.colTasarim.VisibleIndex = 2;
            this.colTasarim.Width = 94;
            // 
            // colStokAdeti
            // 
            this.colStokAdeti.FieldName = "StokAdeti";
            this.colStokAdeti.MinWidth = 25;
            this.colStokAdeti.Name = "colStokAdeti";
            this.colStokAdeti.Visible = true;
            this.colStokAdeti.VisibleIndex = 3;
            this.colStokAdeti.Width = 94;
            // 
            // colFiyat
            // 
            this.colFiyat.FieldName = "Fiyat";
            this.colFiyat.MinWidth = 25;
            this.colFiyat.Name = "colFiyat";
            this.colFiyat.Visible = true;
            this.colFiyat.VisibleIndex = 4;
            this.colFiyat.Width = 94;
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
            // search
            // 
            this.search.Caption = "Edit";
            this.search.ColumnEdit = this.repositoryItemButtonEdit1;
            this.search.MinWidth = 25;
            this.search.Name = "search";
            this.search.Visible = true;
            this.search.VisibleIndex = 5;
            this.search.Width = 94;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1613, 42);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(1414, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Ürün Ekle";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(1514, 8);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(94, 29);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Geri";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T Shirt";
            this.Load += new System.EventHandler(this.Form15_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaiwoneDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShirtBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource tShirtBindingSource;
        private zaiwoneDataSetTableAdapters.TShirtTableAdapter tShirtTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colBeden;
        private DevExpress.XtraGrid.Columns.GridColumn colRenk;
        private DevExpress.XtraGrid.Columns.GridColumn colTasarim;
        private DevExpress.XtraGrid.Columns.GridColumn colStokAdeti;
        private DevExpress.XtraGrid.Columns.GridColumn colFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn search;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}