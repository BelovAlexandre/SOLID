using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    internal class OpenClosed_Principle
    {
        //Refactoring to Follow the Open-Closed Principle:
        // Step 1: Define an Interface:
        public interface IPaymentMethod
        {
            void Pay(decimal amount);
        }

        public class CreditCardPayment : IPaymentMethod
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paid ${amount} using Credit Card.");
            }
        }

        public class PayPalPayment : IPaymentMethod
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paid ${amount} using PayPal.");
            }
        }

        public class BitcoinPayment : IPaymentMethod
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paid ${amount} using Bitcoin.");
            }
        }

        public class PaymentProcessor
        {
            public void ProcessPayment(IPaymentMethod paymentMethod)
            {
                // You can add common logic here (validation, logging, etc.)
                Console.WriteLine("Processing payment...");
                paymentMethod.Pay(99.99m);
                Console.WriteLine("Payment completed.\n");
            }
        }

        //class Program


        //Bad Code ❌
        /// <summary>
        /// While this code works, it violates OCP because every time we add a new payment
        /// method (like GooglePay or ApplePay), we’ll have to modify the ProcessPayment method. T
        /// his approach is error-prone and can lead to fragile code as the application grows.
        /// </summary>
        public class BadPaymentProcessor
        {
            public void ProcessPayment(string paymentMethod)
            {
                if (paymentMethod == "CreditCard")
                {
                    // Process credit card payment
                    Console.WriteLine("Processing credit card payment...");
                }
                else if (paymentMethod == "PayPal")
                {
                    // Process PayPal payment
                    Console.WriteLine("Processing PayPal payment...");
                }
                else if (paymentMethod == "Bitcoin")
                {
                    // Process Bitcoin payment
                    Console.WriteLine("Processing Bitcoin payment...");
                }
                else
                {
                    throw new ArgumentException("Invalid payment method.");
                }
            }
        }


    }
    }

