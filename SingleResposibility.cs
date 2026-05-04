using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using static SOLID.SingleResposibility;
using static SOLID.SingleResposibility.InvoiceGenerator;

namespace SOLID
{
    public class SingleResposibility
    {
        // VIOLATION: This class does too much.
        public class Invoice
        {
            public void GenerateInvoice()
            {
                // Code to generate the invoice
            }

            public void SaveToDatabase()
            {
                // Code to save invoice data to the database
            }

            public void SendEmail()
            {
                // Code to send the invoice via email
            }
        }
        //Good Code ✅
        // Step 1: Separate the Responsibilities
        public class InvoiceGenerator
        {
            public void GenerateInvoice()
            {
                // Code to generate the invoice
                Console.WriteLine("Generate Invoice!");
                //Console.ReadLine();
            }
            public class InvoiceRepository
            {
                public void SaveToDatabase()
                {
                    // Code to save invoice data to the database
                    Console.WriteLine("Save Invoice To Database!");
                    //Console.ReadLine();
                }
            }
            public class InvoiceEmailSender
            {
                public void SendEmail()
                {
                    // Code to send the invoice via email
                    Console.WriteLine("Email Sent!");
                    //Console.ReadLine();
                }
            }



        }


        //Step 2: Coordinating with a Higher-Level Class
        public class InvoiceService
        {
            private readonly InvoiceGenerator _invoiceGenerator;
            private readonly InvoiceRepository _invoiceRepository;
            private readonly InvoiceEmailSender _invoiceEmailSender;

            public InvoiceService(
                InvoiceGenerator invoiceGenerator,
                InvoiceRepository invoiceRepository,
                InvoiceEmailSender invoiceEmailSender)
            {
                _invoiceGenerator = invoiceGenerator;
                _invoiceRepository = invoiceRepository;
                _invoiceEmailSender = invoiceEmailSender;
            }

            public void ProcessInvoice()
            {
                _invoiceGenerator.GenerateInvoice();
                _invoiceRepository.SaveToDatabase();
                _invoiceEmailSender.SendEmail();
            }
        }
    }
   

}
