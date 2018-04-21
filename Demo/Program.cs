using System;
using Demo.Entities;
using Demo.Repositories;

namespace Demo
{
    class Program
    {
        int i = 1;
        
        private static PersonRepository personRep = PersonRepository.GetRepository();
        private static CountryRepository countryRep = CountryRepository.GetRepository();
        private static CityRepository cityRep = CityRepository.GetRepository();
        private static GrandPrixRepository grandprixRep = GrandPrixRepository.GetRepository();
        private static ResultRepository resultRep = ResultRepository.GetRepository();
        
        private static bool NewRecord()
        {
            Person person;
            Country countryPerson, countryGrandPrix;
            City city;
            GrandPrix grandprix;
            Result result;
            person = Person.Read();
            //
            if (personRep.IsPersonExist(person))
            {
                Console.WriteLine("Skater with this name is already exist.\nTry again.");
                return false;
            }            
            countryPerson = Country.Read();
            //
            if (countryRep.IsCountryExist(countryPerson))
            {
                countryPerson = countryRep.GetSameExist(countryPerson);
            }
            countryPerson.AddPerson(person);            
            grandprix = GrandPrix.Read();
            //
            if (grandprixRep.IsGrandPrixExist(grandprix))
            {
                grandprix = grandprixRep.GetSameExist(grandprix);
                Console.WriteLine(grandprix);
                result = Result.Read();
                grandprix.AddResult(result);
                person.AddResult(result);

                countryRep.Save(countryPerson);
                personRep.Save(person);
                grandprixRep.Save(grandprix);
                resultRep.Save(result);
                Console.WriteLine("Add new record:");
                Console.WriteLine(person);
                return true;
            }
            city = City.Read();
            //
            if (cityRep.IsCityExist(city))
            {
                Console.WriteLine("Grand Prix in this city is already exist.\nTry again.");
                return false;
            }
            city.AddGrandPrix(grandprix);            
            countryGrandPrix = Country.Read();
            //
            if (countryRep.IsCountryExist(countryGrandPrix))
            {
                countryGrandPrix = countryRep.GetSameExist(countryGrandPrix);
                countryGrandPrix.AddCity(city);

                result = Result.Read();
                grandprix.AddResult(result);
                person.AddResult(result);

                countryRep.Save(countryPerson);
                countryRep.Save(countryGrandPrix);
                cityRep.Save(city);
                personRep.Save(person);
                grandprixRep.Save(grandprix);
                resultRep.Save(result);
                Console.WriteLine("Add new record:");
                Console.WriteLine(person);
                return true;
            }
            countryGrandPrix.AddCity(city);
            result = Result.Read();
            grandprix.AddResult(result);
            person.AddResult(result);

            countryRep.Save(countryPerson);
            countryRep.Save(countryGrandPrix);
            cityRep.Save(city);
            personRep.Save(person);
            grandprixRep.Save(grandprix);                  
            resultRep.Save(result);
            Console.WriteLine("Add new record:");
            Console.WriteLine(person);
            return true;
        }

        private static void ShowAllSkaters()
        {
            var persons = personRep.GetAll();
            foreach (var skater in persons)
                Console.WriteLine(skater);
        }

        private static void ShowAllGrandPrixes()
        {
            var grandprixes = grandprixRep.GetAll();
            foreach (var grandprix in grandprixes)
            {
                Console.WriteLine(grandprix);
                Console.WriteLine(resultRep.GetGrandPrixResults(grandprix));
            }
        }

        private static bool AddSkaterToGrandPrix()
        {
            ShowAllSkaters();
            int SkaterID;
            Console.Write("Input the skater ID: ");
            try
            {
                SkaterID = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Be more careful and try again.");
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Be more careful and try again.");
                throw;
            }
            
            if (!personRep.IsIDExist(SkaterID))
            {
                Console.WriteLine("Be more careful and try again.");
                return false;
            }
            
            Console.Clear();
            Console.WriteLine("Skater {0} add to Grand Prix:", SkaterID);
            Person person = personRep.GetById(SkaterID);
            GrandPrix grandprix = GrandPrix.Read();
            Country country;
            City city;
            Result result;
            //
            if (grandprixRep.IsGrandPrixExist(grandprix))
            {
                grandprix = grandprixRep.GetSameExist(grandprix);
                Console.WriteLine(grandprix);

                result = Result.Read();
                grandprix.AddResult(result);
                person.AddResult(result);
                
                personRep.Save(person);
                grandprixRep.Save(grandprix);
                resultRep.Save(result);
                Console.WriteLine("Add skater to Grand Prix:");
                Console.WriteLine(person);
                return true;
            }
            //
            city = City.Read();
            //
            if (cityRep.IsCityExist(city))
            {
                Console.WriteLine("Grand Prix in this city is already exist.\nTry again.");
                return false;
            }
            city.AddGrandPrix(grandprix);
            //
            country = Country.Read();
            if (countryRep.IsCountryExist(country))
            {
                country = countryRep.GetSameExist(country);
                country.AddCity(city);

                result = Result.Read();
                grandprix.AddResult(result);
                person.AddResult(result);

                countryRep.Save(country);
                cityRep.Save(city);
                personRep.Save(person);
                grandprixRep.Save(grandprix);
                resultRep.Save(result);
                Console.WriteLine("Add skater to Grand Prix:");
                Console.WriteLine(person);
                return true;
            }
            country.AddCity(city);
            result = Result.Read();
            grandprix.AddResult(result);
            person.AddResult(result);

            countryRep.Save(country);
            cityRep.Save(city);
            personRep.Save(person);
            grandprixRep.Save(grandprix);
            resultRep.Save(result);
            Console.WriteLine("Add skater to Grand Prix:");
            Console.WriteLine(person);
            return true;
        }

