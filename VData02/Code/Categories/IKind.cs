namespace VData02.Categories
{
	internal interface IKind : ICategory
	{
		Enum Data { get; }
	}

	internal interface IKind<TKind> : IKind where TKind : struct, Enum
	{
		new TKind Data { get; }
	}
}