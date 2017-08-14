using HelloWorldApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
	[ Route( "api/[controller]" ) ]
	public class WriteController : Controller
	{
		private readonly IWriteService writeService;

		public WriteController( IWriteService writeService )
		{
			this.writeService = writeService;
		}

		// GET api/write/{message}
		[ HttpGet( "{message}" ) ]
		public ActionResult WriteMessage( string message )
		{
			return this.writeService.WriteMessage( message );
		}
	}
}