﻿using System;
using System.Globalization;
using System.Collections.Generic;

namespace PaymentContract.Entities
{
    class Installment
    {
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }

        public Installment() { }

        public Installment(DateTime dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }

        public override string ToString()
        {
            return DueDate.ToString("dd/MM/yyyy") + " - " + Amount.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}
