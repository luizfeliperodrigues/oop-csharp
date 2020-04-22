using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using UsingLinq.Entities;

namespace UsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double salaryCheck = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> employees = new List<Employee>();

            using(StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salary));
                }
            }

            Console.WriteLine($"Email of people whose salary is more than {salaryCheck.ToString("F2", CultureInfo.InvariantCulture)}:");
            var salaryEmployees = employees.Where(e => e.Salary > salaryCheck).OrderBy(e => e.Email).Select(e => e.Email);
            foreach(string e in salaryEmployees)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.Write("Sum of salary of people whose name starts with 'M': ");
            var salarySum = employees.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.Write(salarySum.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine();
        }
    }
}
