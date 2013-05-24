using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using common;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageBoxService svc = new ConsoleMessager();
            svc.ShowMessage("tralaa");
        }
    }

    class ConsoleMessager : IMessageBoxService
    {
        public void ShowMessage(string message, EMessageType type = EMessageType.Alert)
        {
            Console.WriteLine(message);
        }
    }
}
