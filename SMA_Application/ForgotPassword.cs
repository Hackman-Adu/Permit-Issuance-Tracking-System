using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace SMA_Application
{
    public partial class ForgotPassword : Form
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataReader reader;
        string connectionstring;
        public ForgotPassword()
        {
            InitializeComponent();
            string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\PITS";
            if (!Directory.Exists(dbpath))
            {
                Directory.CreateDirectory(dbpath);
            }
            AppDomain.CurrentDomain.SetData("DataDirectory", dbpath);
            connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\SMA_DATABASE.mdb";
            connection = new OleDbConnection(connectionstring);
        }

       

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }
        

        private void button6_Click(object sender, EventArgs e)
        {   if(Password.Text!=password2.Text)
            {
                MessageBox.Show("Password do not match", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {

                connection.Open();
                string select = "SELECT * FROM Users_Information WHERE User_ID='" + Secured.Encrytion(userid.Text.Trim()) + "'";
                command = new OleDbCommand(select, connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    string updating = "UPDATE Users_Information SET User_Password='" + Secured.Encrytion(Password.Text.Trim()) + "' WHERE User_ID='" + Secured.Encrytion(userid.Text.Trim()) + "'";
                    command = new OleDbCommand(updating, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Password successfully changed", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("User of ID " + userid.Text + " does not exist\nMake sure you typed in the correct User ID", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
