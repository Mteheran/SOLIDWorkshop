using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRP_Printer_Demo;
namespace TestProjectPrinter
{
    public class UnitTestHPX11_OK
    {
        
        [Fact]
        public void PrintBluePrint_ShouldPrintCorrectMessage()
        {
            // Arrange
            HPX11 HPX11 = new HPX11();
            string expectedMessage = "Se imprime Plano";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            HPX11.PrintBluePrint();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void PrintNormal_ShouldPrintCorrectMessage()
        {
            // Arrange
            HPX11 HPX11 = new HPX11();
            string expectedMessage = "Impresión de una hoja Normal";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            HPX11.PrintNormal();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ScanDocument_ShouldPrintCorrectMessage()
        {
            // Arrange
            HPX11 HPX11 = new HPX11();
            string expectedMessage = "Se escanea documento";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            HPX11.ScanDocument();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ScanPhoto_ShouldPrintCorrectMessage()
        {
            // Arrange
            HPX11 HPX11 = new HPX11();
            string expectedMessage = "Se escanea Foto";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            HPX11.ScanPhoto();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

       
    }
}
