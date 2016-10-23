namespace MyStart.Формы
{
    partial class ИнформацияОПечати
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ИнформацияОПечати));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.журналПечатиКарточекBindingSource = new System.Windows.Forms.BindingSource();
            this.inPostDataSet = new MyStart.InPostDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colДатаПечати = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПользователь = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДействие = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.журналПечатиКарточекTableAdapter = new MyStart.InPostDataSetTableAdapters.ЖурналПечатиКарточекTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.журналПечатиКарточекBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inPostDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(667, 359);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.журналПечатиКарточекBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(663, 355);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // журналПечатиКарточекBindingSource
            // 
            this.журналПечатиКарточекBindingSource.DataMember = "ЖурналПечатиКарточек";
            this.журналПечатиКарточекBindingSource.DataSource = this.inPostDataSet;
            // 
            // inPostDataSet
            // 
            this.inPostDataSet.DataSetName = "InPostDataSet";
            this.inPostDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colДатаПечати,
            this.colПользователь,
            this.colДействие});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colДатаПечати
            // 
            this.colДатаПечати.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colДатаПечати.AppearanceCell.Options.UseFont = true;
            this.colДатаПечати.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colДатаПечати.AppearanceHeader.Options.UseFont = true;
            this.colДатаПечати.AppearanceHeader.Options.UseForeColor = true;
            this.colДатаПечати.FieldName = "ДатаПечати";
            this.colДатаПечати.Name = "colДатаПечати";
            this.colДатаПечати.OptionsColumn.AllowEdit = false;
            this.colДатаПечати.Visible = true;
            this.colДатаПечати.VisibleIndex = 0;
            // 
            // colПользователь
            // 
            this.colПользователь.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colПользователь.AppearanceCell.Options.UseFont = true;
            this.colПользователь.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colПользователь.AppearanceHeader.Options.UseFont = true;
            this.colПользователь.FieldName = "Пользователь";
            this.colПользователь.Name = "colПользователь";
            this.colПользователь.OptionsColumn.AllowEdit = false;
            this.colПользователь.Visible = true;
            this.colПользователь.VisibleIndex = 1;
            // 
            // colДействие
            // 
            this.colДействие.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.colДействие.AppearanceCell.Options.UseFont = true;
            this.colДействие.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colДействие.AppearanceHeader.Options.UseFont = true;
            this.colДействие.FieldName = "Действие";
            this.colДействие.Name = "colДействие";
            this.colДействие.OptionsColumn.AllowEdit = false;
            this.colДействие.Visible = true;
            this.colДействие.VisibleIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(667, 359);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(667, 359);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // журналПечатиКарточекTableAdapter
            // 
            this.журналПечатиКарточекTableAdapter.ClearBeforeFill = true;
            // 
            // ИнформацияОПечати
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 359);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ИнформацияОПечати";
            this.Text = "ИнформацияОПечати";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.журналПечатиКарточекBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inPostDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаПечати;
        private DevExpress.XtraGrid.Columns.GridColumn colПользователь;
        private InPostDataSet inPostDataSet;
        private System.Windows.Forms.BindingSource журналПечатиКарточекBindingSource;
        private InPostDataSetTableAdapters.ЖурналПечатиКарточекTableAdapter журналПечатиКарточекTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colДействие;
    }
}