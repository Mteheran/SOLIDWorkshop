using SRP_Printer_Demo;

namespace TestProjectPrinter
{
    public class UnitTestEpsonX
    {
        [Fact]
        public void PhoneCall_ShouldPrintCorrectMessage()
        {
            // Arrange
            EpsonX EpsonX = new EpsonX();
            string expectedMessage = "Llamada telefónica";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            EpsonX.PhoneCall();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void PrintBluePrint_ShouldPrintCorrectMessage()
        {
            // Arrange
            EpsonX EpsonX = new EpsonX();
            string expectedMessage = "Se imprime Plano";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            EpsonX.PrintBluePrint();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void PrintNormal_ShouldPrintCorrectMessage()
        {
            // Arrange
            EpsonX EpsonX = new EpsonX();
            string expectedMessage = "Impresión de una hoja Normal";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            EpsonX.PrintNormal();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ScanDocument_ShouldPrintCorrectMessage()
        {
            // Arrange
            EpsonX EpsonX = new EpsonX();
            string expectedMessage = "Se escanea documento";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            EpsonX.ScanDocument();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ScanPhoto_ShouldPrintCorrectMessage()
        {
            // Arrange
            EpsonX EpsonX = new EpsonX();
            string expectedMessage = "Se escanea Foto";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            EpsonX.ScanPhoto();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void SendFax_ShouldPrintCorrectMessage()
        {
            // Arrange
            EpsonX EpsonX = new EpsonX();
            string expectedMessage = "Se envía Fax";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            EpsonX.SendFax();

            // Assert
            string actualMessage = stringWriter.ToString().Trim();
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}