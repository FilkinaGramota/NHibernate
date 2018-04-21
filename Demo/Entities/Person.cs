using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Demo.Entities
{
    public class Person : Entity<Person>
    {
        public virtual Name PersonName { get; set; }
        public virtual Country Country { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual IList<Result> Results { get; set; }

        public Person()
        {
            Results = new List<Result>();
        }
        public virtual void AddResult(Result result)
        {
            result.Person = this;
            Results.Add(result);
        }
        public virtual void ChangePersonName(string firstName, string middleName, string lastName)
        {
            PersonName = new Name(firstName, middleName, lastName);
        }

        public virtual void ChangeBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            var buildString = new StringBuilder();

            buildString.AppendFormat("\nID {0}.\nName: {1} \nBirth Date: {2} {3}", ID, PersonName, BirthDate, Country);

            foreach (var result in Results)
            {
                buildString.Append(result.ToString());
            }

            return buildString.ToString();
        }

        /// <summary>
        /// Read the information adout skater.
        /// </summary>
        /// <param name="reader">reader</param>
        /// <param name="writer">writer</param>
        /// <returns></returns>
        public static Person Read(TextReader reader = null, TextWriter writer = null)
        {
            if (reader == null)
                reader = Console.In;

            if (writer == null)
                writer = Console.Out; 

            writer.WriteLine("\tInput the data of skater.");
            writer.Write("First name: ");
            string readFirstName = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(readFirstName))
            {
                Console.WriteLine("Something wrong with input data of first name.\n");
                Console.Clear();
                Person.Read();
            }

            writer.Write("Middle name: ");
            string readMiddleName = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(readMiddleName))
            {
                readMiddleName = null;
            }

            writer.Write("Last name: ");
            string readLastName = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(readLastName))
            {
                Console.WriteLine("Something wrong with input data of last name.\n");
                Console.Clear();
                Person.Read();
            }

            DateTime readBirthDate = DateTime.Now;
            writer.Write("Date of Birth (dd.mm.yyyy): ");
            try
            {
                readBirthDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Something wrong with input data of birth date.\n");
                Console.Clear();
                Person.Read();
            }

            return new Person
            {
                PersonName = new Name(readFirstName, readMiddleName, readLastName),
                BirthDate = readBirthDate
            };
        }
    }
}
