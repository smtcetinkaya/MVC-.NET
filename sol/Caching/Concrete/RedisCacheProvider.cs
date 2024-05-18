using Caching.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching.Concrete
{
	internal class RedisCacheProvider : ICacheProvider
	{
		private IDatabase _database;

		public RedisCacheProvider() 
		{ 
			_database= ConnectionMultiplexer.Connect("localhost:6379").GetDatabase(0);
		}
		public bool Any(string key)
		{
			return _database.KeyExists(key);
		}

		public T? Get<T>(string key)
		{
			var result = _database.StringGet(key);
			var deserialize = JsonConvert.DeserializeObject<T>(result);
			return deserialize;
		}

		public bool Remove(string key)
		{
			return _database.KeyDelete(key);
		}

		public void Set<T>(string key, T value, TimeSpan expritation)
		{
			var result = JsonConvert.SerializeObject(value);
			_database.StringSet(key,result,expritation);
			var deserialize = JsonConvert.DeserializeObject<T>(result);
		}
	}
}
