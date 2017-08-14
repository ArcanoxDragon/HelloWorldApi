using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldClient.Services
{
	public class ConsoleMessageService : IMessageService
	{
		#region Implementation of IMessageService

		public void HandleMessage( string message )
		{
			Console.WriteLine( $"The message was: {message}" );
		}

		public void HandleNonExistent( string messageName )
		{
			Console.WriteLine( "That message does not exist" );
		}

		#endregion
	}
}