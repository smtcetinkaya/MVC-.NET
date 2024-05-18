using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.CommonServices.Abstract;
using Business.Services.Obs.Abstract;
using Caching.Abstract;
using DataAccess.Dal.Abstract;
using DataAccess.Dal.Concrete;
using Entities.CommonEntities;
using Entities.ObsWebUI;

namespace Business.CommonServices.Concrete
{
	public class OperationClaimService(IOperationClaimDal operationClaimDal, ICacheProvider cacheProvider) : IOperationClaimService
	{
		public string GetListKey { get; set; } = "";
		public bool Any(Expression<Func<OperationClaim, bool>> filter)
		{
			//var data = GetListKey;
			return operationClaimDal.Any(filter);
		}

		public OperationClaim Get(Expression<Func<OperationClaim, bool>> filter)
		{
			return operationClaimDal.Get(filter);
		}

		public OperationClaim Add(OperationClaim entity)
		{
			cacheProvider.Remove(GetListKey);
			return operationClaimDal.Add(entity);
		}

		public OperationClaim Update(OperationClaim entity)
		{
			cacheProvider.Remove(GetListKey);
			return operationClaimDal.Update(entity);
		}

		public bool Remove(OperationClaim entity)
		{
			cacheProvider.Remove(GetListKey);
			return operationClaimDal.Remove(entity);
		}

		public List<OperationClaim> GetList(Expression<Func<OperationClaim, bool>>? filter = null)
		{
			GetListKey = $"GetOperationClaimList";
			if (!cacheProvider.Any(GetListKey))
			{
				//Thread.Sleep(5000);
				var result = operationClaimDal.GetList(filter);
				cacheProvider.Set(GetListKey, result, TimeSpan.FromSeconds(6000));
				return result;
			}

			return cacheProvider.Get<List<OperationClaim>>(GetListKey)!;
		}
	}
}
