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
    public partial class ExternalData : Form
    {
        OleDbConnection connection;
        OleDbConnection connection2;
        OleDbCommand command;
        string connectionstring;
        OleDbDataReader reader;
        DataTable dt;
        Timer t;
        public ExternalData()
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
            button3.Visible = false;
            t = new Timer();
            t.Tick += t_Tick;
            t.Start();
            this.FormClosing += ExternalData_FormClosing;
           
        }

        void ExternalData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy == true)
            {
                MessageBox.Show("Exporting is still in progress/You will be notified when done", "Exporting", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;

            }
            else
            {
                e.Cancel = false;
            }
        }

        

        void t_Tick(object sender, EventArgs e)
        {
            int i = dataGridView1.Rows.Count;
            if(i!=0)
            {
                int ii = dataGridView1.Rows.Count - 1;
                string a = "Number of records: " + ii.ToString("N");
                label3.Text = a.Replace(".00", "");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(excelpath.Text))
                {
                    MessageBox.Show("Data not chosen", "Importing Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (string.IsNullOrWhiteSpace(devNo.Text))
                {
                    MessageBox.Show("Enter Excel Sheet Name", "Importing Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    devNo.Focus();
                    return;
                }
                string conn = "Provider= Microsoft.Jet.OLEDB.4.0;Data Source=" + excelpath.Text + ";Extended Properties=Excel 8.0;";
                connection2 = new OleDbConnection(conn);
                string loading = "Select * from[" + devNo.Text + "$]";
                OleDbCommand Cmd = new OleDbCommand(loading, connection2);
                OleDbDataAdapter addt = new OleDbDataAdapter(Cmd);

                dt = new DataTable();
                addt.Fill(dt);
                dataGridView1.DataSource = dt;
                button3.Visible = false;
                pic.Visible = false;
                t.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            


            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DataTable();
            pic.Visible= true;
            button3.Visible = false;
            t.Stop();
            label3.Text = "";
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //Form1 form = new Form1();
            //form.button5_Click(bunifuImageButton1, e);
            this.Close();
            
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExternalData_Load(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select Excel File [.xls]";
            open.Filter = "Choose Excel File(.xls)|*.xls";
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.FileName.EndsWith(".xls"))
                {
                    pic.Visible = false;
                    excelpath.Text = open.FileName;
                    button3.Visible = true;
                }
                else
                {
                    MessageBox.Show("Wrong excel file format", "Importing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   if(dataGridView1.Rows.Count<=1)
            {
            MessageBox.Show("No data loaded", "Importing Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
            }
            try
            {
                if(backgroundWorker1.IsBusy==true)
                {
                    MessageBox.Show("Exporting is still in progress/You will be notified when done", "Exporting", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                else
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            ApplicantEntryForm entry = new ApplicantEntryForm();
            entry.Show();
            this.Close();
        }
        void Exporting()
        {
            try
            {
                connection.Open();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    string insert = "INSERT INTO Applicants_Information(DevelopmentNo,AppZoning,ProposedDev,ApplicantPhone,AppGender,DateApplication,AppCurrentState,SPC_Decision,DatePermitIssued,AppDuration,PermitFees,SubmissionFees,AppRemarks) VALUES (@no,@zoning,@proD,@tel,@gender,@AppDate,@current,@spc,@dateS,@duration,@permitFees,@SubFees,@remarks)";
                    command = new OleDbCommand(insert, connection);
                    command.Parameters.AddWithValue("@no", dataGridView1.Rows[i].Cells[0].Value);
                    command.Parameters.AddWithValue("@zoning", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@proD", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@tel", int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                    command.Parameters.AddWithValue("@gender", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@AppDate", DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
                    command.Parameters.AddWithValue("@current", dataGridView1.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@spc", dataGridView1.Rows[i].Cells[7].Value);
                    command.Parameters.AddWithValue("@dateS", DateTime.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()));
                    command.Parameters.AddWithValue("@duration", int.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString()));
                    command.Parameters.AddWithValue("@permitFees", double.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString()));
                    command.Parameters.AddWithValue("@SubFees", double.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString()));
                    command.Parameters.AddWithValue("@remarks", dataGridView1.Rows[i].Cells[12].Value);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Exporting();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled==true)
            {

                MessageBox.Show("Process cancelled", "Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            }
            else if(!(e.Error==null))
            {

                MessageBox.Show(e.Error.Message, "Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
            }
            else
            {

                MessageBox.Show("Data Exported successfully", "Applicant Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = new DataTable();
                label3.Text = "";
            }
                
        }

       
    }
}
