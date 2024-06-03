using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDIDemo
{
    internal class ClassB : IInterfaceB
    {
        private IInterfaceA _classA;

        public ClassB(IInterfaceA classA)
        {
            _classA = classA;
        }
        
        public void doB()
        {
            _classA.doA();
            Console.WriteLine("Do B");
        }
    }
}
