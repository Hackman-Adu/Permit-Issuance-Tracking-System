using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SMA_Application.Properties;

namespace SMA_Application
{
    public partial class BackupDB : Form
    {
        Settings st = new Settings();
        public BackupDB()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuMetroTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Choosing Backup Location";
            if(folder.ShowDialog()==DialogResult.OK)
            {
                loc.Text = folder.SelectedPath;
                st.BackupLocation = loc.Text;
                st.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   if(loc.Text=="")
            {
            MessageBox.Show("Choose a location", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
            }
            try
            {

                string backupfile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\PITS\\SMA_DATABASE.mdb";
               if(!Directory.Exists(loc.Text))
               {
                   Directory.CreateDirectory(loc.Text);
               }
               string filename = loc.Text + "\\Physical Planning Department DB.mdb";

                File.Copy(backupfile, filename, true);
                DialogResult rr = MessageBox.Show("Back Successfully Created" + Environment.NewLine + "Location: " + loc.Text + Environment.NewLine + Environment.NewLine + "Do you want to open?", "Backup File", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                this.Close();
                if (rr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(loc.Text);
                    this.Close();
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BackupDB_Load(object sender, EventArgs e)
        {   if(st.BackupLocation=="")
            {
                button3.Text = "Choose Backup Location";
            }
            else
            {
            button3.Text = "Change Backup Location";
            }
            loc.Text = st.BackupLocation;
        }
    }
}
