namespace common
{
	public enum EMessageType { Alert, Error }

	public class PromptInfo
	{
		public PromptInfo(string message)
		{
			Message = message;
		}

		public string Message { get; set; }

		public string ReturnValue { get; set; }
	}

	public interface IMessageBoxService
	{
		void ShowMessage(string message, EMessageType type = EMessageType.Alert);
		bool Confirm(string message);
		bool Prompt(PromptInfo info);
	}
}