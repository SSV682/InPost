namespace Входящие.InControls
{
    partial class Destiny
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
            this.grid_destiny = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.журналОперацийBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colКомментарий = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_destiny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.журналОперацийBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_destiny
            // 
            this.grid_destiny.DataSource = this.журналОперацийBindingSource;
            this.grid_destiny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_destiny.Location = new System.Drawing.Point(0, 0);
            this.grid_destiny.MainView = this.gridView1;
            this.grid_destiny.Name = "grid_destiny";
            this.grid_destiny.Size = new System.Drawing.Size(355, 393);
            this.grid_destiny.TabIndex = 0;
            this.grid_destiny.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colКомментарий});
            this.gridView1.GridControl = this.grid_destiny;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 30;
            // 
            // журналОперацийBindingSource
            // 
            this.журналОперацийBindingSource.DataSource = typeof(Data.ЖурналОпераций);
            // 
            // colКомментарий
            // 
            this.colКомментарий.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colКомментарий.AppearanceCell.Options.UseFont = true;
            this.colКомментарий.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.colКомментарий.AppearanceHeader.Options.UseFont = true;
            this.colКомментарий.FieldName = "Комментарий";
            this.colКомментарий.Name = "colКомментарий";
            this.colКомментарий.Visible = true;
            this.colКомментарий.VisibleIndex = 0;
            // 
            // destiny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid_destiny);
            this.Name = "destiny";
            this.Size = new System.Drawing.Size(355, 393);
            ((System.ComponentModel.ISupportInitialize)(this.grid_destiny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.журналОперацийBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_destiny;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource журналОперацийBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colКомментарий;
    }
}
