using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Lab_6
{
    public class Green_1
    {
        public struct Participant
        {
            private string surname;

            private string group;

            private string trainer;

            private double result;



            private static readonly double standart;

            private static int passedCount;



            public string Surname => surname;
            public string Group => group;
            public string Trainer => trainer;
            public double Result => result;

            public bool HasPassed => result > 0 && result <= standart;
            public static int PassedTheStandard => passedCount;


            public void Run(double result)
            {
                if (result <= 0)
                {
                    Console.WriteLine("неккоректный резульатат");
                    return;
                }
                if (this.result == 0)
                {
                    this.result = result;
                    if (HasPassed)
                    {
                        passedCount++;
                    }
                }
                else
                {
                    Console.WriteLine("уже есть");
                }
            }


            static Participant()
            {
                standart = 100;
                passedCount = 0;
            }
            public Participant(string surname, string group, string trainer)
            {
                this.surname = surname;
                this.group = group;
                this.trainer = trainer;
                this.result = 0;
            }
            public void Print()
            {
                Console.WriteLine($"{surname}/{group}/{trainer}/{result}");
                Console.WriteLine(HasPassed ? "+" : "-");
            }
        }
    }
}
