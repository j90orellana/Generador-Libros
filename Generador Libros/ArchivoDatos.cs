using System;
using System.IO;

namespace Generador_Libros
{
    public class ArchivoDatos
    {
        // Ruta del archivo donde se guardarán los datos
        private const string archivoRuta = "datos.txt";

        // Método para guardar los datos en el archivo
        public void GuardarDatos(string ruc, string razon, string rutaexceldiario, string rutaexcelmayor)
        {
            using (StreamWriter writer = new StreamWriter(archivoRuta))
            {
                writer.WriteLine("RUC=" + ruc);
                writer.WriteLine("RAZON=" + razon);
                writer.WriteLine("RUTAEXCELDIARIO=" + rutaexceldiario);
                writer.WriteLine("RUTAEXCELMAYOR=" + rutaexcelmayor);
            }
        }

        // Método para leer los datos desde el archivo
        public void LeerDatos(out string ruc, out string razon, out string rutaexceldiario, out string rutaexcelmayor)
        {
            ruc = razon = rutaexceldiario = rutaexcelmayor = string.Empty;

            if (File.Exists(archivoRuta))
            {
                using (StreamReader reader = new StreamReader(archivoRuta))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (linea.StartsWith("RUC="))
                            ruc = linea.Substring("RUC=".Length);
                        else if (linea.StartsWith("RAZON="))
                            razon = linea.Substring("RAZON=".Length);
                        else if (linea.StartsWith("RUTAEXCELDIARIO="))
                            rutaexceldiario = linea.Substring("RUTAEXCELDIARIO=".Length);
                        else if (linea.StartsWith("RUTAEXCELMAYOR="))
                            rutaexcelmayor = linea.Substring("RUTAEXCELMAYOR=".Length);
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
    }
}
