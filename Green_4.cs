using System;
using System.Linq;

namespace Lab_6
{
    public class Green_4
    {
        public struct Participant
        {
            private string name1;
            private string surname1;
            private double[] jumps1;

            public string Name => name1;
            public string Surname => surname1;
            public double[] Jumps
            {
                get
                {
                    if (jumps1 == null)
                    {
                        return null;
                    }
                    double[] arrays = new double[jumps1.Length];
                    Array.Copy(jumps1, arrays, jumps1.Length);
                    return arrays;
                }
            }

            public double BestJump
            {
                get
                {
                    if (jumps1 == null || jumps1.Length == 0) return 0;

                    return jumps1.Max();
                }
            }

            public Participant(string name, string surname)
            {
                name1 = name;
                surname1 = surname;
                jumps1 = new double[3] { 0, 0, 0 };
            }

            public void Jump(double result)
            {
                if (jumps1 == null || jumps1.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < jumps1.Length; i++)
                {
                    if (jumps1[i] == 0)
                    {
                        jumps1[i] = result;
                        return;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return;
                }

                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {

                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Спортсмен: {Name} {Surname}");
                Console.WriteLine($"все прыжки участника: {string.Join(", ", Jumps)}");
                Console.WriteLine($"самый лучший прыжок: {BestJump:F2}");
            }
        }
    }
}
