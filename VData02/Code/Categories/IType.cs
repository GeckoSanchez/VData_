namespace VData02.Categories
{
	public interface IType : ICategory
	{
		/// <summary>
		/// The base <see cref="Enum"/> data for the <see cref="IType"/> class
		/// </summary>
		Enum Data { get; }
	}

	public interface IType<TKind> : IType where TKind : struct, Enum
	{
		/// <summary>
		/// The base <typeparamref name="TKind"/> data for the <see cref="IType{TKind}"/> class
		/// </summary>
		new TKind Data { get; }
	}
}
