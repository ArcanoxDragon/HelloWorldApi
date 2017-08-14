using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace HelloWorldApi.Tests
{
	public class WriteApiTests
	{
		private readonly HttpClient client;

		public WriteApiTests()
		{
			var builder = new WebHostBuilder()
				.UseContentRoot( Path.Combine( Directory.GetCurrentDirectory(), "../../../../HelloWorldApi" ) )
				 .UseStartup<Startup>();
			var server = new TestServer( builder );

			this.client = server.CreateClient();
		}

		[ Fact ]
		public async Task TestHelloRoute()
		{
			const string Message = "Hello World!";
			var res = await this.client.GetAsync( "/api/write/hello" );

			res.EnsureSuccessStatusCode();

			var str = await res.Content.ReadAsStringAsync();

			Assert.Equal( Message, str );
		}

		[ Fact ]
		public async Task TestGoodbyeRoute()
		{
			const string Message = "Goodbye World!";
			var res = await this.client.GetAsync( "/api/write/goodbye" );

			res.EnsureSuccessStatusCode();

			var str = await res.Content.ReadAsStringAsync();

			Assert.Equal( Message, str );
		}
	}
}