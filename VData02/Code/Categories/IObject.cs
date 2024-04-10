namespace VData02.Categories
{
	using Identities;

	public interface IObject : ICategory
	{
		/// <summary>
		/// An <see cref="ObjectIdentity"/> for this <see cref="IObject"/> element
		/// </summary>
		ObjectIdentity Identity { get; set; }
	}

	public interface IObject<TLinked> : IObject
	{
	}
}
