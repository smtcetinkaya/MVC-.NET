﻿using DataAccess.Dal.CommonOperations;
using Entities.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal.Abstract
{
	public interface IUserDal : ICommonDal<User>
	{
		//...special methods for User.

		User GetUserByEmailAndPassword(string email, string password);
		List<OperationClaim> GetUserOperationClaims(int userId);
	}
}
