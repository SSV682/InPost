namespace Входящие.Forms
{
    partial class ChooseDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseDocuments));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.документыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInAct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colГрифы = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colРегНомер = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаПодписи = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colВходящийНомер = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаРегистрации = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПодразделения = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colКомуАдресован = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.документыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.btn_OK);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(773, 544);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.документыBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(769, 498);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // документыBindingSource
            // 
            this.документыBindingSource.DataSource = typeof(Data.Документы);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInAct,
            this.colГрифы,
            this.colРегНомер,
            this.colДатаПодписи,
            this.colВходящийНомер,
            this.colДатаРегистрации,
            this.colПодразделения,
            this.colКомуАдресован});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 30;
            // 
            // colInAct
            // 
            this.colInAct.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colInAct.AppearanceCell.Options.UseFont = true;
            this.colInAct.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colInAct.AppearanceHeader.Options.UseFont = true;
            this.colInAct.Caption = "Выбрать";
            this.colInAct.FieldName = "InAct";
            this.colInAct.Name = "colInAct";
            this.colInAct.Visible = true;
            this.colInAct.VisibleIndex = 0;
            // 
            // colГрифы
            // 
            this.colГрифы.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colГрифы.AppearanceCell.Options.UseFont = true;
            this.colГрифы.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colГрифы.AppearanceHeader.Options.UseFont = true;
            this.colГрифы.FieldName = "Грифы";
            this.colГрифы.Name = "colГрифы";
            this.colГрифы.OptionsColumn.AllowEdit = false;
            this.colГрифы.Visible = true;
            this.colГрифы.VisibleIndex = 1;
            // 
            // colРегНомер
            // 
            this.colРегНомер.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colРегНомер.AppearanceCell.Options.UseFont = true;
            this.colРегНомер.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colРегНомер.AppearanceHeader.Options.UseFont = true;
            this.colРегНомер.FieldName = "РегНомер";
            this.colРегНомер.Name = "colРегНомер";
            this.colРегНомер.OptionsColumn.AllowEdit = false;
            this.colРегНомер.Visible = true;
            this.colРегНомер.VisibleIndex = 2;
            // 
            // colДатаПодписи
            // 
            this.colДатаПодписи.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colДатаПодписи.AppearanceCell.Options.UseFont = true;
            this.colДатаПодписи.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colДатаПодписи.AppearanceHeader.Options.UseFont = true;
            this.colДатаПодписи.FieldName = "ДатаПодписи";
            this.colДатаПодписи.Name = "colДатаПодписи";
            this.colДатаПодписи.OptionsColumn.AllowEdit = false;
            this.colДатаПодписи.Visible = true;
            this.colДатаПодписи.VisibleIndex = 3;
            // 
            // colВходящийНомер
            // 
            this.colВходящийНомер.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colВходящийНомер.AppearanceCell.Options.UseFont = true;
            this.colВходящийНомер.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colВходящийНомер.AppearanceHeader.Options.UseFont = true;
            this.colВходящийНомер.FieldName = "ВходящийНомер";
            this.colВходящийНомер.Name = "colВходящийНомер";
            this.colВходящийНомер.OptionsColumn.AllowEdit = false;
            this.colВходящийНомер.Visible = true;
            this.colВходящийНомер.VisibleIndex = 4;
            // 
            // colДатаРегистрации
            // 
            this.colДатаРегистрации.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colДатаРегистрации.AppearanceCell.Options.UseFont = true;
            this.colДатаРегистрации.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colДатаРегистрации.AppearanceHeader.Options.UseFont = true;
            this.colДатаРегистрации.FieldName = "ДатаРегистрации";
            this.colДатаРегистрации.Name = "colДатаРегистрации";
            this.colДатаРегистрации.OptionsColumn.AllowEdit = false;
            this.colДатаРегистрации.Visible = true;
            this.colДатаРегистрации.VisibleIndex = 5;
            // 
            // colПодразделения
            // 
            this.colПодразделения.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colПодразделения.AppearanceCell.Options.UseFont = true;
            this.colПодразделения.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colПодразделения.AppearanceHeader.Options.UseFont = true;
            this.colПодразделения.FieldName = "Подразделения";
            this.colПодразделения.Name = "colПодразделения";
            this.colПодразделения.OptionsColumn.AllowEdit = false;
            this.colПодразделения.Visible = true;
            this.colПодразделения.VisibleIndex = 6;
            // 
            // colКомуАдресован
            // 
            this.colКомуАдресован.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colКомуАдресован.AppearanceCell.Options.UseFont = true;
            this.colКомуАдресован.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colКомуАдресован.AppearanceHeader.Options.UseFont = true;
            this.colКомуАдресован.FieldName = "КомуАдресован";
            this.colКомуАдресован.Name = "colКомуАдресован";
            this.colКомуАдресован.OptionsColumn.AllowEdit = false;
            this.colКомуАдресован.Visible = true;
            this.colКомуАдресован.VisibleIndex = 7;
            // 
            // btn_OK
            // 
            this.btn_OK.Image = ((System.Drawing.Image)(resources.GetObject("btn_OK.Image")));
            this.btn_OK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_OK.Location = new System.Drawing.Point(2, 504);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(769, 38);
            this.btn_OK.StyleController = this.layoutControl1;
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "simpleButton1";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(773, 544);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_OK;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 502);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(773, 42);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(773, 502);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ChooseDocuments
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 544);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ChooseDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseDocuments";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.документыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource документыBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colInAct;
        private DevExpress.XtraGrid.Columns.GridColumn colГрифы;
        private DevExpress.XtraGrid.Columns.GridColumn colРегНомер;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаПодписи;
        private DevExpress.XtraGrid.Columns.GridColumn colВходящийНомер;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаРегистрации;
        private DevExpress.XtraGrid.Columns.GridColumn colПодразделения;
        private DevExpress.XtraGrid.Columns.GridColumn colКомуАдресован;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}