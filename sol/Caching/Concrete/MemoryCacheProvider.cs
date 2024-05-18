using Caching.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.Concrete
{
	public class MemoryCacheProvider(IMemoryCache memoryCache) : ICacheProvider
	{
		IMemoryCache _memoryCache = memoryCache;

		public bool Any(string key)
		{
			return  _memoryCache.Get(key) != null;
		}

		public T? Get<T>(string key)
		{
			return _memoryCache.Get<T>(key);
		}

		public void Set<T>(string key, T value, TimeSpan expritation)
		{
			_memoryCache.Set(key, value, expritation);
		}

		public bool Remove(string key)
		{
			_memoryCache.Remove(key);
			return true;
		}
	}
}
