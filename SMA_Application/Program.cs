using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SMA_Application.Properties;
using Microsoft.Win32;
using Microsoft.Runtime;
using System.Runtime.InteropServices;

namespace SMA_Application
{
    static class Program
    {
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Settings st = new Settings();
            try
            {
                if (st.ApplicationCount == 5000)
                {
                    Application.Run(new ContactDeveloper());
                    return;
                }

                st.ApplicationCount++;
                st.Save();

                if (IsAppRunning() == true)
                {
       
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new UserLogin());
                }
               
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        static bool IsAppRunning()
        {
            Process[] process = Process.GetProcessesByName(Application.ProductName);
            if(process.Length>1)
            {
                return true;

            }
            else
            {
                return false;
                
            }
            
        }
    }
}
