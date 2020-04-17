using System;
using System.Globalization;

namespace TaxCollector.Entities
{
    class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual() { }

        public Individual(string name, double annualIncome, double healthExpenditures) : base(name, annualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double TaxCalculator()
        {
            if(AnnualIncome < 20000)
            {
                return (AnnualIncome * 0.15 - HealthExpenditures * 0.5);
            }
            else
            {
                return (AnnualIncome * 0.25 - HealthExpenditures * 0.5);
            }
        }

        public override string ToString()
        {
            return $"{Name}: $ {TaxCalculator().ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
