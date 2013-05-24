using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using common;

namespace console1
{
	class Program
	{
		static void Main(string[] args)
		{
			IMessageBoxService svc = new ConsoleMessager();
			svc.ShowMessage("tralala");

			EMessageType type = EMessageType.Error;
		}
	}

	class ConsoleMessager : IMessageBoxService
	{
		public void ShowMessage(string message, EMessageType type = EMessageType.Alert)
		{
			Console.WriteLine(string.Format("{0} {1}", message, type.ToString()));
		}


        public bool Confirm(string message)
        {
            return false;
        }
    }
}
