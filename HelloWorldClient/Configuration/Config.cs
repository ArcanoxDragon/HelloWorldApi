using System.IO;
using Newtonsoft.Json;

namespace HelloWorldClient.Configuration
{
	public class Config
	{
		#region Static

		private static Config Singleton;
		public static Config Instance => Singleton ?? ( Singleton = Config.LoadConfig() );

		private static Config LoadConfig()
		{
			using ( var fs = File.Open( "Config.json", FileMode.Open, FileAccess.Read, FileShare.Read ) )
			using ( var sr = new StreamReader( fs ) )
			using ( var jr = new JsonTextReader( sr ) )
			{
				var json = new JsonSerializer();
				return json.Deserialize<Config>( jr );
			}
		}

		#endregion

		public string ServiceUrl { get; set; }
	}
}