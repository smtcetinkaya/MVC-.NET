namespace ObsWebUI.Middlewares
{
	public class IpLoggerMidlleware
	{
		private readonly RequestDelegate _next;

		public IpLoggerMidlleware(RequestDelegate next) 
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context) 
		{
			var IpAdress = context.Request.Host.Value;

			var ipLogDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
			var ipLogFilePath = Path.Combine(ipLogDirectoryPath, "IpLogs.txt");
			if (!Directory.Exists(ipLogDirectoryPath)) 
			{
				Directory.CreateDirectory(ipLogDirectoryPath);
			}
			var log = $"{DateTime.Now} Ip:{context.Request.Host.Value} {Environment.NewLine}";	
			File.AppendAllText(ipLogFilePath,log);
			await _next(context);

		}

	}
}
