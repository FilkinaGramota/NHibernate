using System;
using System.Linq;
using Demo.Entities;

namespace Demo.Repositories
{
    public class GrandPrixRepository : Repository<GrandPrix>
    {
        private static readonly Object marker = new Object();
        private static GrandPrixRepository repository = null;
        private GrandPrixRepository()
        {    
        }
        public static GrandPrixRepository GetRepository()
        {
            if (repository == null)
            {
                lock (marker)
                {
                    if (repository == null)
                        repository = new GrandPrixRepository();
                }
            }
            return repository;
        }

        public bool IsGrandPrixExist(GrandPrix grandprix)
        {
            return GetAll().Select(x => x.Title).Contains(grandprix.Title);
        }

        public GrandPrix GetSameExist(GrandPrix grandprix)
        {
            return GetAll().Single(x => x.Title == grandprix.Title);
        }

        public Country GetCountry(GrandPrix grandprix)
        {
            return GetAll().Single(x => x.ID == grandprix.ID).City.Country;
        }

        public City GetCity(GrandPrix grandprix)
        {
            return GetAll().Single(x => x.ID == grandprix.ID).City;
        }
    }
}
