using Business.AuthorizationServices;
using Business.AuthorizationServices.Abstract;
using Business.AuthorizationServices.Concrete;
using Business.CommonService.Concrete;
using Business.CommonServices.Abstract;
using Business.CommonServices.Concrete;
using Business.Services.Obs.Abstract;
using Business.Services.Obs.Concrete;
using Caching.Abstract;
using Caching.Concrete;
using DataAccess.Dal.Abstract;
using DataAccess.Dal.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using ObsWebUI.Middlewares;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IFacultyDal, FacultyDal>();
builder.Services.AddSingleton<IDepartmentDal, DepartmentDal>();
builder.Services.AddSingleton<IFacultyService, FacultyService>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();

builder.Services.AddSingleton<IUserDal, UserDal>();
builder.Services.AddSingleton<IOperationClaimDal, OperationClaimDal>();
builder.Services.AddSingleton<IUserOperationClaimDal, UserOperationClaimDal>();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IOperationClaimService, OperationClaimService>();
builder.Services.AddSingleton<IUserOperationClaimService, UserOperationClaimService>();


builder.Services.AddSingleton<IAuthService, AuthService>();






builder.Services.AddMemoryCache();
//builder.Services.AddSingleton<ICacheProvider, RedisCacheProvider>();
builder.Services.AddSingleton<ICacheProvider, MemoryCacheProvider>();


var cookieOpetions = builder.Configuration.GetSection("CookieOptions").Get<CookieAuthOptions>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
{
	options.Cookie.Name = cookieOpetions!.Name;
	options.LoginPath= cookieOpetions.LoginPath;
	options.LogoutPath = cookieOpetions.LogoutPath;
	options.AccessDeniedPath= cookieOpetions.AccessDeniedPath;
	options.SlidingExpiration = cookieOpetions.SlidingExpiration;
	options.ExpireTimeSpan = TimeSpan.FromSeconds(cookieOpetions.TimeOut);



}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

//app.Run(async (contex) =>
//{
//	Debug.WriteLine(contex.Request.HttpContext.User.Identity.IsAuthenticated);
//	Debug.WriteLine(contex.Request.Host.Value);
//	Debug.WriteLine(contex.Request.Path);
//});

//app.Run(Mid1.MyMiddleware1);

//request ayný sýrada response tersten 
//app.Use(async (contex, next) =>
//{
//	Debug.WriteLine("M1-Request:"+contex.Request.Path);
//	next();
//	Debug.WriteLine("M1-Response:"+contex.Response.StatusCode);
//});
//app.Use(async (contex, next) =>
//{
//	Debug.WriteLine("M2-Request:" + contex.Request.Path);
//	next();
//	Debug.WriteLine("M2-Response:" + contex.Response.StatusCode);
//});
//app.Use(async (contex, next) =>
//{
//	Debug.WriteLine("M3-Request:" + contex.Request.Path);
//	next();
//	Debug.WriteLine("M3-Response:" + contex.Response.StatusCode);
//});
//app.Use(async (contex, next) =>
//{
//	Debug.WriteLine("M4-Request:" + contex.Request.Path);
//	next();
//	Debug.WriteLine("M4-Response:" + contex.Response.StatusCode);
//});

//app.UseMiddleware<IpLoggerMidlleware>();
//app.UseMiddleware<IpLoggerMidlleware>();



app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
