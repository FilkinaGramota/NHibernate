using System;
using System.IO;

namespace Demo
{
    class Menu
    {
        public static UserAction Choice(TextReader reader = null, TextWriter writer = null)
        {
            if (reader == null)
                reader = Console.In;

            if (writer == null)
                writer = Console.Out;

            var type = typeof(UserAction);
            var values = type.GetEnumValues();

            writer.WriteLine("\tMENU");
            for (int i = 0; i < values.Length; i++)
                writer.WriteLine("\n {0}. {1}", Enum.Format(type, values.GetValue(i), "D"), values.GetValue(i));

            writer.Write(" ---> ");
            var userInput = reader.ReadLine();

            if (writer == Console.Out)
                Console.Clear();

            return (UserAction)Enum.Parse(type, userInput);
        }
    }
}
