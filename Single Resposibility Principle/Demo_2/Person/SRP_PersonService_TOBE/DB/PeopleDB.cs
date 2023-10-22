using SRP_PersonService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_PersonService_TOBE.DB
{
    public class PeopleDB
    {
        public List<Person> GetAll()
        {
            var people = new List<Person>
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
            return people;
        }

        public Person FindPersonById(List<Person> people, int personId)
        {
            return people.FirstOrDefault(x => x.Id == personId);
        }
    }
}
