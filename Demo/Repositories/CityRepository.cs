using System;
using System.Linq;
using Demo.Entities;

namespace Demo.Repositories
{
    public class CityRepository : Repository<City>
    {
        private static readonly Object marker = new Object();
        private static CityRepository repository = null;
        private CityRepository()
        {    
        }
        public static CityRepository GetRepository()
        {
            if (repository == null)
            {
                lock (marker)
                {
                    if (repository == null)
                        repository = new CityRepository();
                }
            }
            return repository;
        }

        public bool IsCityExist(City city)
        {
            return GetAll().Select(x => x.CityName).Contains(city.CityName);
        }

        public City GetSameExist(City city)
        {
            return GetAll().Single(x => x.CityName == city.CityName);
        }
    }
}
