using System;
using System.Globalization;

namespace TaxCollector.Entities
{
    class Company : TaxPayer
    {
        public int NumberEmployees { get; set; }

        public Company() { }

        public Company(string name, double annualIncome, int numberEmployees) : base(name, annualIncome)
        {
            NumberEmployees = numberEmployees;
        }

        public override double TaxCalculator()
        {
            if (NumberEmployees <= 10)
            {
                return AnnualIncome * 0.16;
            }
            else
            {
                return AnnualIncome * 0.14;
            }
        }

        public override string ToString()
        {
            return $"{Name}: $ {TaxCalculator().ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
