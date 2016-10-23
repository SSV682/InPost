namespace Входящие.Forms
{
    partial class ReRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReRegistration));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.te_Year = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbi_createNewDoc = new DevExpress.XtraBars.BarButtonItem();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.grid_docs = new DevExpress.XtraGrid.GridControl();
            this.документыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colГрифы = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colРегНомер = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаПодписи = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПолныйВходящийНомер = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаРегистрации = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПодразделения = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colКомуАдресован = new DevExpress.XtraGrid.Columns.GridColumn();
            this.te_IncNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_Year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_docs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.документыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_IncNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.te_Year);
            this.layoutControl1.Controls.Add(this.btn_OK);
            this.layoutControl1.Controls.Add(this.grid_docs);
            this.layoutControl1.Controls.Add(this.te_IncNumber);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(859, 501);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // te_Year
            // 
            this.te_Year.Location = new System.Drawing.Point(709, 2);
            this.te_Year.MenuManager = this.barManager1;
            this.te_Year.Name = "te_Year";
            this.te_Year.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.te_Year.Properties.Appearance.Options.UseFont = true;
            this.te_Year.Size = new System.Drawing.Size(148, 26);
            this.te_Year.StyleController = this.layoutControl1;
            this.te_Year.TabIndex = 7;
            this.te_Year.EditValueChanged += new System.EventHandler(this.te_Year_EditValueChanged);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbi_createNewDoc});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(859, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 501);
            this.barDockControlBottom.Size = new System.Drawing.Size(859, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 501);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(859, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 501);
            // 
            // bbi_createNewDoc
            // 
            this.bbi_createNewDoc.Caption = "Cоздать новый документ";
            this.bbi_createNewDoc.Glyph = ((System.Drawing.Image)(resources.GetObject("bbi_createNewDoc.Glyph")));
            this.bbi_createNewDoc.Id = 0;
            this.bbi_createNewDoc.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F);
            this.bbi_createNewDoc.ItemAppearance.Normal.Options.UseFont = true;
            this.bbi_createNewDoc.Name = "bbi_createNewDoc";
            this.bbi_createNewDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_createNewDoc_ItemClick);
            // 
            // btn_OK
            // 
            this.btn_OK.Image = ((System.Drawing.Image)(resources.GetObject("btn_OK.Image")));
            this.btn_OK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_OK.Location = new System.Drawing.Point(2, 461);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(855, 38);
            this.btn_OK.StyleController = this.layoutControl1;
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "simpleButton1";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // grid_docs
            // 
            this.grid_docs.DataSource = this.документыBindingSource;
            this.grid_docs.Location = new System.Drawing.Point(2, 32);
            this.grid_docs.MainView = this.gridView1;
            this.grid_docs.MenuManager = this.barManager1;
            this.grid_docs.Name = "grid_docs";
            this.grid_docs.Size = new System.Drawing.Size(855, 425);
            this.grid_docs.TabIndex = 5;
            this.grid_docs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid_docs.DoubleClick += new System.EventHandler(this.grid_docs_DoubleClick);
            // 
            // документыBindingSource
            // 
            this.документыBindingSource.DataSource = typeof(Data.Документы);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colГрифы,
            this.colРегНомер,
            this.colДатаПодписи,
            this.colПолныйВходящийНомер,
            this.colДатаРегистрации,
            this.colПодразделения,
            this.colКомуАдресован});
            this.gridView1.GridControl = this.grid_docs;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colГрифы
            // 
            this.colГрифы.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colГрифы.AppearanceCell.Options.UseFont = true;
            this.colГрифы.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colГрифы.AppearanceHeader.Options.UseFont = true;
            this.colГрифы.FieldName = "Грифы";
            this.colГрифы.Name = "colГрифы";
            this.colГрифы.Visible = true;
            this.colГрифы.VisibleIndex = 0;
            // 
            // colРегНомер
            // 
            this.colРегНомер.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colРегНомер.AppearanceCell.Options.UseFont = true;
            this.colРегНомер.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colРегНомер.AppearanceHeader.Options.UseFont = true;
            this.colРегНомер.FieldName = "РегНомер";
            this.colРегНомер.Name = "colРегНомер";
            this.colРегНомер.Visible = true;
            this.colРегНомер.VisibleIndex = 1;
            // 
            // colДатаПодписи
            // 
            this.colДатаПодписи.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colДатаПодписи.AppearanceCell.Options.UseFont = true;
            this.colДатаПодписи.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colДатаПодписи.AppearanceHeader.Options.UseFont = true;
            this.colДатаПодписи.FieldName = "ДатаПодписи";
            this.colДатаПодписи.Name = "colДатаПодписи";
            this.colДатаПодписи.Visible = true;
            this.colДатаПодписи.VisibleIndex = 2;
            // 
            // colПолныйВходящийНомер
            // 
            this.colПолныйВходящийНомер.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colПолныйВходящийНомер.AppearanceCell.Options.UseFont = true;
            this.colПолныйВходящийНомер.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colПолныйВходящийНомер.AppearanceHeader.Options.UseFont = true;
            this.colПолныйВходящийНомер.FieldName = "ПолныйВходящийНомер";
            this.colПолныйВходящийНомер.Name = "colПолныйВходящийНомер";
            this.colПолныйВходящийНомер.Visible = true;
            this.colПолныйВходящийНомер.VisibleIndex = 3;
            // 
            // colДатаРегистрации
            // 
            this.colДатаРегистрации.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colДатаРегистрации.AppearanceCell.Options.UseFont = true;
            this.colДатаРегистрации.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colДатаРегистрации.AppearanceHeader.Options.UseFont = true;
            this.colДатаРегистрации.FieldName = "ДатаРегистрации";
            this.colДатаРегистрации.Name = "colДатаРегистрации";
            this.colДатаРегистрации.Visible = true;
            this.colДатаРегистрации.VisibleIndex = 4;
            // 
            // colПодразделения
            // 
            this.colПодразделения.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colПодразделения.AppearanceCell.Options.UseFont = true;
            this.colПодразделения.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colПодразделения.AppearanceHeader.Options.UseFont = true;
            this.colПодразделения.Caption = "Откуда";
            this.colПодразделения.FieldName = "Подразделения";
            this.colПодразделения.Name = "colПодразделения";
            this.colПодразделения.Visible = true;
            this.colПодразделения.VisibleIndex = 5;
            // 
            // colКомуАдресован
            // 
            this.colКомуАдресован.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colКомуАдресован.AppearanceCell.Options.UseFont = true;
            this.colКомуАдресован.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colКомуАдресован.AppearanceHeader.Options.UseFont = true;
            this.colКомуАдресован.Caption = "Кому";
            this.colКомуАдресован.FieldName = "КомуАдресован";
            this.colКомуАдресован.Name = "colКомуАдресован";
            this.colКомуАдресован.Visible = true;
            this.colКомуАдресован.VisibleIndex = 6;
            // 
            // te_IncNumber
            // 
            this.te_IncNumber.Location = new System.Drawing.Point(152, 2);
            this.te_IncNumber.MenuManager = this.barManager1;
            this.te_IncNumber.Name = "te_IncNumber";
            this.te_IncNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.te_IncNumber.Properties.Appearance.Options.UseFont = true;
            this.te_IncNumber.Size = new System.Drawing.Size(518, 26);
            this.te_IncNumber.StyleController = this.layoutControl1;
            this.te_IncNumber.TabIndex = 4;
            this.te_IncNumber.EditValueChanged += new System.EventHandler(this.te_IncNumber_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(859, 501);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.te_IncNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(672, 30);
            this.layoutControlItem1.Text = "Входящий номер";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(145, 19);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grid_docs;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(859, 429);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_OK;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 459);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(859, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.te_Year;
            this.layoutControlItem4.Location = new System.Drawing.Point(672, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(187, 30);
            this.layoutControlItem4.Text = "Год";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(30, 19);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // ReRegistration
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 501);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReRegistration";
            this.ShowIcon = false;
            this.Text = "Перерегистрация";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te_Year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_docs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.документыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_IncNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem bbi_createNewDoc;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraGrid.GridControl grid_docs;
        private System.Windows.Forms.BindingSource документыBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colГрифы;
        private DevExpress.XtraGrid.Columns.GridColumn colРегНомер;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаПодписи;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаРегистрации;
        private DevExpress.XtraGrid.Columns.GridColumn colПодразделения;
        private DevExpress.XtraGrid.Columns.GridColumn colКомуАдресован;
        private DevExpress.XtraEditors.TextEdit te_IncNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit te_Year;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colПолныйВходящийНомер;
    }
}