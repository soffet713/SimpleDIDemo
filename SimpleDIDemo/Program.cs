using System;

namespace CustomDIDemo 
{
    class Program
    {
        static void Main(string[] args)
        {
            DiContainer container = new DiContainer();
            container.Register<IInterfaceA, ClassA>();
            container.Register<IInterfaceB, ClassB>();
            IInterfaceB classB = container.Resolve<IInterfaceB>();
            classB.doB();
            Console.ReadKey();
        }
    }
}
