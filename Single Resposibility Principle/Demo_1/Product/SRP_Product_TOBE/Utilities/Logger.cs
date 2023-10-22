using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Productos_ToBe.Utilities
{
    using System;
    using System.IO;

    public class Logger
    {
        private string logFilePath;

        public Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void Log(string message)
        {
            try
            {
                string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string logMessage = $"{timeStamp}: {message}";

                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que pueda ocurrir al escribir en el archivo de registro.
                Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
            }
        }
    }

}
