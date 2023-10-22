using SOLID.SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Printer_Demo
{
    public class HPX11_OK : IPrint, IScan
    {
        public void PrintBluePrint()
        {
            Console.WriteLine("Se imprime Plano");
        }
        public void PrintNormal()
        {
            Console.WriteLine("Impresión de una hoja Normal");
        }

        public void ScanDocument()
        {
            Console.WriteLine("Se escanea documento");
        }

        public void ScanPhoto()
        {
            Console.WriteLine("Se escanea Foto");
        }

       
    }
}
