using System;
using System.Text;
using Demo.Entities;

namespace Demo.Repositories
{
    public class ResultRepository : Repository<Result>
    {
        private static readonly Object marker = new Object();
        private static ResultRepository repository = null;
        private ResultRepository()
        {    
        }
        public static ResultRepository GetRepository()
        {
            if (repository == null)
            {
                lock (marker)
                {
                    if (repository == null)
                        repository = new ResultRepository();
                }
            }
            return repository;
        }

        public string GetGrandPrixResults(GrandPrix grandprix)
        {
            StringBuilder sb = new StringBuilder();
            var results = grandprix.Results;
            foreach (var result in results)
            {
                sb.AppendFormat("{0} | {1}", result.Person.PersonName, result.Score);
            }
            return sb.ToString();
        }
    }
}
