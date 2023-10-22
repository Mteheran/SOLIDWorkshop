using SRP_PersonService.Entities;
using SRP_PersonService_TOBE.DB;
using System.Reflection;

namespace SOLID.SRP
{
    public class PeopleService
    {
        PeopleDB peopleDB;
        public PeopleService()
        {
            peopleDB = new PeopleDB();
        }

        public List<Person> GetEmployes()
        {
            return peopleDB.GetAll();
        }
        public void AddPersonYears(int personId, int quantity, List<Person> people)
        {
            var person = peopleDB.FindPersonById(people, personId);
            person.Years += quantity;
        }
    }
}
