using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Easy.Instance;

namespace DAVIDSystems.donotsleep
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
            if (SingleInstance.IsSecondInstance("donotsleep"))
            {
                return;
            }
            var mainForm = new MainForm();
            mainForm.Visible = false;
            mainForm.DisplayBallonMessage(null, 3000);
            ApplicationContext context = new ApplicationContext();
            Application.Run(context);
        }

    }
}
