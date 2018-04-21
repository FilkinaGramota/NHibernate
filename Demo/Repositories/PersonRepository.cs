using System;
using System.Linq;
using Demo.Entities;

namespace Demo.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        private static readonly Object marker = new Object();
        private static PersonRepository repository = null;
        private PersonRepository()
        {    
        }
        public static PersonRepository GetRepository()
        {
            if (repository == null)
            {
                lock (marker)
                {
                    if (repository == null)
                        repository = new PersonRepository();
                }
            }
            return repository;
        }

        public bool IsPersonExist(Person person)
        {
            return GetAll().Any(x => x.PersonName.Equals(person.PersonName));
        }

        public bool IsIDExist(int id)
        {
            return GetAll().Select(x => x.ID).Contains(id);
        }

        public Country GetCountry(Person person)
        {
            return GetAll().Single(x => x.ID == person.ID).Country;
        }
    }
}
