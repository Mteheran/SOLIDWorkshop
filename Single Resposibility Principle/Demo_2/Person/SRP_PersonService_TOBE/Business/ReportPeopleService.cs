using SRP_PersonService.Entities;
using SRP_PersonService_TOBE.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_PersonService_TOBE.Business
{
    public class ReportPeopleService
    {
        public void GenerateReport(List<Person> people)
        {
            BuildHeader();

            BuildBody(people);
            
            BuildFooter();
        }

        private void BuildHeader()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║                 Lista de Empleados             ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.WriteLine("║  ID  ║      Nombre      ║ Años     ║ Activo    ║");
            Console.WriteLine("╠══════╬══════════════════╬══════════╬═══════════╣");
        }
        private void BuildBody(List<Person> people)
        {
            foreach (Person person in people)
            {
                string personName = person.Name ?? "N/A";
                string isActive = person.IsActive ? "Sí" : "No";

                Console.WriteLine($"║ {person.Id,4} ║ {personName,-16} ║ {person.Years,8} ║ {isActive,9} ║");
            }
        }
        private void BuildFooter()
        {
            Console.WriteLine("╚══════╩══════════════════╩══════════╩═══════════╝");
        }
    }
}
