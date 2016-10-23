namespace Входящие.InControls
{
    partial class ReturnedDocuments
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grid_DocsControl = new DevExpress.XtraGrid.GridControl();
            this.документыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colГрифы = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПолныйРегистрационныйНомер = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаПодписи = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПолныйВходящийНомер = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаРегистрации = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПодразделения = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colКомуАдресован = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeстоположение = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаВозврата = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаКонтроля = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbe_TypeControl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_DocsControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.документыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_TypeControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grid_DocsControl);
            this.layoutControl1.Controls.Add(this.cbe_TypeControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(863, 631);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grid_DocsControl
            // 
            this.grid_DocsControl.DataSource = this.документыBindingSource;
            this.grid_DocsControl.Location = new System.Drawing.Point(2, 36);
            this.grid_DocsControl.MainView = this.gridView1;
            this.grid_DocsControl.Name = "grid_DocsControl";
            this.grid_DocsControl.Size = new System.Drawing.Size(859, 593);
            this.grid_DocsControl.TabIndex = 5;
            this.grid_DocsControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid_DocsControl.Load += new System.EventHandler(this.grid_DocsControl_Load);
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
            this.colПолныйРегистрационныйНомер,
            this.colДатаПодписи,
            this.colПолныйВходящийНомер,
            this.colДатаРегистрации,
            this.colПодразделения,
            this.colКомуАдресован,
            this.colMeстоположение,
            this.colДатаВозврата,
            this.colДатаКонтроля});
            this.gridView1.GridControl = this.grid_DocsControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colДатаВозврата, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colДатаКонтроля, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.gridView1_ColumnWidthChanged);
            // 
            // colГрифы
            // 
            this.colГрифы.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colГрифы.AppearanceCell.Options.UseFont = true;
            this.colГрифы.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colГрифы.AppearanceHeader.Options.UseFont = true;
            this.colГрифы.FieldName = "Грифы";
            this.colГрифы.Name = "colГрифы";
            this.colГрифы.Visible = true;
            this.colГрифы.VisibleIndex = 0;
            // 
            // colПолныйРегистрационныйНомер
            // 
            this.colПолныйРегистрационныйНомер.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colПолныйРегистрационныйНомер.AppearanceCell.Options.UseFont = true;
            this.colПолныйРегистрационныйНомер.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colПолныйРегистрационныйНомер.AppearanceHeader.Options.UseFont = true;
            this.colПолныйРегистрационныйНомер.Caption = "Рег Номер";
            this.colПолныйРегистрационныйНомер.FieldName = "ПолныйРегистрационныйНомер";
            this.colПолныйРегистрационныйНомер.Name = "colПолныйРегистрационныйНомер";
            this.colПолныйРегистрационныйНомер.Visible = true;
            this.colПолныйРегистрационныйНомер.VisibleIndex = 1;
            // 
            // colДатаПодписи
            // 
            this.colДатаПодписи.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colДатаПодписи.AppearanceCell.Options.UseFont = true;
            this.colДатаПодписи.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colДатаПодписи.AppearanceHeader.Options.UseFont = true;
            this.colДатаПодписи.FieldName = "ДатаПодписи";
            this.colДатаПодписи.Name = "colДатаПодписи";
            this.colДатаПодписи.Visible = true;
            this.colДатаПодписи.VisibleIndex = 2;
            // 
            // colПолныйВходящийНомер
            // 
            this.colПолныйВходящийНомер.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colПолныйВходящийНомер.AppearanceCell.Options.UseFont = true;
            this.colПолныйВходящийНомер.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colПолныйВходящийНомер.AppearanceHeader.Options.UseFont = true;
            this.colПолныйВходящийНомер.Caption = "Входящий номер";
            this.colПолныйВходящийНомер.FieldName = "ПолныйВходящийНомер";
            this.colПолныйВходящийНомер.Name = "colПолныйВходящийНомер";
            this.colПолныйВходящийНомер.Visible = true;
            this.colПолныйВходящийНомер.VisibleIndex = 3;
            // 
            // colДатаРегистрации
            // 
            this.colДатаРегистрации.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colДатаРегистрации.AppearanceCell.Options.UseFont = true;
            this.colДатаРегистрации.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colДатаРегистрации.AppearanceHeader.Options.UseFont = true;
            this.colДатаРегистрации.FieldName = "ДатаРегистрации";
            this.colДатаРегистрации.Name = "colДатаРегистрации";
            this.colДатаРегистрации.Visible = true;
            this.colДатаРегистрации.VisibleIndex = 4;
            // 
            // colПодразделения
            // 
            this.colПодразделения.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colПодразделения.AppearanceCell.Options.UseFont = true;
            this.colПодразделения.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colПодразделения.AppearanceHeader.Options.UseFont = true;
            this.colПодразделения.FieldName = "Подразделения";
            this.colПодразделения.Name = "colПодразделения";
            this.colПодразделения.Visible = true;
            this.colПодразделения.VisibleIndex = 5;
            // 
            // colКомуАдресован
            // 
            this.colКомуАдресован.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colКомуАдресован.AppearanceCell.Options.UseFont = true;
            this.colКомуАдресован.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colКомуАдресован.AppearanceHeader.Options.UseFont = true;
            this.colКомуАдресован.FieldName = "КомуАдресован";
            this.colКомуАдресован.Name = "colКомуАдресован";
            this.colКомуАдресован.Visible = true;
            this.colКомуАдресован.VisibleIndex = 6;
            // 
            // colMeстоположение
            // 
            this.colMeстоположение.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colMeстоположение.AppearanceCell.Options.UseFont = true;
            this.colMeстоположение.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colMeстоположение.AppearanceHeader.Options.UseFont = true;
            this.colMeстоположение.FieldName = "Meстоположение";
            this.colMeстоположение.Name = "colMeстоположение";
            this.colMeстоположение.Visible = true;
            this.colMeстоположение.VisibleIndex = 7;
            // 
            // colДатаВозврата
            // 
            this.colДатаВозврата.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colДатаВозврата.AppearanceCell.Options.UseFont = true;
            this.colДатаВозврата.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colДатаВозврата.AppearanceHeader.Options.UseFont = true;
            this.colДатаВозврата.FieldName = "ДатаВозврата";
            this.colДатаВозврата.Name = "colДатаВозврата";
            this.colДатаВозврата.Visible = true;
            this.colДатаВозврата.VisibleIndex = 8;
            // 
            // colДатаКонтроля
            // 
            this.colДатаКонтроля.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colДатаКонтроля.AppearanceCell.Options.UseFont = true;
            this.colДатаКонтроля.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colДатаКонтроля.AppearanceHeader.Options.UseFont = true;
            this.colДатаКонтроля.FieldName = "ДатаКонтроля";
            this.colДатаКонтроля.Name = "colДатаКонтроля";
            this.colДатаКонтроля.Visible = true;
            this.colДатаКонтроля.VisibleIndex = 9;
            // 
            // cbe_TypeControl
            // 
            this.cbe_TypeControl.Location = new System.Drawing.Point(125, 2);
            this.cbe_TypeControl.Name = "cbe_TypeControl";
            this.cbe_TypeControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.cbe_TypeControl.Properties.Appearance.Options.UseFont = true;
            this.cbe_TypeControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbe_TypeControl.Properties.Items.AddRange(new object[] {
            "по дате контроля",
            "по дате возврата"});
            this.cbe_TypeControl.Size = new System.Drawing.Size(736, 30);
            this.cbe_TypeControl.StyleController = this.layoutControl1;
            this.cbe_TypeControl.TabIndex = 4;
            this.cbe_TypeControl.EditValueChanged += new System.EventHandler(this.cbe_TypeControl_EditValueChanged);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(863, 631);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.cbe_TypeControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(863, 34);
            this.layoutControlItem1.Text = "Тип контроля";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(120, 23);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grid_DocsControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(863, 597);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ReturnedDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ReturnedDocuments";
            this.Size = new System.Drawing.Size(863, 631);
            this.Load += new System.EventHandler(this.ReturnedDocuments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_DocsControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.документыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_TypeControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grid_DocsControl;
        private System.Windows.Forms.BindingSource документыBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colГрифы;
        private DevExpress.XtraGrid.Columns.GridColumn colПолныйРегистрационныйНомер;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаПодписи;
        private DevExpress.XtraEditors.ComboBoxEdit cbe_TypeControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colПолныйВходящийНомер;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаРегистрации;
        private DevExpress.XtraGrid.Columns.GridColumn colПодразделения;
        private DevExpress.XtraGrid.Columns.GridColumn colКомуАдресован;
        private DevExpress.XtraGrid.Columns.GridColumn colMeстоположение;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаВозврата;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаКонтроля;
    }
}
