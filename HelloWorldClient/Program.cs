using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HelloWorldClient.Configuration;
using HelloWorldClient.Services;
using Ninject;

namespace HelloWorldClient
{
	class Program
	{
		private static IReadOnlyKernel Kernel;

		private static void Main()
		{
			var kernelConfig = new KernelConfiguration();
			kernelConfig.Bind<IMessageService>().To<ConsoleMessageService>();

			Kernel = kernelConfig.BuildReadonlyKernel();

			Task.Run( MainAsync ).Wait();

			while ( Console.KeyAvailable )
				Console.ReadKey( true ); // clear buffer

			Console.WriteLine( "Press any key to continue" );
			Console.ReadKey( true );
		}

		private static async Task MainAsync()
		{
			var service = Kernel.Get<IMessageService>();
			var client = new HttpClient {
				BaseAddress = new Uri( Config.Instance.ServiceUrl )
			};

			Console.Write( "Enter a message name: " );

			var messageName = Console.ReadLine();
			var res = await client.GetAsync( $"/api/write/{messageName}" );

			if ( res.StatusCode == HttpStatusCode.NotFound )
			{
				service.HandleNonExistent( messageName );
			}
			else
			{
				res.EnsureSuccessStatusCode();

				var message = await res.Content.ReadAsStringAsync();

				service.HandleMessage( message );
			}
		}
	}
}