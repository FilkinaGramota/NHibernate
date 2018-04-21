using System;
using System.Collections.Generic;
using System.IO;

namespace Demo.Entities
{
    public class Country : Entity<Country>
    {
        public virtual string CountryName { get; set; }
        public virtual IList<City> Cities { get; set; }
        public virtual IList<Person> Persons { get; set; }
        
        public Country()
        {
            Persons = new List<Person>();
            Cities = new List<City>();
        }

        public virtual void AddCity(City city)
        {
            city.Country = this;
            Cities.Add(city);
        }

        public virtual void AddPerson(Person person)
        {
            person.Country = this;
            Persons.Add(person);
        }

        public override string ToString()
        {
            return string.Format("\nCountry: {0}", CountryName);
        }

        /// <summary>
        /// Read the information adout country.
        /// </summary>
        /// <param name="reader">reader</param>
        /// <param name="writer">writer</param>
        /// <returns></returns>
        public static Country Read(TextReader reader = null, TextWriter writer = null)
        {
            if (reader == null)
                reader = Console.In;

            if (writer == null)
                writer = Console.Out;

            writer.Write("Country: ");
            string readCountry = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(readCountry))
            {
                Console.WriteLine("Something wrong with input data of country name.\n");
                Console.Clear();
                Country.Read();
            }
                        
            return new Country
            {
                CountryName = readCountry
            };
        }
    }
}
