namespace VData01.Properties
{
	using Bases;
	using Exceptions;

	public interface IActivatable
	{
		bool IsActive { get; }

		/// <summary>
		/// Function to activate this <see cref="IActivatable"/> element
		/// </summary>
		/// <exception cref="BaseException"/>
		/// <exception cref="ActivationException"/>
		void Activate();

		/// <summary>
		/// Function to deactivate this <see cref="IActivatable"/> element
		/// </summary>
		/// <exception cref="BaseException"/>
		/// <exception cref="ActivationException"/>
		void Deactivate();
	}
}
