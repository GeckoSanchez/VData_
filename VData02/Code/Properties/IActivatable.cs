namespace VData02.Properties
{
	using Categories;
	using Exceptions;

	public interface IActivatable : IProperty
	{
		/// <summary>
		/// Whether this <see cref="IActivatable"/> element is active (<see langword="true"/>),
		/// or inactive (<see langword="false"/>)
		/// </summary>
		bool IsActive { get; }

		/// <summary>
		/// Function to activte this <see cref="IActivatable"/> element
		/// </summary>
		/// <exception cref="ActivationException"/>
		void Activate();

		/// <summary>
		/// Function to deactivte this <see cref="IActivatable"/> element
		/// </summary>
		/// <exception cref="ActivationException"/>
		void Deactivate();
	}
}
