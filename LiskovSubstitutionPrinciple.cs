using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SOLID
{
    /// <summary>
    /// "Objects of a superclass should be replaceable with objects of its subclasses without breaking the application."
    //If Class B inherits from Class A, you should be able to pass B into any method that expects A without getting weird errors or NotImplementedExceptions.
    /// </summary>
    internal class LiskovSubstitutionPrinciple
    {
        public class Bird { public virtual void Fly() { } }
        public class Ostrich : Bird
        {
            public override void Fly() => throw new Exception("Can't fly!");
        }
        // ADHERENCE: Better hierarchy.
        //public class Bird { /* General bird traits */ }
        public class FlyingBird : Bird { public new static void Fly() { } }
        public class Duck : FlyingBird { }
        //public class Ostrich : Bird { /* No Fly method here */ }
    }
}
