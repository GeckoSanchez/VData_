namespace VData01.Categories
{
	using Identities;

	public interface IData : ICategory
	{
		DataIdentity Identity { get; }
	}
}
