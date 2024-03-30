namespace VData01.Properties
{
	using Bases;
	using Exceptions;

	public interface ICreatable
	{
		DateTime? CMoment { get; }

		/// <summary>
		/// Function to create a <c>*NEW*</c> save file for this <see cref="ICreatable"/> element
		/// </summary>
		/// <exception cref="BaseException"/>
		/// <exception cref="CreationException"/>
		void Create();
	}
}
