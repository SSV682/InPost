namespace Входящие.Forms
{
    partial class AddValueDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddValueDictionary));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.te_prefix = new DevExpress.XtraEditors.TextEdit();
            this.te_index = new DevExpress.XtraEditors.TextEdit();
            this.te_value = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_prefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_index.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_value.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_cancel);
            this.layoutControl1.Controls.Add(this.btn_Ok);
            this.layoutControl1.Controls.Add(this.te_prefix);
            this.layoutControl1.Controls.Add(this.te_index);
            this.layoutControl1.Controls.Add(this.te_value);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(799, 145);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.Image")));
            this.btn_cancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(401, 104);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(396, 38);
            this.btn_cancel.StyleController = this.layoutControl1;
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "simpleButton2";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.Image")));
            this.btn_Ok.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Ok.Location = new System.Drawing.Point(2, 104);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(395, 38);
            this.btn_Ok.StyleController = this.layoutControl1;
            this.btn_Ok.TabIndex = 7;
            this.btn_Ok.Text = "simpleButton1";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // te_prefix
            // 
            this.te_prefix.Location = new System.Drawing.Point(74, 70);
            this.te_prefix.Name = "te_prefix";
            this.te_prefix.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.te_prefix.Properties.Appearance.Options.UseFont = true;
            this.te_prefix.Size = new System.Drawing.Size(723, 30);
            this.te_prefix.StyleController = this.layoutControl1;
            this.te_prefix.TabIndex = 6;
            // 
            // te_index
            // 
            this.te_index.Location = new System.Drawing.Point(74, 36);
            this.te_index.Name = "te_index";
            this.te_index.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.te_index.Properties.Appearance.Options.UseFont = true;
            this.te_index.Size = new System.Drawing.Size(723, 30);
            this.te_index.StyleController = this.layoutControl1;
            this.te_index.TabIndex = 5;
            // 
            // te_value
            // 
            this.te_value.Location = new System.Drawing.Point(74, 2);
            this.te_value.Name = "te_value";
            this.te_value.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.te_value.Properties.Appearance.Options.UseFont = true;
            this.te_value.Size = new System.Drawing.Size(723, 30);
            this.te_value.StyleController = this.layoutControl1;
            this.te_value.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(799, 145);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.te_value;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(799, 34);
            this.layoutControlItem1.Text = "Значение";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.te_index;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(799, 34);
            this.layoutControlItem2.Text = "Индекс";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(69, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.te_prefix;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(799, 34);
            this.layoutControlItem3.Text = "Префикс";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(69, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btn_Ok;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 102);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(399, 43);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_cancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(399, 102);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(400, 43);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // AddValueDictionary
            // 
            this.AcceptButton = this.btn_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(799, 145);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AddValueDictionary";
            this.Text = "AddValueDictionary";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te_prefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_index.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_value.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.TextEdit te_prefix;
        private DevExpress.XtraEditors.TextEdit te_index;
        private DevExpress.XtraEditors.TextEdit te_value;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;

    }
}