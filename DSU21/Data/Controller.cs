using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU21.Data
{
    public class Controller 
    {
        private IPersonRepository personRepository;
        public Controller(IPersonRepository repository)
        {
            personRepository = repository;
        }
        public async Task<Person> GetPerson(int? id)
        {
            // här hämtar vi data från Postgres

            var person = personRepository.GetPerson(id);
            await Task.Delay(0);
            return new Person { Name = "Erik" }; // ska ju såklart egentligen returnera person
        }
    }

    public interface IPersonRepository
    {
        Person GetPerson(int? id);
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
