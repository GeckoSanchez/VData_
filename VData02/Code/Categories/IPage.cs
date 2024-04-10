namespace VData02.Categories
{
	using Kinds;

	public interface IPage : ICategory
	{
		public PageKind PageKind { get; }

		public Enum? ElemKind { get; }
		
		long? ID { get; }
	}
}
