using System;
using System.Collections.Generic;
using System.Text;

namespace Course
{
    class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Salary { get; private set; }

        public Employee()
        {
            Salary = 0;
        }

        public Employee(int id, string name) : this ()
        {
            Id = id;
            Name = name;
        }

        public Employee(int id, string name, double salary) : this(id, name)
        {
            Salary = salary;
        }

        public void increaseSalary(double percentage)
        {
            Salary *= (1 + percentage / 100);
        }

        public override string ToString()
        {
            return Id + ", " + Name + ", " + Salary.ToString("F2");
        }
    }
}
