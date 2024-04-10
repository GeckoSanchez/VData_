namespace VData02.Properties
{
	using Bases;
	using Categories;
	using Exceptions;
	using Values;

	public interface IDeletable : IProperty
	{
		Moment? DMoment { get; }

		/// <summary>
		/// Function to delete an <c>*EXISTING*</c> save file for an <see cref="IDeletable"/> element
		/// </summary>
		/// <exception cref="BaseException"/>
		/// <exception cref="DeletionException"/>
		void Delete();

		/// <summary>
		/// Function to try to delete an <c>*EXISTING*</c> save file for an <see cref="IDeletable"/> element
		/// </summary>
		/// <returns><see langword="true"/> if the file was deleted, <see langword="false"/> otherwise</returns>
		bool TryDelete();
	}
}
