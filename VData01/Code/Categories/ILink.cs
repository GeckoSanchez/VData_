namespace VData01.Categories
{
	using Identities;

	public interface ILink : ICategory
	{
		LinkIdentity Identity { get; }
	}
}
