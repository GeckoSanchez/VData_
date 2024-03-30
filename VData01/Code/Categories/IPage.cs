namespace VData01.Categories
{
	using Identities;

	public interface IPage : ICategory
	{
		PageIdentity Identity { get; }
	}
}
