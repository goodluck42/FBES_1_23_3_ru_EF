namespace EagerAndExplicitAndLazyLoading.Data.Configurations;

public abstract class Configuration<T>
	where T : new()
{
	private static T? _instance;
	public static T Instance => _instance ??= new T();
}