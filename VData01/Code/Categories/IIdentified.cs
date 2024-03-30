namespace VData01.Categories
{
	using Bases;

	public interface IIdentified : ICategory
	{
		BaseIdentity Identity { get; }
	}

	public interface IIdentified<TKind> : IIdentified where TKind : struct, Enum
	{
		new BaseIdentity<TKind> Identity { get; }
	}
}
