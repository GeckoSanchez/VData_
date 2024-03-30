namespace VData01.Categories
{
	using Bases;
	using Newtonsoft.Json;

	/// <summary>
	/// An element's Identity
	/// </summary>
	public interface IIdentity : ICategory
	{
		/// <summary>
		/// The <see cref="BaseName"/> name for this <see cref="IIdentity"/>
		/// </summary>
		[JsonProperty]
		BaseName Name { get; }

		/// <summary>
		/// The <see cref="BaseType"/> kind for this <see cref="IIdentity"/>
		/// </summary>
		[JsonProperty]
		BaseType Type { get; }

		/// <summary>
		/// The <see cref="BaseID"/> ID for this <see cref="IIdentity"/>
		/// </summary>
		[JsonProperty]
		BaseID ID { get; }
	}

	/// <summary>
	/// An element's Identity for a <typeparamref name="TKind"/> kind
	/// </summary>
	/// <typeparam name="TKind">A <see cref="Kinds"/></typeparam>
	public interface IIdentity<TKind> : IIdentity where TKind : struct, Enum
	{
		/// <summary>
		/// The <see cref="BaseName{TKind}"/> name for this <see cref="IIdentity{TKind}"/>
		/// </summary>
		[JsonProperty]
		new BaseName<TKind> Name { get; }

		/// <summary>
		/// The <see cref="BaseType{TKind}"/> kind for this <see cref="IIdentity{TKind}"/>
		/// </summary>
		[JsonProperty]
		new BaseType<TKind> Type { get; }

		/// <summary>
		/// The <see cref="BaseID{TKind}"/> ID for this <see cref="IIdentity{TKind}"/>
		/// </summary>
		[JsonProperty]
		new BaseID<TKind> ID { get; }
	}
}
