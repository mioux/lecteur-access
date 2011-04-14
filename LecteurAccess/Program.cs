using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace LectureAccess
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain frm = new frmMain();
            if (args.Length > 0 && File.Exists(args[0]))
                frm.OpenDB(args[0]);
            Application.Run(frm);
        }
    }
}