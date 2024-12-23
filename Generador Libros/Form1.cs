using DevExpress.XtraReports.UI;
using Generador_Libros.Libros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generador_Libros
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonGenerarLibroDiario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ArchivoDatos archivoDatos = new ArchivoDatos();
            archivoDatos.LeerDatos(out string ruc, out string razon, out string rutaexceldiario, out string rutaexcelmayor);

            // Validar que ningún campo esté vacío
            if (string.IsNullOrWhiteSpace(ruc) ||
                string.IsNullOrWhiteSpace(razon) ||
                string.IsNullOrWhiteSpace(rutaexceldiario))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Por favor, complete todos los campos antes de continuar en configuraciones.", "Campos incompletos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            // Validar que el RUC tenga solo números y sea de una longitud específica (por ejemplo, 11 dígitos)
            if (!System.Text.RegularExpressions.Regex.IsMatch(ruc, @"^\d{11}$"))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("El RUC debe contener solo 11 dígitos numéricos.", "RUC inválido", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            // Validar que la ruta del archivo de diario exista
            if (!System.IO.File.Exists(rutaexceldiario))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("La ruta del archivo Excel para el Libro Diario no es válida o el archivo no existe.", "Ruta inválida", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            // Generar el reporte si todas las validaciones son correctas
            XtraReportLibroDiario report = new XtraReportLibroDiario();
            report.lblruc.Text = ruc;
            report.lblrazon.Text = razon;
            report.excelDataSource1.FileName = rutaexceldiario;

            var tool = new ReportPrintTool(report);
            tool.PrintingSystem.StartPrint += printingSystem_StartPrint;
            tool.ShowPreview();
        }


        private void printingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            // Establece el nombre de la impresora.
            var printerSettings = new PrinterSettings();
            e.PrintDocument.PrinterSettings.PrinterName = printerSettings.PrinterName;
        }

        private frmconfig frmConfigInstance;

        private void barButtonConfiguracionesLibros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmConfigInstance == null || frmConfigInstance.IsDisposed)
            {
                frmConfigInstance = new frmconfig();
                frmConfigInstance.MdiParent = this;
                frmConfigInstance.Show();

            }
            else
            {
                frmConfigInstance.Focus();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ArchivoDatos archivoDatos = new ArchivoDatos();
            archivoDatos.LeerDatos(out string ruc, out string razon, out string rutaexceldiario, out string rutaexcelmayor);

            // Validar que ningún campo esté vacío
            if (string.IsNullOrWhiteSpace(ruc) ||
                string.IsNullOrWhiteSpace(razon) ||
                string.IsNullOrWhiteSpace(rutaexcelmayor))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Por favor, complete todos los campos antes de continuar en configuraciones.", "Campos incompletos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            // Validar que el RUC tenga solo números y sea de una longitud específica (por ejemplo, 11 dígitos)
            if (!System.Text.RegularExpressions.Regex.IsMatch(ruc, @"^\d{11}$"))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("El RUC debe contener solo 11 dígitos numéricos.", "RUC inválido", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            // Validar que la ruta del archivo de diario exista
            if (!System.IO.File.Exists(rutaexcelmayor))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("La ruta del archivo Excel para el Libro Mayor no es válida o el archivo no existe.", "Ruta inválida", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            // Generar el reporte si todas las validaciones son correctas
            XtraReportLibroMayor report = new XtraReportLibroMayor();
            report.lblruc.Text = ruc;
            report.lblrazon.Text = razon;
            report.excelDataSource1.FileName = rutaexcelmayor;

            var tool = new ReportPrintTool(report);
            tool.PrintingSystem.StartPrint += printingSystem_StartPrint;
            tool.ShowPreview();
        }
    }
}

