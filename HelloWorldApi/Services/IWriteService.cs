using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Services
{
	public interface IWriteService
	{
		ActionResult WriteMessage( string messageName );
	}
}