using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Services.Obs.Abstract;
using Caching.Abstract;
using DataAccess.Dal.Abstract;
using Entities.ObsWebUI;

namespace Business.Services.Obs.Concrete
{
	public class FacultyService(IFacultyDal facultyDal, ICacheProvider cacheProvider) : IFacultyService
	{
		public string GetListKey { get; set; } = "";
		public bool Any(Expression<Func<Faculty, bool>> filter)
		{
			//var data = GetListKey;
			 return facultyDal.Any(filter);
		 }

		public Faculty Get(Expression<Func<Faculty, bool>> filter)
		{
			return facultyDal.Get(filter);
		}

		public Faculty Add(Faculty entity)
		{
			cacheProvider.Remove(GetListKey);
			return facultyDal.Add(entity);
		}

		public Faculty Update(Faculty entity)
		{
			cacheProvider.Remove(GetListKey);
			return facultyDal.Update(entity);
		}

		public bool Remove(Faculty entity)
		{
			cacheProvider.Remove(GetListKey);
			return facultyDal.Remove(entity);
		}

		public List<Faculty> GetList(Expression<Func<Faculty, bool>>? filter = null)
		{
			GetListKey = $"GetFacultyList";
			if (!cacheProvider.Any(GetListKey))
			{
				//Thread.Sleep(5000);
				var result = facultyDal.GetList(filter);
				cacheProvider.Set(GetListKey,result,TimeSpan.FromSeconds(6000));
				return result;
			}

			return cacheProvider.Get<List<Faculty>>(GetListKey)!;
		}
	}
}
