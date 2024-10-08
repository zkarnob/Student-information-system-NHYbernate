using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System;
using System.Linq;
using NHibernate.Tool.hbm2ddl;


public class Student
{
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual int Age { get; set; }
    public virtual string Dept { get; set; }
}


public class StudentMapping : ClassMap<Student>
{
    public StudentMapping()
    {
        Table("Student");
        Id(x => x.Id).GeneratedBy.Identity();
        Map(x => x.Name);
        Map(x => x.Age);
        Map(x => x.Dept);
    }
}


public class SessionMaker
{
    private static ISessionFactory _sessionFactory;

    public static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)
                InitializeSessionFactory();
            return _sessionFactory;
        }
    }

    private static void InitializeSessionFactory()
    {
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }

    public static void AddStudent(string name, int age, string dept)
    {
       
    }

    public static void GetAllStudents()
    {
     
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. Exit");
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
                    AddStudent(name, age, dept);
                    break;

                case "2":
                    GetAllStudents();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
