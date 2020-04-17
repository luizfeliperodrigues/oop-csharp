using System;

namespace Work.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract()
        {
            ValuePerHour = 0;
            Hours = 0;
        }

        public HourContract(DateTime date) : this()
        {
            Date = date;
        }

        public HourContract(DateTime date, double valuePerHour, int hours) : this(date)
        {
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }
    }
}
