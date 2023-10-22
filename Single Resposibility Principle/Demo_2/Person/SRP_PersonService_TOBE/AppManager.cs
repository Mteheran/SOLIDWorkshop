using SOLID.SRP;
using SRP_PersonService.Entities;
using SRP_PersonService_TOBE.Business;

namespace SRP_PersonService_TOBE
{
    public class AppManager
    {
        AuditService _auditService;
        PeopleService _peopleService;
        ReportPeopleService _reportPeopleService;
        List<Person> _people;

        public AppManager()
        {
            _auditService = new AuditService();
            _peopleService = new PeopleService();
            _reportPeopleService = new ReportPeopleService();
            _people = new List<Person>();
        }
        public void RunApp()
        {
            PeopleService productInventory = new PeopleService();
            _people = productInventory.GetEmployes();
            string print = string.Empty;
            string userInput = string.Empty;
            string quantityInput = string.Empty;

            _reportPeopleService.GenerateReport(_people);

            LoopApp(productInventory, ref userInput, ref quantityInput);

            Console.ReadLine();
        }

        private void LoopApp(PeopleService productInventory, ref string userInput, ref string quantityInput)
        {
            while (string.IsNullOrEmpty(userInput))
            {
                ReadData(out userInput, out quantityInput);

                ModifyData(productInventory, userInput, quantityInput);

                PrintReport();

                userInput = string.Empty;
                quantityInput = string.Empty;
            }
        }

        private void PrintReport()
        {
            _reportPeopleService.GenerateReport(_people);
        }

        private void ModifyData(PeopleService productInventory, string userInput, string quantityInput)
        {
            int idPerson = 0;
            int.TryParse(userInput, out idPerson);

            int quantity = 0;
            int.TryParse(quantityInput, out quantity);
            productInventory.AddPersonYears(idPerson, quantity, _people);
        }

        private void ReadData(out string userInput, out string quantityInput)
        {
            Console.WriteLine("Ingresa el Id de una Persona:");

            userInput = Console.ReadLine();

            Console.WriteLine("Ingresa la cantidad agregada a un producto:");

            quantityInput = Console.ReadLine();
        }
    }
}
