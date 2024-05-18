﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dal.Abstract;
using DataAccess.EfDbContext;
using Entities.ObsWebUI;

namespace DataAccess.Dal.Concrete
{
	public class FacultyDal :IFacultyDal
	{
		public bool Any(Expression<Func<Faculty, bool>> filter)
		{
			using (YtuSchoolDbContext context = new YtuSchoolDbContext())
			{
				return context.Faculties.Any(filter);
			}
		}

		public Faculty Get(Expression<Func<Faculty, bool>>filter)
		{
			using (YtuSchoolDbContext context = new YtuSchoolDbContext())
			{
				return context.Faculties.FirstOrDefault(filter);
			}
		}

		public Faculty Add(Faculty entity)
		{
			using (YtuSchoolDbContext context = new YtuSchoolDbContext())
			{
				context.Faculties.Add(entity);
				context.SaveChanges();
				return entity;
			}
		}

		public Faculty Update(Faculty entity)
		{
			using (YtuSchoolDbContext context = new YtuSchoolDbContext())
			{
				context.Faculties.Update(entity);
				context.SaveChanges();

				return entity;
			}
		}

		public bool Remove(Faculty entity)
		{
			using (YtuSchoolDbContext context = new YtuSchoolDbContext())
			{
				context.Faculties.Remove(entity);
				context.SaveChanges();
				return true;
			}
		}

		public List<Faculty> GetList(Expression<Func<Faculty, bool>> filter)
		{
			using (YtuSchoolDbContext context = new YtuSchoolDbContext())
			{
				if (filter == null)
				{
					return context.Faculties.ToList();
				}
				else
				{
					return context.Faculties.Where(filter).ToList();
				}
			}
		}
	}
}
