using System;
using System.Collections.Generic;
using static SOLID.InterfaceSegregationPrinciple_ISP;
using static SOLID.OpenClosed_Principle;
using static SOLID.SingleResposibility;
using static SOLID.SingleResposibility.InvoiceGenerator;

class Program
{
    static void Main()
    {
        Console.WriteLine("Started!");
        //Console.ReadLine();
        // SIngle responcobility principle
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

        //Console.ReadKey();


        Console.WriteLine("=== ISP Demo ===\n");
        HumanWorker human = new HumanWorker();
        RobotWorker robot = new RobotWorker();

        Console.WriteLine("Human:");
        human.Work();
        human.Eat();

        Console.WriteLine("\nRobot:");
        robot.Work();

        // robot.Eat();   // This won't compile - Good! Robot shouldn't eat.
        Console.ReadKey();

    }
}