        private static bool UpdatePerson()
        {
            ShowAllSkaters();
            int SkaterID;
            Console.Write("Input the skater ID: ");
            try
            {
                SkaterID = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Be more careful and try again.");
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Be more careful and try again.");
                throw;
            }
            if (!personRep.IsIDExist(SkaterID))
            {
                Console.WriteLine("Be more careful and try again.");
                return false;
            }

            Console.Clear();
            Person person = personRep.GetById(SkaterID);
            string[] substrings = person.ToString().Split('\n');
            Console.WriteLine("ID {0}", SkaterID);
            //name
            Console.Write("{0} -> ", substrings[2]);
            string readString = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(readString))//not empty -> change
            {
                string[] name = readString.Split(' ');
                if (name.Length == 3)
                    person.ChangePersonName(name[0], name[1], name[2]);
                else
                    if (name.Length == 2)
                        person.ChangePersonName(name[0], "", name[1]);
                    else
                    {
                        Console.WriteLine("\tInput name correctly");
                        return false;
                    }
            }
            //birth date
            Console.Write("{0} -> ", substrings[3]);
            readString = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(readString))//not empty -> change
            {
                DateTime date;
                try
                {
                    date = Convert.ToDateTime(readString);
                    person.ChangeBirthDate(date);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input date correctly.");
                    throw;
                }
            }
            //country
            Console.Write("{0} -> ", substrings[4]);
            readString = Console.ReadLine();
            Country country;
            if (!string.IsNullOrWhiteSpace(readString))//not empty -> change
            {
                if (countryRep.IsCountryExist(readString))
                {
                    country = countryRep.GetByName(readString);
                }
                country = new Country { CountryName = readString };
                country.AddPerson(person);
                countryRep.Save(country);
            }
            personRep.Save(person);
            return true;
        }

        private static bool DeletePerson()
        {
            ShowAllSkaters();
            int SkaterID;
            Console.Write("Input the skater ID: ");
            try
            {
                SkaterID = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Be more careful and try again.");
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Be more careful and try again.");
                throw;
            }
            if (!personRep.IsIDExist(SkaterID))
            {
                Console.WriteLine("Be more careful and try again.");
                return false;
            }

            var person = personRep.GetById(SkaterID);
            personRep.Delete(person);
            Console.Clear();
            ShowAllSkaters();
            return true;
        }
               
        static void Main(string[] args)
        {
            UserAction userChoice;
            do
            {
                Console.Clear();
                userChoice = Menu.Choice();

                switch (userChoice)
                {
                    case UserAction.AddNewRecord:

                        Console.WriteLine("\tCreate new records in database.");
                        NewRecord();
                        Console.ReadKey();
                        break;

                    case UserAction.AddSkaterToGrandPrix:

                        Console.WriteLine("\tAdd new Grand Prix in database.");
                        AddSkaterToGrandPrix();
                        Console.ReadKey();
                        break;

                    case UserAction.UpdateSkater:

                        Console.WriteLine("\tUpdate information about skater.");
                        UpdatePerson();
                        Console.ReadKey();
                        break;

                    case UserAction.ShowAllSkaters:

                        Console.WriteLine("\tShow all skaters in database.");
                        ShowAllSkaters();
                        Console.ReadKey();
                        break;

                    case UserAction.ShowAllGrandPrix:

                        Console.WriteLine("\tShow all Grand Prixes in database.");
                        ShowAllGrandPrixes();
                        Console.ReadKey();
                        break;

                    case UserAction.DeleteSkaterByID:

                        Console.WriteLine("\tDelete skater's record from database.");
                        DeletePerson();
                        Console.ReadKey();
                        break;

                    case UserAction.DeleteAll:

                        Console.WriteLine("\tClear database.");
                        personRep.CreateDataBase();
                        Console.ReadKey();
                        break;

                    case UserAction.Exit:

                        Console.WriteLine("\tTnank you for using this application!!!");
                        break;

                    default:
                        Console.WriteLine("\t! Something wrong ! Keep calm  and try again.");
                        Console.WriteLine("Press any key.");
                        Console.ReadKey();
                        break;
                }

            } while (userChoice != UserAction.Exit);
            Console.ReadKey();
        }
    }
}
