namespace VData01.Properties
{
	using Exceptions;

	public interface ISavable
	{
		/// <summary>
		/// Function to save an <c>*EXISTING*</c> save file for the <see cref="ISavable"/> element
		/// </summary>
		/// <exception cref="SaveException"/>
		void Save();
	}
}
