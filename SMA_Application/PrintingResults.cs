using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGVPrinterHelper;
using System.Windows.Forms;
using System.Drawing;

namespace SMA_Application
{
    class PrintingResults
    {

        public void printing(string subtitle1,DataGridView dgv)
        {
            DGVPrinter printer = new DGVPrinter();
            int i = dgv.Rows.Count - 1;

            string maintitle = "SUAME MUNICIPAL ASSEMBLY"+Environment.NewLine+"PHYSICAL PLANNING DEPARTMENT";


            string subtitle = subtitle1+Environment.NewLine+Environment.NewLine;
            printer.Title = maintitle;
            printer.SubTitle = subtitle;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.SubTitleAlignment = StringAlignment.Center;
            printer.TitleAlignment = StringAlignment.Center;
            printer.TitleFont = new Font("Times New Roman", 14, FontStyle.Bold);
            printer.SubTitleFont = new Font("Times New Roman", 14, FontStyle.Regular);
            printer.TitleColor = Color.FromArgb(64, 64, 64);
            printer.SubTitleColor = Color.FromArgb(64, 64, 64);
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true ;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.Footer = DateTime.Now.ToLongDateString() + Environment.NewLine + i.ToString()+" Applicants"+Environment.NewLine+ "Permit Issuance Tracking System";
            printer.FooterFont = new Font("Times New Roman", 12, FontStyle.Bold);
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dgv);
            
        }
        
    }




}
