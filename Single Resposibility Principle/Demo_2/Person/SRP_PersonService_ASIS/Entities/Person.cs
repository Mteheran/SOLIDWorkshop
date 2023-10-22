using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_PersonService.Entities
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Years { get; set; }
        public bool IsActive { get; set; }
    }
}
