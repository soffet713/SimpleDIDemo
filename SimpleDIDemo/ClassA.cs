using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDIDemo
{
    internal class ClassA : IInterfaceA
    {
        public void doA()
        {
            Console.WriteLine("Do A");
        }
        
    }
}
