namespace Входящие
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.nb_working_with_logs = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_open_journal = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_working_with_act = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_create_act = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_edit_act = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_view_act = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_editor = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_reports = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_print_journal = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_function = new DevExpress.XtraNavBar.NavBarGroup();
            this.nb_edit_dictionary = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_uploaded_documents = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_returned_documents = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_clodsed_documents = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_settings = new DevExpress.XtraNavBar.NavBarItem();
            this.nb_exit = new DevExpress.XtraNavBar.NavBarItem();
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.panelMain);
            this.splitContainer1.Size = new System.Drawing.Size(914, 545);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.nb_working_with_logs;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nb_working_with_logs,
            this.nb_working_with_act,
            this.nb_reports,
            this.nb_function});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nb_open_journal,
            this.nb_create_act,
            this.nb_edit_act,
            this.nb_view_act,
            this.nb_editor,
            this.nb_print_journal,
            this.nb_edit_dictionary,
            this.nb_uploaded_documents,
            this.nb_clodsed_documents,
            this.nb_settings,
            this.nb_exit,
            this.nb_returned_documents});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 222;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControl1.Size = new System.Drawing.Size(222, 545);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("VS2010");
            // 
            // nb_working_with_logs
            // 
            this.nb_working_with_logs.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.nb_working_with_logs.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_working_with_logs.Appearance.Options.UseFont = true;
            this.nb_working_with_logs.Caption = "Работа с журналами";
            this.nb_working_with_logs.Expanded = true;
            this.nb_working_with_logs.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_open_journal)});
            this.nb_working_with_logs.Name = "nb_working_with_logs";
            this.nb_working_with_logs.SmallImage = ((System.Drawing.Image)(resources.GetObject("nb_working_with_logs.SmallImage")));
            // 
            // nb_open_journal
            // 
            this.nb_open_journal.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_open_journal.Appearance.Options.UseFont = true;
            this.nb_open_journal.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_open_journal.AppearanceHotTracked.Options.UseFont = true;
            this.nb_open_journal.Caption = "Открыть журнал";
            this.nb_open_journal.Name = "nb_open_journal";
            this.nb_open_journal.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_open_journal_LinkClicked);
            // 
            // nb_working_with_act
            // 
            this.nb_working_with_act.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.nb_working_with_act.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_working_with_act.Appearance.Options.UseFont = true;
            this.nb_working_with_act.Caption = "Работа с актами";
            this.nb_working_with_act.Expanded = true;
            this.nb_working_with_act.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_create_act),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_edit_act),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_view_act),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_editor)});
            this.nb_working_with_act.Name = "nb_working_with_act";
            this.nb_working_with_act.SmallImage = ((System.Drawing.Image)(resources.GetObject("nb_working_with_act.SmallImage")));
            // 
            // nb_create_act
            // 
            this.nb_create_act.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_create_act.Appearance.Options.UseFont = true;
            this.nb_create_act.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_create_act.AppearanceHotTracked.Options.UseFont = true;
            this.nb_create_act.Caption = "Создать акт";
            this.nb_create_act.Name = "nb_create_act";
            this.nb_create_act.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_create_act_LinkClicked);
            // 
            // nb_edit_act
            // 
            this.nb_edit_act.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_edit_act.Appearance.Options.UseFont = true;
            this.nb_edit_act.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_edit_act.AppearanceHotTracked.Options.UseFont = true;
            this.nb_edit_act.Caption = "Редактировать акт";
            this.nb_edit_act.Name = "nb_edit_act";
            this.nb_edit_act.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_edit_act_LinkClicked);
            // 
            // nb_view_act
            // 
            this.nb_view_act.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_view_act.Appearance.Options.UseFont = true;
            this.nb_view_act.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_view_act.AppearanceHotTracked.Options.UseFont = true;
            this.nb_view_act.Caption = "Просмотреть акт";
            this.nb_view_act.Name = "nb_view_act";
            this.nb_view_act.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_view_act_LinkClicked);
            // 
            // nb_editor
            // 
            this.nb_editor.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_editor.Appearance.Options.UseFont = true;
            this.nb_editor.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_editor.AppearanceHotTracked.Options.UseFont = true;
            this.nb_editor.Caption = "Редактор";
            this.nb_editor.Name = "nb_editor";
            // 
            // nb_reports
            // 
            this.nb_reports.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.nb_reports.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_reports.Appearance.Options.UseFont = true;
            this.nb_reports.Caption = "Отчеты";
            this.nb_reports.Expanded = true;
            this.nb_reports.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_print_journal)});
            this.nb_reports.Name = "nb_reports";
            this.nb_reports.SmallImage = ((System.Drawing.Image)(resources.GetObject("nb_reports.SmallImage")));
            // 
            // nb_print_journal
            // 
            this.nb_print_journal.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_print_journal.Appearance.Options.UseFont = true;
            this.nb_print_journal.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_print_journal.AppearanceHotTracked.Options.UseFont = true;
            this.nb_print_journal.Caption = "Печать журнала";
            this.nb_print_journal.Name = "nb_print_journal";
            this.nb_print_journal.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_print_journal_LinkClicked);
            // 
            // nb_function
            // 
            this.nb_function.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.nb_function.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nb_function.Appearance.Options.UseFont = true;
            this.nb_function.Caption = "Дополнительные функции";
            this.nb_function.Expanded = true;
            this.nb_function.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_edit_dictionary),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_uploaded_documents),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_returned_documents),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_clodsed_documents),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_settings),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nb_exit)});
            this.nb_function.Name = "nb_function";
            this.nb_function.SmallImage = ((System.Drawing.Image)(resources.GetObject("nb_function.SmallImage")));
            // 
            // nb_edit_dictionary
            // 
            this.nb_edit_dictionary.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_edit_dictionary.Appearance.Options.UseFont = true;
            this.nb_edit_dictionary.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_edit_dictionary.AppearanceHotTracked.Options.UseFont = true;
            this.nb_edit_dictionary.Caption = "Редактирование словарей";
            this.nb_edit_dictionary.Name = "nb_edit_dictionary";
            this.nb_edit_dictionary.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_edit_dictionary_LinkClicked);
            // 
            // nb_uploaded_documents
            // 
            this.nb_uploaded_documents.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_uploaded_documents.Appearance.Options.UseFont = true;
            this.nb_uploaded_documents.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_uploaded_documents.AppearanceHotTracked.Options.UseFont = true;
            this.nb_uploaded_documents.Caption = "Переданные документы";
            this.nb_uploaded_documents.Name = "nb_uploaded_documents";
            this.nb_uploaded_documents.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_uploaded_documents_LinkClicked);
            // 
            // nb_returned_documents
            // 
            this.nb_returned_documents.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F);
            this.nb_returned_documents.Appearance.Options.UseFont = true;
            this.nb_returned_documents.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold);
            this.nb_returned_documents.AppearanceHotTracked.Options.UseFont = true;
            this.nb_returned_documents.Caption = "Контроль документов";
            this.nb_returned_documents.Name = "nb_returned_documents";
            this.nb_returned_documents.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_returned_documents_LinkClicked);
            // 
            // nb_clodsed_documents
            // 
            this.nb_clodsed_documents.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_clodsed_documents.Appearance.Options.UseFont = true;
            this.nb_clodsed_documents.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_clodsed_documents.AppearanceHotTracked.Options.UseFont = true;
            this.nb_clodsed_documents.Caption = "Закрытые документы";
            this.nb_clodsed_documents.Name = "nb_clodsed_documents";
            this.nb_clodsed_documents.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_clodsed_documents_LinkClicked);
            // 
            // nb_settings
            // 
            this.nb_settings.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_settings.Appearance.Options.UseFont = true;
            this.nb_settings.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_settings.AppearanceHotTracked.Options.UseFont = true;
            this.nb_settings.Caption = "Настройки";
            this.nb_settings.Name = "nb_settings";
            this.nb_settings.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_settings_LinkClicked);
            // 
            // nb_exit
            // 
            this.nb_exit.Appearance.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_exit.Appearance.Options.UseFont = true;
            this.nb_exit.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nb_exit.AppearanceHotTracked.Options.UseFont = true;
            this.nb_exit.Caption = "Выход";
            this.nb_exit.Name = "nb_exit";
            this.nb_exit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nb_exit_LinkClicked);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(688, 545);
            this.panelMain.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 545);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Входящие";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup nb_working_with_logs;
        private DevExpress.XtraNavBar.NavBarItem nb_open_journal;
        private DevExpress.XtraNavBar.NavBarGroup nb_working_with_act;
        private DevExpress.XtraNavBar.NavBarGroup nb_reports;
        private DevExpress.XtraNavBar.NavBarGroup nb_function;
        private DevExpress.XtraNavBar.NavBarItem nb_create_act;
        private DevExpress.XtraNavBar.NavBarItem nb_edit_act;
        private DevExpress.XtraNavBar.NavBarItem nb_view_act;
        private DevExpress.XtraNavBar.NavBarItem nb_editor;
        private DevExpress.XtraNavBar.NavBarItem nb_edit_dictionary;
        private DevExpress.XtraNavBar.NavBarItem nb_uploaded_documents;
        private DevExpress.XtraNavBar.NavBarItem nb_clodsed_documents;
        private DevExpress.XtraNavBar.NavBarItem nb_settings;
        private DevExpress.XtraNavBar.NavBarItem nb_exit;
        private DevExpress.XtraNavBar.NavBarItem nb_print_journal;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraNavBar.NavBarItem nb_returned_documents;
    }
}