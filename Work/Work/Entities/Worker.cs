using System;
using System.Collections.Generic;
using Work.Entities.Enums;

namespace Work.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name) : this()
        {
            Name = name;
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) : this (name)
        {
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            if(Contracts.Count > 0)
            {
                Contracts.Remove(contract);
            }
            
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            foreach (HourContract c in Contracts)
            {
                if(c.Date.Month == month && c.Date.Year == year)
                {
                    sum += c.TotalValue();
                }
            }

            return sum;
        }

        public override string ToString()
        {
            return "Name: "
                + Name
                + "Departament: "
                + "Income: ";
                //+ income(;
        }

    }
}
