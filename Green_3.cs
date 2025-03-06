using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_3
    {
        public struct Student
        {
            private string name1;
            private string surname1;
            private int[] marks1;
            private bool isExpelled1;



            public double AvgMark
            {
                get
                {
                    if (marks1 == null || marks1.Length == 0) return 0;

                    double obsh = 0;
                    int cnt = 0;
                    foreach (int mark in marks1)
                    {
                        if (mark != 0)
                        {
                            obsh += mark;
                            cnt++;
                        }
                    }
                    if (cnt == 0) return 0;
                    return obsh / cnt;
                }
            }

            public bool IsExpelled => isExpelled1;
            public string Name => name1;
            public string Surname => surname1;
            public int[] Marks => marks1;


            public Student(string name, string surname)
            {
                name1 = name;
                surname1 = surname;
                marks1 = new int[3] { 0, 0, 0 };
                isExpelled1 = false;

            }


            public static void SortByAvgMark(Student[] array)
            {
                if (array == null)
                {
                    return;
                }
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AvgMark < array[j + 1].AvgMark)
                        {
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Exam(int mark)
            {
                if (isExpelled1)
                {
                    return;
                }

                if (mark < 2 || mark > 5)
                {
                    Console.WriteLine("Оценка должна быть от 2 до 5.");
                    return;
                }

                if (mark == 2)
                {
                    isExpelled1 = true;
                    return;
                }


                int index = 0;
                index = Array.IndexOf(marks1, 0);
                if (index != -1)
                {
                    marks1[index] = mark;
                }
                else
                {
                    Console.WriteLine("все оценки получены");
                }
            }



            public void Print()
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Студент: {Name} {Surname}");

                Console.WriteLine($"Оценки: {string.Join(", ", Marks)}");

                Console.WriteLine($"СР Балл: {AvgMark:F2}");

                Console.WriteLine($"Отчислен: {(IsExpelled ? "Да" : "Нет")}");
                Console.WriteLine("----------------------------------------");

            }
        }
    }
}
