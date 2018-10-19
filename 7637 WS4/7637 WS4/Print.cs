using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace _7637_WS4
{
    class PrintClass
    {
        static string strToPrint;
        static Font font = new Font("Arial", 12);
        
        public PrintClass()
        {

        }

        public static void Print(string str)
        {
            strToPrint = str;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
            //printDoc.QueryPageSettings += PrintDoc_QueryPageSettings;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            //PageSetupDialog pageSetup = new PageSetupDialog();
            //pageSetup.Document = printDoc;

            PrintPreviewDialog preDlg = new PrintPreviewDialog();
            preDlg.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                //preDlg.ShowDialog();
                printDoc.Print();
            }
        }

        private static void PrintDoc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = true;
        }

        private static void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charsOnPage = 0;
            int linesOnPage = 0;
            //e.Graphics.DrawString("Привет", new Font("Arial", 14), Brushes.Black, 0, 0);
            e.Graphics.MeasureString(strToPrint, font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charsOnPage, out linesOnPage);
            e.Graphics.DrawString(strToPrint, font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);

            strToPrint = strToPrint.Substring(charsOnPage);
            e.HasMorePages = (strToPrint.Length > 0);
        }
    }
}
