namespace VData02.Categories
{
	using Bases;
	using Newtonsoft.Json;

	/// <summary>
	/// An element's Identity
	/// </summary>
	public interface IIdentity : ICategory
	{
		/// <summary>
		/// The <see cref="BaseName"/> name for this <see cref="BaseIdentity"/> object
		/// </summary>
		BaseName Name { get; }

		/// <summary>
		/// The <see cref="BaseKind"/> kind for this <see cref="BaseIdentity"/> object
		/// </summary>
		BaseKind Kind { get; }

		/// <summary>
		/// The <see cref="BaseID"/> ID for this <see cref="BaseIdentity"/> object
		/// </summary>
		BaseID ID { get; }
	}

	/// <summary>
	/// An element's Identity with a <typeparamref name="TKind"/> kind
	/// </summary>
	/// <typeparam name="TKind">A <see cref="Kinds"/> kind</typeparam>
	public interface IIdentity<TKind> : IIdentity where TKind : struct, Enum
	{
		/// <summary>
		/// The <see cref="BaseName{TKind}"/> name for this <see cref="BaseIdentity{TKind}"/> object
		/// </summary>
		new BaseName<TKind> Name { get; }

		/// <summary>
		/// The <see cref="BaseKind{TKind}"/> kind for this <see cref="BaseIdentity{TKind}"/> object
		/// </summary>
		new BaseKind<TKind> Kind { get; }

		/// <summary>
		/// The <see cref="BaseID{TKind}"/> ID for this <see cref="BaseIdentity{TKind}"/> object
		/// </summary>
		new BaseID<TKind> ID { get; }
	}
}
