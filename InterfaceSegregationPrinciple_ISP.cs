using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    internal class InterfaceSegregationPrinciple_ISP
    {
        // VIOLATION: A RobotWorker shouldn't have to implement 'Eat'.
        public interface IWorker
        {
            void Work();
            void Eat();
        }
        // ADHERENCE: Split the interface.
        public interface IWorkable { void Work(); }
        public interface IEatable { void Eat(); }

        public class HumanWorker : IWorkable, IEatable
        {
            public void Work() => Console.WriteLine("Working...");
            public void Eat() => Console.WriteLine("Eating lunch...");
        }

        public class RobotWorker : IWorkable
        {
            public void Work() => Console.WriteLine("Robot working 24/7...");
        }
    }
}
