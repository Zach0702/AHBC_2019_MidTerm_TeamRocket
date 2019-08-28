using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class Payment : IPaymentMethod
    {
        public double SubTotal { get; set; }
        public double SalesTaxTotal { get; set; }
        public double GrandTotal { get; set; }
        public object PaymentType { get; private set; }

        double taxRate = 0.06;

        public Payment(double calculatedSubTotal)
        {
            SubTotal = calculatedSubTotal;
        }

      

        private double CalculateTotalWithTax()
        {
            //sales tax total = subtotal * the taxrate of 6%
            SalesTaxTotal = SubTotal * taxRate;
            return SalesTaxTotal;
        }

        private double CalculateGrandTotal()
        {
            // grand total = subtotal + tax total
            GrandTotal = SubTotal + SalesTaxTotal;
            return GrandTotal;
        }

        public void MethodOfPayment()
        {
            Console.WriteLine("Please enter your desired method of payment");
            while (true)
            {
                PaymentType = paymentType;
                switch (paymentType)
                {
                    case 1:
                        PayCash();
                        return;

                    case 2:
                        PayCheck();
                        return;

                    case 3:
                        PayCreditCard();
                        return;

                    default:
                        Console.WriteLine("I'm sorry but we do not accept this form of payment.");
                        break;
                }

            }
        }

        //public double AddingTaxRate()
        //{
        //** if we decide to do non-taxable items.. maybe rename this method??
        //}
    }
}
