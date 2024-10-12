using System;
using StudentManagementSystem.BusinessLogic;
using StudentManagementSystem.DataAccess.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace StudentManagement.Presentation
{
    class Program
    {
        static void Main(string[] args)  // This should be the entry point
        {
            var studentService = new StudentService();

            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        var age = int.Parse(Console.ReadLine());
                        Console.Write("Enter Dept: ");
                        var dept = Console.ReadLine();
                        studentService.AddStudent(name, age, dept);
                        break;

                    case "2":
                        var students = studentService.GetAllStudents();
                        foreach (var student in students)
                        {
                            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Dept: {student.Dept}");
                        }
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
