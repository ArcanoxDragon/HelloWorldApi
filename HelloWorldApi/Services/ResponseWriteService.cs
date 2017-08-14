using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HelloWorldApi.Services
{
	public class ResponseWriteService : IWriteService
	{
		private readonly IConfigurationRoot config;

		public ResponseWriteService( IConfigurationRoot configuration )
		{
			this.config = configuration;
		}

		#region Implementation of IWriteService

		public ActionResult WriteMessage( string messageName )
		{
			var message = this.config[ $"Services:Write:Messages:{messageName}" ];

			if ( string.IsNullOrEmpty( message ) )
				return new NotFoundResult();

			return new OkObjectResult( message );
		}

		#endregion
	}
}