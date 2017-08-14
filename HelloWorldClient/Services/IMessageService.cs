namespace HelloWorldClient.Services
{
	public interface IMessageService
	{
		void HandleMessage( string message );
		void HandleNonExistent( string messageName );
	}
}