namespace Caching.Abstract;

public interface ICacheProvider 
{
	bool Any(string key);
	T? Get<T> (String  key);
	void Set<T> (String key, T value, TimeSpan expritation);	
	bool Remove (string key);
	
}