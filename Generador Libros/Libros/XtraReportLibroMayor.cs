using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Generador_Libros.Libros
{
    public partial class XtraReportLibroMayor : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportLibroMayor()
        {
            InitializeComponent();
        }

        private void lblSumDebe_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void lblSumHaber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void lblSumHaber_AfterPrint(object sender, EventArgs e)
        {

        }

        private void lblSumDebe_AfterPrint(object sender, EventArgs e)
        {

        }
    }
}
