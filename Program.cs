using System;
using System.Collections.Generic;
using static SOLID.OpenClosed_Principle;
using static SOLID.SingleResposibility;
using static SOLID.SingleResposibility.InvoiceGenerator;

class Program
{
    static void Main()
    {
        Console.WriteLine("Started!");
        //Console.ReadLine();

        // 1. Instantiate the dependencies
        var generator = new InvoiceGenerator();
        var repository = new InvoiceRepository();
        var emailSender = new InvoiceEmailSender();

        // 2. Inject them into the service
        var invoiceService = new InvoiceService(generator, repository, emailSender);

        // 3. Execute the logic
        invoiceService.ProcessInvoice();

        // Open Close


        PaymentProcessor paymentProcessor = new PaymentProcessor();

        IPaymentMethod creditCardPayment = new CreditCardPayment();
        IPaymentMethod paypalPayment = new PayPalPayment();
        IPaymentMethod bitcoinPayment = new BitcoinPayment();

        paymentProcessor.ProcessPayment(new CreditCardPayment());
        paymentProcessor.ProcessPayment(new PayPalPayment());
        paymentProcessor.ProcessPayment(new BitcoinPayment());

        Console.ReadKey();

    }
}