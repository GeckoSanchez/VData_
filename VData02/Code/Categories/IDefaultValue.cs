namespace VData02.Categories
{
	public interface IDefaultValue<T> : ICategory where T : notnull, ICategory
	{
		/// <summary>
		/// A default <typeparamref name="T"/> data value
		/// </summary>
		static T Default { get; }
	}
}
