using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.CommonServices.Abstract;
using Entities.CommonEntities;
using DataAccess.Dal.Abstract;
using Business.Services.Obs.Abstract;
using Caching.Abstract;
using Entities.ObsWebUI;
using DataAccess.Dal.Concrete;

namespace Business.CommonServices.Concrete
{
	public class UserService(IUserDal userDal, ICacheProvider cacheProvider) : IUserService
	{
		public string GetListKey { get; set; } = "";
		public bool Any(Expression<Func<User, bool>> filter)
		{
			//var data = GetListKey;
			return userDal.Any(filter);
		}

		public User Get(Expression<Func<User, bool>> filter)
		{
			return userDal.Get(filter);
		}

		public User Add(User entity)
		{
			cacheProvider.Remove(GetListKey);
			return userDal.Add(entity);
		}

		public User Update(User entity)
		{
			cacheProvider.Remove(GetListKey);
			return userDal.Update(entity);
		}

		public bool Remove(User entity)
		{
			cacheProvider.Remove(GetListKey);
			return userDal.Remove(entity);
		}

		public List<User> GetList(Expression<Func<User, bool>>? filter = null)
		{
			GetListKey = $"GetUserList";
			if (!cacheProvider.Any(GetListKey))
			{
				//Thread.Sleep(5000);
				var result = userDal.GetList(filter);
				cacheProvider.Set(GetListKey, result, TimeSpan.FromSeconds(6000));
				return result;
			}

			return cacheProvider.Get<List<User>>(GetListKey)!;
		}

		public User GetUserByEmailAndPassword(string email, string password)
		{
			return userDal.GetUserByEmailAndPassword(email, password);
		}

		public List<OperationClaim> GetUserOperationClaims(int userId)
		{
			return userDal.GetUserOperationClaims(userId);
		}
	}
}
