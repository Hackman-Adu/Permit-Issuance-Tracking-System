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
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SMA_Application
{
    public partial class Multisearch : Form
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter adapt;
        OleDbDataReader reader;
        string connectionstring;
        Thread t1;
        PdfPCell anothercell;
       
        
        public Multisearch()
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
            dataGridView1.ContextMenuStrip=contextMenuStrip1;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            dataGridView1.MultiSelect = true;
            
           

        }

        void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

      
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Filling(string target,string target1)
        {
            connection.Open();
            command = new OleDbCommand(target, connection);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                comboBox1.Items.Add(reader[target1].ToString());
            }
            connection.Close();
            reader.Close();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                comboBox1.Items.Clear();
                string select = "SELECT DISTINCT AppZoning FROM Applicants_Information";
                string t = "AppZoning";
                Filling(select, t);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox1.Items.Clear();
                string select = "SELECT DISTINCT AppGender FROM Applicants_Information";
                string t = "AppGender";
                Filling(select, t);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                comboBox1.Items.Clear();
                string select = "SELECT DISTINCT ProposedDev FROM Applicants_Information";
                string t = "ProposedDev";
                Filling(select, t);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "";
            if(comboBox1.Text=="Select Parameter Value")
            {
                MessageBox.Show("Select search parameter", "Search Parameter", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            connection.Open();
            if (radioButton1.Checked == true)
            {
                query = "SELECT * FROM Applicants_Information WHERE AppZoning='" + comboBox1.Text + "'";
            }
            else if (radioButton2.Checked == true)
            {
                query = "SELECT * FROM Applicants_Information WHERE AppGender='" + comboBox1.Text + "'";
            }
            else if (radioButton3.Checked == true)
            {
                query = "SELECT * FROM Applicants_Information WHERE ProposedDev='" + comboBox1.Text + "'";
            }
            else if (radioButton4.Checked == true)
            {
                query = "SELECT * FROM Applicants_Information";
            }
            command = new OleDbCommand(query,connection);
            adapt = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dt.Columns[0].ColumnName = "Development Number";
            dt.Columns[1].ColumnName = "Zoning";
            dt.Columns[2].ColumnName = "Proposed Development";
            dt.Columns[3].ColumnName = "Telephone";
            dt.Columns[4].ColumnName = "Gender";
            dt.Columns[5].ColumnName = "Application Date";
            dt.Columns[6].ColumnName = "Current Status";
            dt.Columns[7].ColumnName = "SPC Decision";
            dt.Columns[8].ColumnName = "Permit Date";
            dt.Columns[9].ColumnName = "Duration";
            dt.Columns[10].ColumnName = "Permit Fees";
            dt.Columns[11].ColumnName = "Submission Fees";
            dt.Columns[12].ColumnName = "Remarks";
            
            
            dataGridView1.DataSource = dt;
            connection.Close();
            groupBox1.Visible = false;
            comboBox1.Visible = false;
            button3.Visible = false;
            label1.Visible = true;
            CurrentS.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            timer1.Start();
            dataGridView1.Columns[10].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[11].DefaultCellStyle.Format = "c";
            dataGridView1.ClearSelection();
            
            
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DataTable();
            groupBox1.Visible = true;
            comboBox1.Visible = true;
            button3.Visible = true;
            label12.Text = "";
            label1.Visible = false;
            CurrentS.Visible = false;
            button4.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            timer1.Stop();
        }

        private void Multisearch_Load(object sender, EventArgs e)
        {
            label12.Text = "";
            label1.Visible = false;
            CurrentS.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            
            
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //SaveFileDialog svv = new SaveFileDialog();
            //svv.Title = "Exporting File";
            //svv.Filter = "CSV File(*.csv)|*.csv";
            //svv.FileName = "Hackman123";
            //if (svv.ShowDialog() == DialogResult.OK)
            //{
            //    StreamWriter cw = new StreamWriter(svv.FileName);

            //    string csv = string.Empty;
            //    foreach (DataGridViewColumn column in dataGridView1.Columns)
            //    {
            //        csv = csv + column.HeaderText + ",";

            //    }
            //    //csv = csv.TrimEnd(',');
            //    csv += "\r\n";
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        foreach (DataGridViewCell cell in row.Cells)
            //        {
            //            csv += cell.Value.ToString().TrimEnd(',').Replace(",", "") + ",";
            //        }
            //        csv += "\r\n";
            //    }
            //    cw.Write(csv, false);
            //    cw.Close();
            //    MessageBox.Show("Done");

            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CurrentS.Text))
                {
                    MessageBox.Show("Enter Report Title", "Printing Output", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CurrentS.Focus();
                    return;
                }
                printingAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void printingASPDF()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Exporting As PDF";
            save.Filter = "PDF|*.pdf";
            if(save.ShowDialog()==DialogResult.OK)
            {
                Document dd = new Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                FileStream fs = new FileStream(save.FileName, FileMode.Create);
                PdfWriter wr = PdfWriter.GetInstance(dd, fs);
                dd.Open();
                string title = "SUAME MUNICIPAL ASSEMBLY";
                string sub1 = Properties.Settings.Default.DepartmentName+Environment.NewLine;
                Paragraph par = new Paragraph(title);
                par.Alignment = Element.ALIGN_CENTER;
                dd.Add(par);
                Paragraph sub = new Paragraph(sub1+Environment.NewLine);
                sub.Alignment = Element.ALIGN_CENTER;
                dd.Add(sub);
                string a = "MAIN HEADING HERE"+Environment.NewLine;
                Paragraph p3 = new Paragraph(a+Environment.NewLine);
                p3.Alignment = Element.ALIGN_CENTER;
                dd.Add(p3);
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("user_logo.png");            
                iTextSharp.text.Rectangle rc = new iTextSharp.text.Rectangle(60,60);
                img.ScaleToFit(rc);
                string persons = "Department Head Name: .................................\nDepartment Code: ...............................................\nHead Signature: .................................................."+Environment.NewLine;             
                PdfPTable dtt = new PdfPTable(1);
                dtt.HorizontalAlignment = Element.ALIGN_LEFT;
                dtt.DefaultCell.BorderWidth = 0;
                dtt.WidthPercentage = 50;
                PdfPCell cell = new PdfPCell(img);
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.BorderWidth = 0;
                dtt.AddCell(cell);
                dd.Add(dtt);
                PdfPTable ct = new PdfPTable(2);
                ct.WidthPercentage = 100;
                ct.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell ccell = new PdfPCell(new Phrase(persons));
                ccell.HorizontalAlignment = Element.ALIGN_LEFT;
                ccell.BorderWidth = 0;
                ccell.Colspan = 50;
                ct.AddCell(ccell);
                PdfPCell ccell2 = new PdfPCell(new Phrase(persons));
                ccell.HorizontalAlignment = Element.ALIGN_RIGHT;
                ccell2.BorderWidth = 0;
                ccell2.Colspan = 50;
                ct.AddCell(ccell2);
                dd.Add(ct);

                Paragraph p1 = new Paragraph(Environment.NewLine);
                p1.Alignment = Element.ALIGN_LEFT;
                
                dd.Add(p1);
                PdfPTable dt = new PdfPTable(5);
                float[] flt = new float[]{ 0.9f, 0.2f, 0.2f, 0.9f, 0.2f };
                dt.SetWidths(flt);
                dt.WidthPercentage = 100;
                dt.DefaultCell.BorderWidth = 0.5f;
                dt.HorizontalAlignment = Element.ALIGN_LEFT;
                dt.WidthPercentage = 100;
                dt.DefaultCell.BorderColor = BaseColor.DARK_GRAY;
                dt.DefaultCell.Padding = 3;
                dt.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                dt.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;            
                iTextSharp.text.Font ff = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 6, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.GREEN);
                dt.DefaultCell.Phrase = new Phrase() { Font = ff };
                //foreach (DataGridViewColumn col in dataGridView1.Columns)
                //{
                //    PdfPCell cll = new PdfPCell(new Phrase(col.HeaderText));
                //    cll.HorizontalAlignment = Element.ALIGN_CENTER;
                //    cll.VerticalAlignment = Element.ALIGN_MIDDLE;
                //    cll.PaddingRight = 2;
                //    cll.PaddingLeft = 2;

                //    cll.BorderWidth = 0.5f;
                //    //cll.BackgroundColor = iTextSharp.text.BaseColor.DARK_GRAY;
                //    dt.AddCell(cll);   
                //}
                //dt.HeaderRows = 1;
                PdfPCell headercell = new PdfPCell(new Phrase("HEADER FOR ALL",ff));
                headercell.Colspan = dataGridView1.Columns.Count;
                headercell.HorizontalAlignment = Element.ALIGN_CENTER;
                headercell.VerticalAlignment = Element.ALIGN_MIDDLE;
                headercell.FixedHeight = 30;
                headercell.BackgroundColor = BaseColor.CYAN;
                dt.AddCell(headercell);
                iTextSharp.text.Font fff1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.PINK);
 
              
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        //anothercell = new PdfPCell(new Phrase(c.Value.ToString(),fff1));
                        //anothercell.Colspan = (int)0.75;
                        //anothercell.BorderWidth = 0;
                        //dt.AddCell(anothercell);
                        PdfPCell ll = new PdfPCell(new Phrase(c.Value.ToString(), fff1));
                        ll.BorderWidth = 0;
                        dt.AddCell(ll);
                        
                    }
                }
               
                
                    dd.Add(dt);
                    string footer = Environment.NewLine;
                    Paragraph footer1 = new Paragraph(footer);
                    dd.Add(footer1);
                    //string ft = "Number of records found: " + dataGridView1.Rows.Count.ToString() + " applicants";
                    //iTextSharp.text.Font ff = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 15, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.GREEN);
                    //Paragraph ppp = new Paragraph(ft,ff);
                    //dd.Add(ppp);
                    PdfPTable recc = new PdfPTable(1);
                    recc.WidthPercentage = 100;
                    iTextSharp.text.Font fff = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 15, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.WHITE);
              
                    string file = "Number of records found: " + dataGridView1.Rows.Count.ToString() + " applicants";
                    PdfPCell ce = new PdfPCell(new Phrase(file,fff));
                    ce.FixedHeight = 50;
                    ce.BorderWidth = 0;
                    ce.BackgroundColor = BaseColor.BLACK;
                    ce.HorizontalAlignment = Element.ALIGN_CENTER;
                    ce.VerticalAlignment = Element.ALIGN_MIDDLE;
              
                    
                    recc.AddCell(ce);
                    dd.Add(recc);
                   
                    dd.Close();

                

            }
            
        }
        void printingAll()
        {PdfPCell rowcell;
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Exporting As PDF";
            save.Filter = "PDF|*.pdf";
            if(save.ShowDialog()==DialogResult.OK)
            {
                iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4.Rotate());
                Document dd = new Document(rec, 10, 10, 10, 10);
                FileStream fs = new FileStream(save.FileName, FileMode.Create);
                PdfWriter wr = PdfWriter.GetInstance(dd, fs);
                dd.Open();
                string title = "SUAME MUNICIPAL ASSEMBLY APPLICANTS LIST";
                Paragraph titleP = new Paragraph(title);
                titleP.Alignment = Element.ALIGN_CENTER;
                titleP.SpacingAfter = 10;
                dd.Add(titleP);
                PdfPTable dt = new PdfPTable(dataGridView1.Columns.Count);
                float[]flts=new float[]{1f,1f,1f,1.5f,1f,1f,1f,1f,1f,1f,1f,1f,1f};
                dt.WidthPercentage = 100;
                dt.SetWidths(flts);
                iTextSharp.text.Font f = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font f1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 11, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
               
                foreach(DataGridViewColumn c in dataGridView1.Columns)
                {
                    PdfPCell header = new PdfPCell(new Phrase(c.HeaderText, f));
                    header.HorizontalAlignment = Element.ALIGN_LEFT;
                    header.VerticalAlignment = Element.ALIGN_MIDDLE;
                    header.BorderWidth = 0.5f;
                    dt.AddCell(header);

                }
                foreach(DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach(DataGridViewCell cell in r.Cells)
                    {
                        rowcell = new PdfPCell(new Phrase(cell.Value.ToString(), f1));
                        rowcell.HorizontalAlignment = Element.ALIGN_LEFT;
                        rowcell.BorderWidth = 0.5f;
                        dt.AddCell(rowcell);
                    }
                }
                dd.Add(dt);
                dd.Close();
              
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string deleting = "";
                if (radioButton1.Checked == true)
                {
                    deleting = "DELETE FROM Applicants_Information WHERE AppZoning='" + comboBox1.Text + "' ";
                }
                else if (radioButton2.Checked == true)
                {
                    deleting = "DELETE FROM Applicants_Information WHERE AppGender='" + comboBox1.Text + "' ";

                }
                else if (radioButton3.Checked == true)
                {
                    deleting = "DELETE FROM Applicants_Information WHERE ProposedDev='" + comboBox1.Text + "' ";

                }
                else if (radioButton4.Checked == true)
                {
                    deleting = "DELETE * FROM Applicants_Information";

                }
                command = new OleDbCommand(deleting, connection);
                DialogResult rr = MessageBox.Show("Do you want to permanently delete the following applicants from the current database?", "Deleting Applicants", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rr == DialogResult.Yes)
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Applicants Successfully Deleted");
                    connection.Close();
                    button1_Click(button4, e);
                    
                }
                else
                {
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked==true)
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "All Applicants";
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell.ContextMenuStrip = contextMenuStrip1;
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {

            int i = dataGridView1.Rows.Count;
            if (i > 1)
            {
                string a = i.ToString("N") + " Applicants Found";
                label12.Text = a.Replace(".00", "");
            }
            else
            {
                label12.Text = i.ToString() + " Applicant Found";
            }
            int ii = 0;
            foreach(DataGridViewRow rows in dataGridView1.SelectedRows)
            {
                ii++;
            }
            label4.Text = "Row(s) Selected: " + ii.ToString();

        }

        private void deleteSelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletingRows();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Columns.RemoveAt(e.ColumnIndex);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DeletingRows();
        }
        void DeletingRows()
        {
            try
            {
                foreach (DataGridViewRow rs in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(rs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(selectAll));
            t.Start();
            
            
        }
        void selectAll()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(new ThreadStart(deletingS));
            t.Start();
            
        }
        void deletingS()
        {

            int ii = dataGridView1.SelectedRows.Count;
            if (ii == 0)
            {
                MessageBox.Show("No records selected");
                return;
            }
            connection.Open();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                string deleting = "DELETE * FROM Applicants_information WHERE DevelopmentNo='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                command = new OleDbCommand(deleting, connection);
                command.ExecuteNonQuery();

            }
            connection.Close();
            MessageBox.Show("Done!!!");
            
        }

        

        }
        
    }



