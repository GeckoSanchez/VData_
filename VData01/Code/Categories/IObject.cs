namespace VData01.Categories
{
	using Identities;
	using Properties;

	public interface IObject : ICategory, IActivatable, ICreatable, IDeletable, IInitializable, ILinkable, ISavable
	{
		ObjectIdentity Identity { get; }
	}

	public interface IObject<TLinked> : IObject, ILinkable<TLinked> where TLinked : ILinkable
	{
		new ObjectIdentity Identity { get; }
	}
}
