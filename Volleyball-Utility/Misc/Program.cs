using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volleyball_Utility
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static bool SetupRequired() //if setuprequired == true, then pass to setup form
        {
            try
            {
                // Volleyball-Utility\bin\Release
                string path = Path.Combine(AppContext.BaseDirectory, "info.txt");
                if (!File.Exists(path))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult result;
            if (SetupRequired()) //complete setup and then start proper application
            {
                using (var setupForm = new Setup())
                    result = setupForm.ShowDialog(); //program pauses here 
                if (result != DialogResult.OK) return;
            }
            Application.Run(new Form1());
        }
    }
}
