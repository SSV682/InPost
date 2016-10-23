namespace Входящие.InControls
{
    partial class Act
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Act));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbi_createDocument = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_actPerformed = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_printToCheck = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_editor = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.grid_ActsDoc = new DevExpress.XtraGrid.GridControl();
            this.документыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colГрифы = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colРегНомер = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colВходящийНомер = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colДатаРегистрации = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colНазваниеДокумента = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colПодразделения = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colКомуАдресован = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ActsDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.документыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbi_createDocument,
            this.bbi_actPerformed,
            this.bbi_printToCheck,
            this.bbi_editor});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_createDocument, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_actPerformed, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_printToCheck, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_editor, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbi_createDocument
            // 
            this.bbi_createDocument.Caption = "Создать документ";
            this.bbi_createDocument.Glyph = ((System.Drawing.Image)(resources.GetObject("bbi_createDocument.Glyph")));
            this.bbi_createDocument.Id = 0;
            this.bbi_createDocument.Name = "bbi_createDocument";
            this.bbi_createDocument.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_createDocument_ItemClick);
            // 
            // bbi_actPerformed
            // 
            this.bbi_actPerformed.Caption = "Акт исполнен";
            this.bbi_actPerformed.Glyph = ((System.Drawing.Image)(resources.GetObject("bbi_actPerformed.Glyph")));
            this.bbi_actPerformed.Id = 1;
            this.bbi_actPerformed.Name = "bbi_actPerformed";
            this.bbi_actPerformed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_actPerformed_ItemClick);
            // 
            // bbi_printToCheck
            // 
            this.bbi_printToCheck.Caption = "Печать для проверки";
            this.bbi_printToCheck.Glyph = ((System.Drawing.Image)(resources.GetObject("bbi_printToCheck.Glyph")));
            this.bbi_printToCheck.Id = 2;
            this.bbi_printToCheck.Name = "bbi_printToCheck";
            this.bbi_printToCheck.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbi_printToCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_printToCheck_ItemClick);
            // 
            // bbi_editor
            // 
            this.bbi_editor.Caption = "Редактор";
            this.bbi_editor.Glyph = ((System.Drawing.Image)(resources.GetObject("bbi_editor.Glyph")));
            this.bbi_editor.Id = 3;
            this.bbi_editor.Name = "bbi_editor";
            this.bbi_editor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_editor_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1018, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 738);
            this.barDockControlBottom.Size = new System.Drawing.Size(1018, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 698);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1018, 40);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 698);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_Delete);
            this.layoutControl1.Controls.Add(this.btn_Add);
            this.layoutControl1.Controls.Add(this.grid_ActsDoc);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 40);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1018, 698);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Delete.Location = new System.Drawing.Point(511, 658);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(505, 38);
            this.btn_Delete.StyleController = this.layoutControl1;
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.Text = "simpleButton2";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Add.Location = new System.Drawing.Point(2, 658);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(505, 38);
            this.btn_Add.StyleController = this.layoutControl1;
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "simpleButton1";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // grid_ActsDoc
            // 
            this.grid_ActsDoc.DataSource = this.документыBindingSource;
            this.grid_ActsDoc.Location = new System.Drawing.Point(2, 2);
            this.grid_ActsDoc.MainView = this.gridView1;
            this.grid_ActsDoc.MenuManager = this.barManager1;
            this.grid_ActsDoc.Name = "grid_ActsDoc";
            this.grid_ActsDoc.Size = new System.Drawing.Size(1014, 652);
            this.grid_ActsDoc.TabIndex = 4;
            this.grid_ActsDoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid_ActsDoc.Load += new System.EventHandler(this.grid_ActsDoc_Load);
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
            this.colВходящийНомер,
            this.colДатаРегистрации,
            this.colНазваниеДокумента,
            this.colПодразделения,
            this.colКомуАдресован});
            this.gridView1.GridControl = this.grid_ActsDoc;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 30;
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
            // colРегНомер
            // 
            this.colРегНомер.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colРегНомер.AppearanceCell.Options.UseFont = true;
            this.colРегНомер.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colРегНомер.AppearanceHeader.Options.UseFont = true;
            this.colРегНомер.FieldName = "РегНомер";
            this.colРегНомер.Name = "colРегНомер";
            this.colРегНомер.Visible = true;
            this.colРегНомер.VisibleIndex = 1;
            // 
            // colВходящийНомер
            // 
            this.colВходящийНомер.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colВходящийНомер.AppearanceCell.Options.UseFont = true;
            this.colВходящийНомер.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colВходящийНомер.AppearanceHeader.Options.UseFont = true;
            this.colВходящийНомер.FieldName = "ВходящийНомер";
            this.colВходящийНомер.Name = "colВходящийНомер";
            this.colВходящийНомер.Visible = true;
            this.colВходящийНомер.VisibleIndex = 2;
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
            this.colДатаРегистрации.VisibleIndex = 3;
            // 
            // colНазваниеДокумента
            // 
            this.colНазваниеДокумента.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14F);
            this.colНазваниеДокумента.AppearanceCell.Options.UseFont = true;
            this.colНазваниеДокумента.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.colНазваниеДокумента.AppearanceHeader.Options.UseFont = true;
            this.colНазваниеДокумента.FieldName = "НазваниеДокумента";
            this.colНазваниеДокумента.Name = "colНазваниеДокумента";
            this.colНазваниеДокумента.Visible = true;
            this.colНазваниеДокумента.VisibleIndex = 4;
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
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1018, 698);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grid_ActsDoc;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1018, 656);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Add;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 656);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(509, 42);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_Delete;
            this.layoutControlItem3.Location = new System.Drawing.Point(509, 656);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(509, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // Act
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Act";
            this.Size = new System.Drawing.Size(1018, 738);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_ActsDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.документыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbi_createDocument;
        private DevExpress.XtraBars.BarButtonItem bbi_actPerformed;
        private DevExpress.XtraBars.BarButtonItem bbi_printToCheck;
        private DevExpress.XtraBars.BarButtonItem bbi_editor;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraGrid.GridControl grid_ActsDoc;
        private System.Windows.Forms.BindingSource документыBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colГрифы;
        private DevExpress.XtraGrid.Columns.GridColumn colРегНомер;
        private DevExpress.XtraGrid.Columns.GridColumn colВходящийНомер;
        private DevExpress.XtraGrid.Columns.GridColumn colДатаРегистрации;
        private DevExpress.XtraGrid.Columns.GridColumn colНазваниеДокумента;
        private DevExpress.XtraGrid.Columns.GridColumn colПодразделения;
        private DevExpress.XtraGrid.Columns.GridColumn colКомуАдресован;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
