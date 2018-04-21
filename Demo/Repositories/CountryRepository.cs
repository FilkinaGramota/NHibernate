using System;
using System.Linq;
using Demo.Entities;

namespace Demo.Repositories
{
    public class CountryRepository : Repository<Country>
    {
        private static readonly Object marker = new Object();
        private static CountryRepository repository = null;
        private CountryRepository()
        {    
        }
        public static CountryRepository GetRepository()
        {
            if (repository == null)
            {
                lock (marker)
                {
                    if (repository == null)
                        repository = new CountryRepository();
                }
            }
            return repository;
        }

        public bool IsCountryExist(string countryName)
        {
            return GetAll().Select(x => x.CountryName).Contains(countryName);
        }

        public bool IsCountryExist(Country country)
        {
            return GetAll().Select(x => x.CountryName).Contains(country.CountryName);
        }

        public Country GetSameExist(Country country)
        {
            return GetAll().Single(x => x.CountryName == country.CountryName);
        }

        public Country GetByName(string countryName)
        {
            return GetAll().Single(x => x.CountryName == countryName);
        }
    }
}
