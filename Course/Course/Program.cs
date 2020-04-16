using System;
using System.Collections.Generic;
using System.Text;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            
            Console.Write("How many employees will be registered? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i<=n; i++)
            {
                Console.WriteLine("Emplyoee #" + i + ":");
                Console.Write("Id: ");
                int empId = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee(empId, name, salary));
            }

            Console.Write("Enter the employee id that will have salary increase : ");
            int id = int.Parse(Console.ReadLine());

            Employee e = new Employee();
            e = employees.Find(e => e.Id == id);
            if (e != null)
            {
                Console.Write("Enter the percentage: ");
                double percentage = double.Parse(Console.ReadLine());
                e.increaseSalary(percentage);
            }
            else
            {
                Console.WriteLine("This id does not exist!");
            }

            Console.WriteLine("Updated list of employees:");
            foreach(Employee emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }

            Console.WriteLine("somente testando o git");

            Console.WriteLine("Como voce esta hoje?");
        }
    }
}
