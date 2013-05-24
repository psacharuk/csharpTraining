using System;
using common;

namespace s2gr2
{
	class FancyMessageBoxService : IMessageBoxService
	{
		public void ShowMessage(string message, EMessageType type = EMessageType.Alert)
		{
			var frm = new MessageBoxForm(message, type);
			frm.ShowDialog();
		}

        public bool Confirm(string message)
        {
            throw new NotImplementedException();
            //using (var frm = new ConfirmFrame())
            //{

            //}
        }
    }
}