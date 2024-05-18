using Business.CommonServices.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AuthorizationServices.Abstract
{
	public interface IAuthService
	{
		Task<bool> SingInAsync(string email, string password);
		Task SingOutAsync();
	}
}
