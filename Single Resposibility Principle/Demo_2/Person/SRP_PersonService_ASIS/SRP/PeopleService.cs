using SRP_PersonService.Entities;
using System.Reflection;

namespace SOLID.SRP
{
    public class PeopleService
    {
        List<Person> people = null;
        public PeopleService()
        {
            LoadPeople();
        }

        private void LoadPeople()
        {
            people = new List<Person>
            {
                new Person { Id = 1, Name = "Andrés", Years = 50, IsActive = false },
                new Person { Id = 2, Name = "Carlos", Years = 30, IsActive = true },
                new Person { Id = 3, Name = "Juan", Years = 20, IsActive = true },
                new Person { Id = 4, Name = "Jose", Years = 5, IsActive = false },
                new Person { Id = 5, Name = "Pedro", Years = 45, IsActive = true },
                new Person { Id = 6, Name = "Camilo", Years = 56, IsActive = true },
                new Person { Id = 7, Name = "Andrea", Years = 0, IsActive = false },
                new Person { Id = 8, Name = "Virginia", Years = 11, IsActive = true },
                new Person { Id = 0, Name = null, Years = 0, IsActive = true },
            };
        }

        public void GenerateReport()
        {
           var resultPersonList = people.Where(x=>x.IsActive && (x.Years > 0 && x.Id > 0) && !string.IsNullOrEmpty(x.Name) ).ToList();


            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║                 Lista de Empleados             ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.WriteLine("║  ID  ║      Nombre      ║ Años     ║ Activo    ║");
            Console.WriteLine("╠══════╬══════════════════╬══════════╬═══════════╣");

            foreach (Person person in people)
            {
                string personName = person.Name ?? "N/A";
                string isActive = person.IsActive ? "Sí" : "No";

                Console.WriteLine($"║ {person.Id,4} ║ {personName,-16} ║ {person.Years,8} ║ {isActive,9} ║");
            }

            Console.WriteLine("╚══════╩══════════════════╩══════════╩═══════════╝");

            AuditSearchOperation();

        }

        public void AuditSearchOperation( )
        {
            // Obtiene la referencia al ensamblado actual
            Assembly assembly = Assembly.GetEntryAssembly();

            // Obtiene el nombre del ensamblado
            string assemblyName = assembly.GetName().Name;
            string auditFilePath = "audit.log";
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string machineName = Environment.MachineName;
            string logMessage = $"{currentTime} - Assembly: {assemblyName}, Machine: {machineName} - Search operation performed.";

            try
            {
                File.AppendAllText(auditFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la auditoría: {ex.Message}");
            }
        }

        public void AddPersonYears(int personId, int quantity)
        {
            var person = people.FirstOrDefault(x => x.Id == personId);
            person.Years += quantity;
        }
    }
}
