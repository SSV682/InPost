namespace Входящие.InControls
{
    partial class EditorOfDictionaries
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
            this.xtc = new DevExpress.XtraTab.XtraTabControl();
            this.xtp_executor = new DevExpress.XtraTab.XtraTabPage();
            this.grid_executor = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colИсполнитель = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtp_from = new DevExpress.XtraTab.XtraTabPage();
            this.grid_from = new DevExpress.XtraGrid.GridControl();
            this.подразделенияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colНазваниеПодразделения = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colИндекс = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПрефикс = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtb_where = new DevExpress.XtraTab.XtraTabPage();
            this.grid_where = new DevExpress.XtraGrid.GridControl();
            this.комуАдресованBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colКомуАдресован1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtp_view = new DevExpress.XtraTab.XtraTabPage();
            this.grid_view = new DevExpress.XtraGrid.GridControl();
            this.видДокументаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colВид = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtc)).BeginInit();
            this.xtc.SuspendLayout();
            this.xtp_executor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_executor)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.исполнителиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.xtp_from.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.подразделенияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtb_where.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_where)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.комуАдресованBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtp_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.видДокументаBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // xtc
            // 
            this.xtc.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.xtc.Appearance.Options.UseFont = true;
            this.xtc.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 12F);
            this.xtc.AppearancePage.Header.Options.UseFont = true;
            this.xtc.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.xtc.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtc.Location = new System.Drawing.Point(0, 0);
            this.xtc.Name = "xtc";
            this.xtc.SelectedTabPage = this.xtp_from;
            this.xtc.Size = new System.Drawing.Size(1105, 871);
            this.xtc.TabIndex = 0;
            this.xtc.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtp_from,
            this.xtb_where,
            this.xtp_view,
            this.xtp_executor});
            // 
            // xtp_executor
            // 
            this.xtp_executor.Controls.Add(this.grid_executor);
            this.xtp_executor.Name = "xtp_executor";
            this.xtp_executor.Size = new System.Drawing.Size(1099, 837);
            this.xtp_executor.Text = "Исполнители";
            // 
            // grid_executor
            // 
            this.grid_executor.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_executor.DataSource = this.исполнителиBindingSource;
            this.grid_executor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_executor.Location = new System.Drawing.Point(0, 0);
            this.grid_executor.MainView = this.gridView4;
            this.grid_executor.Name = "grid_executor";
            this.grid_executor.Size = new System.Drawing.Size(1099, 837);
            this.grid_executor.TabIndex = 0;
            this.grid_executor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.обновитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 70);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // исполнителиBindingSource
            // 
            this.исполнителиBindingSource.DataSource = typeof(Data.Исполнители);
            // 
            // gridView4
            // 
            this.gridView4.ColumnPanelRowHeight = 50;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colИсполнитель});
            this.gridView4.GridControl = this.grid_executor;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsView.ShowDetailButtons = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            this.gridView4.RowHeight = 30;
            // 
            // colИсполнитель
            // 
            this.colИсполнитель.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colИсполнитель.AppearanceCell.Options.UseFont = true;
            this.colИсполнитель.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colИсполнитель.AppearanceHeader.Options.UseFont = true;
            this.colИсполнитель.FieldName = "Исполнитель";
            this.colИсполнитель.Name = "colИсполнитель";
            this.colИсполнитель.OptionsColumn.AllowMove = false;
            this.colИсполнитель.Visible = true;
            this.colИсполнитель.VisibleIndex = 0;
            // 
            // xtp_from
            // 
            this.xtp_from.Controls.Add(this.grid_from);
            this.xtp_from.Name = "xtp_from";
            this.xtp_from.Size = new System.Drawing.Size(1099, 837);
            this.xtp_from.Text = "Откуда поступил";
            // 
            // grid_from
            // 
            this.grid_from.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_from.DataSource = this.подразделенияBindingSource;
            this.grid_from.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_from.Location = new System.Drawing.Point(0, 0);
            this.grid_from.MainView = this.gridView1;
            this.grid_from.Name = "grid_from";
            this.grid_from.Size = new System.Drawing.Size(1099, 837);
            this.grid_from.TabIndex = 0;
            this.grid_from.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // подразделенияBindingSource
            // 
            this.подразделенияBindingSource.DataSource = typeof(Data.Подразделения);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 50;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colНазваниеПодразделения,
            this.colИндекс,
            this.colПрефикс});
            this.gridView1.GridControl = this.grid_from;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 30;
            // 
            // colНазваниеПодразделения
            // 
            this.colНазваниеПодразделения.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colНазваниеПодразделения.AppearanceCell.Options.UseFont = true;
            this.colНазваниеПодразделения.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colНазваниеПодразделения.AppearanceHeader.Options.UseFont = true;
            this.colНазваниеПодразделения.FieldName = "НазваниеПодразделения";
            this.colНазваниеПодразделения.Name = "colНазваниеПодразделения";
            this.colНазваниеПодразделения.OptionsColumn.AllowMove = false;
            this.colНазваниеПодразделения.Visible = true;
            this.colНазваниеПодразделения.VisibleIndex = 0;
            // 
            // colИндекс
            // 
            this.colИндекс.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colИндекс.AppearanceCell.Options.UseFont = true;
            this.colИндекс.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colИндекс.AppearanceHeader.Options.UseFont = true;
            this.colИндекс.FieldName = "Индекс";
            this.colИндекс.Name = "colИндекс";
            this.colИндекс.OptionsColumn.AllowMove = false;
            this.colИндекс.Visible = true;
            this.colИндекс.VisibleIndex = 1;
            // 
            // colПрефикс
            // 
            this.colПрефикс.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colПрефикс.AppearanceCell.Options.UseFont = true;
            this.colПрефикс.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colПрефикс.AppearanceHeader.Options.UseFont = true;
            this.colПрефикс.FieldName = "Префикс";
            this.colПрефикс.Name = "colПрефикс";
            this.colПрефикс.OptionsColumn.AllowMove = false;
            this.colПрефикс.Visible = true;
            this.colПрефикс.VisibleIndex = 2;
            // 
            // xtb_where
            // 
            this.xtb_where.Controls.Add(this.grid_where);
            this.xtb_where.Name = "xtb_where";
            this.xtb_where.Size = new System.Drawing.Size(1099, 837);
            this.xtb_where.Text = "Кому адресован";
            // 
            // grid_where
            // 
            this.grid_where.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_where.DataSource = this.комуАдресованBindingSource;
            this.grid_where.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_where.Location = new System.Drawing.Point(0, 0);
            this.grid_where.MainView = this.gridView2;
            this.grid_where.Name = "grid_where";
            this.grid_where.Size = new System.Drawing.Size(1099, 837);
            this.grid_where.TabIndex = 0;
            this.grid_where.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // комуАдресованBindingSource
            // 
            this.комуАдресованBindingSource.DataSource = typeof(Data.КомуАдресован);
            // 
            // gridView2
            // 
            this.gridView2.ColumnPanelRowHeight = 50;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colКомуАдресован1});
            this.gridView2.GridControl = this.grid_where;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsView.ShowDetailButtons = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.RowHeight = 30;
            // 
            // colКомуАдресован1
            // 
            this.colКомуАдресован1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colКомуАдресован1.AppearanceCell.Options.UseFont = true;
            this.colКомуАдресован1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colКомуАдресован1.AppearanceHeader.Options.UseFont = true;
            this.colКомуАдресован1.Caption = "Кому адресован";
            this.colКомуАдресован1.FieldName = "КомуАдресован1";
            this.colКомуАдресован1.Name = "colКомуАдресован1";
            this.colКомуАдресован1.OptionsColumn.AllowMove = false;
            this.colКомуАдресован1.Visible = true;
            this.colКомуАдресован1.VisibleIndex = 0;
            // 
            // xtp_view
            // 
            this.xtp_view.Controls.Add(this.grid_view);
            this.xtp_view.Name = "xtp_view";
            this.xtp_view.Size = new System.Drawing.Size(1099, 837);
            this.xtp_view.Text = "Вид документа";
            // 
            // grid_view
            // 
            this.grid_view.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_view.DataSource = this.видДокументаBindingSource;
            this.grid_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_view.Location = new System.Drawing.Point(0, 0);
            this.grid_view.MainView = this.gridView3;
            this.grid_view.Name = "grid_view";
            this.grid_view.Size = new System.Drawing.Size(1099, 837);
            this.grid_view.TabIndex = 0;
            this.grid_view.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // видДокументаBindingSource
            // 
            this.видДокументаBindingSource.DataSource = typeof(Data.ВидДокумента);
            // 
            // gridView3
            // 
            this.gridView3.ColumnPanelRowHeight = 50;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colВид});
            this.gridView3.GridControl = this.grid_view;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsView.ShowDetailButtons = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            this.gridView3.RowHeight = 30;
            // 
            // colВид
            // 
            this.colВид.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colВид.AppearanceCell.Options.UseFont = true;
            this.colВид.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colВид.AppearanceHeader.Options.UseFont = true;
            this.colВид.FieldName = "Вид";
            this.colВид.Name = "colВид";
            this.colВид.OptionsColumn.AllowMove = false;
            this.colВид.Visible = true;
            this.colВид.VisibleIndex = 0;
            // 
            // EditorOfDictionaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtc);
            this.Name = "EditorOfDictionaries";
            this.Size = new System.Drawing.Size(1105, 871);
            ((System.ComponentModel.ISupportInitialize)(this.xtc)).EndInit();
            this.xtc.ResumeLayout(false);
            this.xtp_executor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_executor)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.исполнителиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.xtp_from.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.подразделенияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtb_where.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_where)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.комуАдресованBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtp_view.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.видДокументаBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtc;
        private DevExpress.XtraTab.XtraTabPage xtp_from;
        private DevExpress.XtraTab.XtraTabPage xtb_where;
        private DevExpress.XtraTab.XtraTabPage xtp_view;
        private DevExpress.XtraGrid.GridControl grid_from;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl grid_where;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl grid_view;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraTab.XtraTabPage xtp_executor;
        private DevExpress.XtraGrid.GridControl grid_executor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.BindingSource подразделенияBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colНазваниеПодразделения;
        private DevExpress.XtraGrid.Columns.GridColumn colИндекс;
        private DevExpress.XtraGrid.Columns.GridColumn colПрефикс;
        private System.Windows.Forms.BindingSource комуАдресованBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colКомуАдресован1;
        private System.Windows.Forms.BindingSource видДокументаBindingSource;
        private System.Windows.Forms.BindingSource исполнителиBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colИсполнитель;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colВид;
    }
}
