using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            
            while (true)
            {
                try
                {
                    Console.WriteLine("\n=== Student Grade Management System ===");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Display All Students");
                    Console.WriteLine("3. Search for Student");
                    Console.WriteLine("4. Calculate Average Grade");
                    Console.WriteLine("5. Find Highest and Lowest Grades");
                    Console.WriteLine("0. Exit");
                    Console.Write("Choose an option: (0-5)");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudent(students);
                            break;
                        case "2":
                            DisplayStudents(students);
                            break;
                        case "3":
                            SearchStudent(students);
                            break;
                        case "4":
                            CalculateAverage(students);
                            break;
                        case "5":
                            FindHighLow(students);
                            break;
                        case "0":
                            Console.WriteLine("App done Running...");
                            return;
                        default:
                            Console.WriteLine(" Wrong option. Please try chosing from (0-5).");
                            break;
                    }
                }
                catch (FormatException format)
                {
                    Console.WriteLine($"Wrong Input Format Error: {format.Message}");
                }
                catch (OverflowException flow)
                {
                    Console.WriteLine($"Wrong Input Overflow Error: {flow.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                }
            }
        }

        static void AddStudent(Dictionary<string, int> students)
        {
            try
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Student name is empty, Please enter student name to proceed");
                    return;
                }

                Console.Write("Enter grade from the between to (0 - 100): ");
                
                int grade = int.Parse(Console.ReadLine()!); 

                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Grade must be only be between 0 and 100.");
                    return;
                }

                if (students.ContainsKey(name))
                {
                    students[name] = grade;
                    Console.WriteLine($"Student '{name}' already is available in files. Grade updated to {grade}.");
                }
                else
                {
                    students.Add(name, grade);
                    Console.WriteLine($"Student '{name}' added and saved successfully");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong grade  entry. Please enter a valid grade.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Grade value is too large. Please enter a reasonable number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add student: {ex.Message}");
            }
        }

        static void DisplayStudents(Dictionary<string, int> students)
        {
            try
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("No students were found.");
                    return;
                }

                Console.WriteLine("List of Students:");
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Key}: {student.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to display students: {ex.Message}");
            }
        }

        static void SearchStudent(Dictionary<string, int> students)
        {
            try
            {
                Console.Write("Enter name of student to search: ");
                string name = Console.ReadLine()?.Trim();

                if (students.TryGetValue(name!, out int grade))
                {
                    Console.WriteLine($"Student '{name}' has a grade of {grade}.");
                }
                else
                {
                    Console.WriteLine($"Student '{name}' was not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to search student: {ex.Message}");
            }
        }

        static void CalculateAverage(Dictionary<string, int> students)
        {
            try
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("No found students to calculate average grade.");
                    return;
                }

                double average = students.Values.Average();
                Console.WriteLine($"Average Grade: {average:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to calculate average grade: {ex.Message}");
            }
        }

        static void FindHighLow(Dictionary<string, int> students)
        {
            try
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("No students to analyze.");
                    return;
                }

                int highest = students.Values.Max();
                int lowest = students.Values.Min();

                var highStudents = students.Where(s => s.Value == highest).Select(s => s.Key);
                var lowStudents = students.Where(s => s.Value == lowest).Select(s => s.Key);

                Console.WriteLine($"Highest Grade ({highest}): {string.Join(", ", highStudents)}");
                Console.WriteLine($"Lowest Grade ({lowest}): {string.Join(", ", lowStudents)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to find  the highest and lowest grades: {ex.Message}");
            }
        }
    }
}
