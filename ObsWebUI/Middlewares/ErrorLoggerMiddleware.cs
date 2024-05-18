namespace ObsWebUI.Middlewares
{
	public class ErrorLoggerMiddleware(RequestDelegate next)
	{
		public async Task InvokeAsync(HttpContext context)
		{
			try 
			{
				await next(context);
			}
			catch (Exception e)
			{
				
					var logDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
					var logFilePath = Path.Combine(logDirectoryPath, "ErrorLogs.txt");

					if (!Directory.Exists(logDirectoryPath))
					{
						Directory.CreateDirectory(logDirectoryPath);
					}

					var formData = Environment.NewLine;

					if (context.Request.Method == "POST")
					{
						foreach (var key in context.Request.Form.Keys)
						{
							if (key != "__RequestVerificationToken")
							{
								formData += " Key: " + key + ", Data: " + context.Request.Form[key];
							}
						}
					}

				var log = $"Time: {DateTime.Now} Error: {e.Message}\nStackTrace: {e.StackTrace}\n";

					await File.AppendAllTextAsync(logFilePath, log);


					await next(context);

			}
			
		}
	}
}
