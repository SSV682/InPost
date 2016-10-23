using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Data;
using Data.Classes;
using DevExpress.Xpo.DB.Helpers;
using DocInterfaces;
using DocsData;
using ФабрикаРедакторов;

namespace Входящие
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DocInterfaces.DocsGlobalFactory.СоздательДокументов = new Шаблоны_документов();
            DocsGlobalFactory.ФабрикаРедакторов = new DefaultEditorsFactory();

            if(GlobalClass.CurrentUser ==null) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
