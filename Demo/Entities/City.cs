using System;
using System.IO;

namespace Demo.Entities
{
    public class City : Entity<City>
    {
        public virtual string CityName { get; set; }
        public virtual Country Country { get; set; }
        public virtual GrandPrix GrandPrix { get; set; }

        public virtual void AddGrandPrix(GrandPrix grandprix)
        {
            grandprix.City = this;
            GrandPrix = grandprix;
        }

        public override string ToString()
        {
            return string.Format("\nCity: {0}  {1}", CityName, Country);
        }

        /// <summary>
        /// Read the information adout city.
        /// </summary>
        /// <param name="reader">reader</param>
        /// <param name="writer">writer</param>
        /// <returns></returns>
        public static City Read(TextReader reader = null, TextWriter writer = null)
        {
            if (reader == null)
                reader = Console.In;

            if (writer == null)
                writer = Console.Out;

            writer.Write("Competition City: ");
            string readCity = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(readCity))
            {
                Console.WriteLine("Something wrong with input data of country name.\n");
                Console.Clear();
                City.Read();
            }

            return new City
            {
                CityName = readCity
            };
        }
    }
}
