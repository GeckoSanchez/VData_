namespace VData02.Categories
{
	public interface IIdentified : ICategory
	{
		//BaseIdentity Identity { get; }
	}

	public interface IIdentified<TKind> : IIdentified where TKind : struct, Enum
	{
		//new BaseIdentity<TKind> Identity { get; }
	}
}
