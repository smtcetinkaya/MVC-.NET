using Business.CommonServices.Abstract;
using Caching.Abstract;
using System.Linq.Expressions;
using Entities.CommonEntities;
using DataAccess.Dal.Concrete;
using DataAccess.Dal.Abstract;

namespace Business.CommonService.Concrete
{
	public class UserOperationClaimService(IUserOperationClaimDal userOperationClaimDal, ICacheProvider cacheProvider) : IUserOperationClaimService
	{
		public string GetListKey { get; set; } = "";
		public bool Any(Expression<Func<UserOperationClaim, bool>> filter)
		{
			//var data = GetListKey;
			return userOperationClaimDal.Any(filter);
		}

		public UserOperationClaim Get(Expression<Func<UserOperationClaim, bool>> filter)
		{
			return userOperationClaimDal.Get(filter);
		}

		public UserOperationClaim Add(UserOperationClaim entity)
		{
			cacheProvider.Remove(GetListKey);
			return userOperationClaimDal.Add(entity);
		}

		public UserOperationClaim Update(UserOperationClaim entity)
		{
			cacheProvider.Remove(GetListKey);
			return userOperationClaimDal.Update(entity);
		}

		public bool Remove(UserOperationClaim entity)
		{
			cacheProvider.Remove(GetListKey);
			return userOperationClaimDal.Remove(entity);
		}

		public List<UserOperationClaim> GetList(Expression<Func<UserOperationClaim, bool>>? filter = null)
		{
			GetListKey = $"GetUserOperationClaimList";
			if (!cacheProvider.Any(GetListKey))
			{
				//Thread.Sleep(5000);
				var result = userOperationClaimDal.GetList(filter);
				cacheProvider.Set(GetListKey, result, TimeSpan.FromSeconds(6000));
				return result;
			}

			return cacheProvider.Get<List<UserOperationClaim>>(GetListKey)!;
		}
	}
}
