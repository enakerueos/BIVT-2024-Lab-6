﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    if (_marks == null)
                    {
                        return null;
                    }
                    int[] arr = new int[_marks.Length];
                    Array.Copy(_marks, arr, _marks.Length);
                    return arr;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
                    {
                        return 0;
                    }
                    double summa = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        summa += _marks[i];
                    }
                    return summa / _marks.Length;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            public void Exam(int mark)
            {
                if (_marks == null)
                {
                    return;
                }

                if (mark < 2 || mark > 5)
                {
                    return;
                }

                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    }
                }

                Console.WriteLine("уже писали все экзамены");
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}");
                Console.WriteLine($"Средний балл: {AvgMark:F2}");
            }
        }

        public struct Group
        {
            private string _name;
            private Student[] _students;
            private int _count;

            public string Name => _name;
            public Student[] Students => _students;

            public double AvgMark
            {
                get
                {
                    if (_students == null || _count == 0)
                    {
                        return 0;
                    }

                    int valid_St = 0;
                    double t_Avg = 0;

                    for (int i = 0; i < _count; i++)
                    {
                        if (_students[i].AvgMark > 0)
                        {
                            t_Avg += _students[i].AvgMark;
                            valid_St++;
                        }
                    }
                    return valid_St == 0 ? 0 : t_Avg / valid_St;
                }
            }

            public Group(string name)
            {
                _name = name;
                _students = new Student[0];
                _count = 0;
            }

            public void Add(Student student)
            {
                if (_students == null)
                    _students = new Student[0];
                Array.Resize(ref _students, _count + 1);
                _students[_count] = student;
                _count++;
            }

            public void Add(Student[] Students)
            {
                if (Students == null)
                {
                    return;
                }
                if (_students == null)
                {
                    _students = new Student[0];
                }

                int new_length = _count + Students.Length;

                Array.Resize(ref _students, new_length);
                for (int i = 0; i < Students.Length; i++)
                {
                    _students[_count + i] = Students[i];
                }
                _count = new_length;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {Name} | Средний балл: {AvgMark:F2}");

                foreach (var student in _students)
                {
                    student.Print();
                }
            }

            public static void SortByAvgMark(Group[] groups)
            {
                if (groups == null || groups.Length == 0)
                    return;
                bool t;
                do
                {
                    t = false;
                    for (int i = 0; i < groups.Length - 1; i++)
                    {
                        if (groups[i].AvgMark < groups[i + 1].AvgMark)
                        {
                            Group temp = groups[i];
                            groups[i] = groups[i + 1];
                            groups[i + 1] = temp;
                            t = true;
                        }
                    }
                } while (t);
            }
        }
    }
}