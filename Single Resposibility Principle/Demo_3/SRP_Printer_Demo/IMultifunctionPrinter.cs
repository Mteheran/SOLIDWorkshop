using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SRP
{
    public interface IMultifunctionPrinter
    {
        void PrintBluePrint();
        void PrintNormal();
        void SendFax();
        void ScanPhoto();
        void ScanDocument();
        void PhoneCall();
    }
}
