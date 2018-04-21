using System;
using System.IO;

namespace Demo.Entities
{
    public class Result : Entity<Result>
    {
        public virtual Person Person { get; set; }
        public virtual GrandPrix GrandPrix { get; set; }
        public virtual Score Score { get; set; }

        public virtual void ChangeScore(double ShortProgram, double FreeSkating)
        {
            Score = new Score(ShortProgram, FreeSkating);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", GrandPrix, Score);
        }

        /// <summary>
        /// Read the information adout result.
        /// </summary>
        /// <param name="reader">reader</param>
        /// <param name="writer">writer</param>
        /// <returns></returns>
        public static Result Read(TextReader reader = null, TextWriter writer = null)
        {
            if (reader == null)
                reader = Console.In;

            if (writer == null)
                writer = Console.Out;

            double readSP = 0;
            writer.Write("Short Program: ");
            try
            {
                readSP = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Something wrong with input score of short program.\n");
                Console.Clear();
                Result.Read();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Something wrong with input score of short program.\n");
                Console.Clear();
                Result.Read();
            }

            double readFS = 0;
            writer.Write("Free Skating: ");
            try
            {
                readFS = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Something wrong with input score of free skating.\n");
                Console.Clear();
                Result.Read();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Something wrong with input score of free skating.\n");
                Console.Clear();
                Result.Read();
            }
                        
            return new Result
            {
                Score = new Score(readSP, readFS)
            };
        }
    }
}
