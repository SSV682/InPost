namespace АдминистрированиеВходящих
{
    partial class ОкноАдминистратора
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.nbg_option = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbg_administration = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbi_Roles = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.panelAdmin = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.navBarControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelAdmin);
            this.splitContainer1.Size = new System.Drawing.Size(936, 719);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.nbg_option;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbg_administration,
            this.nbg_option});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbi_Roles,
            this.navBarItem2,
            this.navBarItem3,
            this.navBarItem4,
            this.navBarItem5});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 312;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControl1.Size = new System.Drawing.Size(312, 719);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("VS2010");
            // 
            // nbg_option
            // 
            this.nbg_option.Caption = "Дополнительные функции";
            this.nbg_option.Expanded = true;
            this.nbg_option.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4)});
            this.nbg_option.Name = "nbg_option";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "Редактирование словарей";
            this.navBarItem5.Name = "navBarItem5";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "Выход";
            this.navBarItem4.Name = "navBarItem4";
            // 
            // nbg_administration
            // 
            this.nbg_administration.Caption = "Функции администрирование";
            this.nbg_administration.Expanded = true;
            this.nbg_administration.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_Roles),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3)});
            this.nbg_administration.Name = "nbg_administration";
            // 
            // nbi_Roles
            // 
            this.nbi_Roles.Caption = "Настройка ролей";
            this.nbi_Roles.Name = "nbi_Roles";
            this.nbi_Roles.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_Roles_LinkClicked);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Настройка подразделений";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Настройка полномочий пользователя";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // panelAdmin
            // 
            this.panelAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdmin.Location = new System.Drawing.Point(0, 0);
            this.panelAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(620, 719);
            this.panelAdmin.TabIndex = 0;
            // 
            // ОкноАдминистратора
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 719);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ОкноАдминистратора";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ОкноАдминистратора";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup nbg_administration;
        private DevExpress.XtraNavBar.NavBarGroup nbg_option;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem nbi_Roles;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private System.Windows.Forms.Panel panelAdmin;
    }
}