using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class Cash : IPaymentMethod
    {
        private void Pay()
        {
            double cashGiven, amountTendered, totalOrderAmount;
            cashGiven = CashReceived();
            Console.WriteLine("");
            while (cashGiven < totalOrderAmount)
            {
                Console.WriteLine("I apologize, however the funds provided are insufficient.");
            }
            if (cashGiven >= totalOrderAmount)
            {
                amountTendered = cashGiven - totalOrderAmount;
                Console.WriteLine($"Total Change: " + amountTendered);
                Console.ReadKey();
            }
        }

        private double CashReceived()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double cashResult)
                {
                    return cashResult;
                }
                Console.WriteLine("Input Error. Please try again: ");
            }
        }

        public void Pay(string total)
        {

        }


    }
}
    

    
    


