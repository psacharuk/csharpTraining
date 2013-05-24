namespace common
{
    public enum EMessageType { Alert, Error }
	public interface IMessageBoxService
	{
		void ShowMessage(string message, EMessageType type = EMessageType.Alert);
	}
}