namespace VData01.Categories
{
	using Identities;

	public interface IPlatform : ICategory
	{
		PlatformIdentity Identity { get; }
	}
}
