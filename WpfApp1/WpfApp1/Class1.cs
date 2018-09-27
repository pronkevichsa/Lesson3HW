using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Class1
    {
        private decimal summa;
        private decimal percent;
        
        // private decimal everyMonthPayment;
        // private decimal totalSummaPayment;
        // private float finalMonthfloat;

        public Class1()
        {
            summa = 100;
            percent = 10;
        }
        public Class1(decimal summaInput, decimal percentInput )
        {
            summa = summaInput;
            percent = percentInput;
        }

        public decimal Summa
        {
            get
            {
                return Summa;
            }
            set
            {
                summa = value;
            }
        }
        public decimal Percent
        {
            get
            {
                return percent;
            }
            set
            {
                percent = value;
            }
        }

        public decimal[] MonthPaymentCalc()
        {
           // decimal totalSummaPayment = summa * percent / 100 + summa;
            decimal everyMonthPayment = (summa * percent / 100 + summa) / 12; 
            
            float everyMonthPaymentfloat = (float)Math.Round(Convert.ToDouble(everyMonthPayment), 2);
            decimal lastMonth = (summa * percent / 100 + summa) - (decimal)everyMonthPaymentfloat * 11;
            decimal[] payment = new decimal[12];
            for (int i = 0; i < 11; i++)
                payment[i] = (decimal)everyMonthPaymentfloat;
            payment[11] = lastMonth;
            return payment;
        }

        
    }
}
