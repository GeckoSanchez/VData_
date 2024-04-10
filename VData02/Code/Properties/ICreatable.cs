namespace VData02.Properties
{
	using Bases;
	using Categories;
	using Exceptions;
	using Values;

	public interface ICreatable : IProperty
	{
		Moment? CMoment { get; }

		/// <summary>
		/// Function to create a save file for a <c>*NEW*</c> <see cref="ICreatable"/> element
		/// </summary>
		/// <exception cref="BaseException"/>
		/// <exception cref="CreationException"/>
		void Create();

		/// <summary>
		/// Function to try to create a save file for a <c>*NEW*</c> <see cref="ICreatable"/> element
		/// </summary>
		/// <returns><see langword="true"/> if the file was created, <see langword="false"/> otherwise</returns>
		bool TryCreate();
	}
}
