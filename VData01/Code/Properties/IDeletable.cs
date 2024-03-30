namespace VData01.Properties
{
	using Bases;
	using Categories;
	using Exceptions;

	public interface IDeletable : IProperty
	{
		DateTime? DMoment { get; }

		/// <summary>
		/// Function to delete an <c>*EXISTING*</c> save file for this <see cref="IDeletable"/> element
		/// </summary>
		/// <exception cref="BaseException"/>
		/// <exception cref="DeletionException"/>
		void Delete();
	}
}
