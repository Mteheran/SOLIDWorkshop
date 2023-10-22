using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SRP_PersonService_TOBE.Business
{
    public class AuditService
    {
        public void AuditSearchOperation()
        {
            string auditFilePath, logMessage;
            try
            {
                GetAuditInformation(out auditFilePath, out logMessage);
                SaveAuditOperation(auditFilePath, logMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la auditoría: {ex.Message}");
            }
        }

        private static void SaveAuditOperation(string auditFilePath, string logMessage)
        {
            File.AppendAllText(auditFilePath, logMessage + Environment.NewLine);
        }

        private static void GetAuditInformation(out string auditFilePath, out string logMessage)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            string assemblyName = assembly.GetName().Name;
            auditFilePath = "audit.log";
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string machineName = Environment.MachineName;
            logMessage = $"{currentTime} - Assembly: {assemblyName}, Machine: {machineName} - Search operation performed.";
        }
    }
}
