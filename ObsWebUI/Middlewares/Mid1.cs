using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace ObsWebUI.Middlewares
{
	public class Mid1
	{
		public static Task MyMiddleware1(HttpContext context) 
		{
			Debug.WriteLine(context.Request.HttpContext.User.Identity.IsAuthenticated);
			Debug.WriteLine(context.Request.Host.Value);
			Debug.WriteLine(context.Request.Path);
			return Task.CompletedTask;
		}
	}
}
