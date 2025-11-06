using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Main.Login_Screen;





namespace DVLD_Main
{

    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]

        static void Main()
        {

            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FRMMainForm());

            Application.Run(new Login_Screen.FRMLoginScreen());


        }

    }

}














