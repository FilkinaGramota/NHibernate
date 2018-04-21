using System;
using System.Collections.Generic;
using System.IO;

namespace Demo.Entities
{
    public class GrandPrix : Entity<GrandPrix>
    {
        public virtual string Title { get; set; }
        public virtual City City { get; set; }
        public virtual DateTime DateOfStart { get; set; }
        public virtual DateTime DateOfEnd { get; set; }
        public virtual IList<Result> Results { get; set; }

        public GrandPrix()
        {
            Results = new List<Result>();
        }

        public virtual void AddResult(Result result)
        {
            result.GrandPrix = this;
            Results.Add(result);
        }

        public override string ToString()
        {
            return string.Format("\nGrand Prix: {0} {1} \nDate: {2} - {3}\n", Title, City, DateOfStart, DateOfEnd);
        }

        /// <summary>
        /// Read the information adout Grand Prix.
        /// </summary>
        /// <param name="reader">reader</param>
        /// <param name="writer">writer</param>
        /// <returns></returns>
        public static GrandPrix Read(TextReader reader = null, TextWriter writer = null)
        {
            if (reader == null)
                reader = Console.In;

            if (writer == null)
                writer = Console.Out;

            writer.Write("Grand Prix Title: ");
            string readTitle = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(readTitle))
            {
                Console.WriteLine("Something wrong with input data of title.\n");
                Console.Clear();
                GrandPrix.Read();
            }

            writer.Write("Date of the start: ");
            DateTime readDateOfStart = DateTime.Now;
            DateTime readDateOfEnd = DateTime.Now;
            try
            {
                readDateOfStart = Convert.ToDateTime(Console.ReadLine());
                readDateOfEnd = readDateOfStart.AddDays(2);
                writer.Write("Date of the end: {0}\n", readDateOfEnd);
            }
            catch (FormatException)
            {
                Console.WriteLine("Something wrong with input data of start date.\n");
                Console.Clear();
                GrandPrix.Read();                
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Something wrong with calculate of end date.\n");
                Console.Clear();
                GrandPrix.Read();
            }
                        
            return new GrandPrix
            {
                Title = readTitle,
                DateOfStart = readDateOfStart,
                DateOfEnd = readDateOfEnd
            };
        }
    }
}
