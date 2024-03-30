namespace VData01.Properties
{
	using Bases;
	using Categories;
	using Exceptions;

	public interface ILinkable : IProperty { }

	public interface ILinkable<TLinked> : ILinkable where TLinked : ILinkable
	{
		HashSet<BaseID> LinkedIDs { get; }

		/// <summary>
		/// Function to link a <typeparamref name="TLinked"/> element to this <see cref="ILinkable"/> element
		/// </summary>
		/// <param name="elem">
		/// A <typeparamref name="TLinked"/> element to be linked to this <see cref="ILinkable"/> element
		/// </param>
		/// <exception cref="LinkException"/>
		void Link(TLinked elem);

		/// <summary>
		/// Fonction to attempt to link a <typeparamref name="TLinked"/> element to this <see cref="ILinkable"/> element
		/// </summary>
		/// <param name="elem">
		/// A <typeparamref name="TLinked"/> element to be linked to this <see cref="ILinkable"/> element
		/// </param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="elem"/> could be linked to this <see cref="ILinkable"/> element.
		/// Otherwise, <see langword="false"/>
		/// </returns>
		bool TryLink(TLinked elem);

		/// <summary>
		/// Function to unlink a <typeparamref name="TLinked"/> element from this <see cref="ILinkable"/> element
		/// </summary>
		/// <param name="elem">
		/// A <typeparamref name="TLinked"/> element that will be unlinked from this <see cref="ILinkable"/> element
		/// </param>
		/// <exception cref="LinkException"/>
		void Unlink(TLinked elem);

		/// <summary>
		/// Fonction to attempt to unlink a <typeparamref name="TLinked"/> element from this <see cref="ILinkable"/> element
		/// </summary>
		/// <param name="elem">
		/// A <typeparamref name="TLinked"/> element that will be unlinked from this <see cref="ILinkable"/> element
		/// </param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="elem"/> could be unlinked from this <see cref="ILinkable"/> element.
		/// Otherwise, <see langword="false"/>
		/// </returns>
		bool TryUnlink(TLinked elem);
	}
}
