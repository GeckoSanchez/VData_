namespace VData02.Properties
{
	using Bases;
	using Categories;

	public interface ILinkable : IProperty { }

	public interface ILinkable<TLinked> : IProperty where TLinked : ILinkable
	{
		HashSet<BaseID> LinkedIDs { get; }

		/// <summary>
		/// Function to link a <typeparamref name="TLinked"/> element to this <see cref="ILinkable{TLinked}"/> element
		/// </summary>
		/// <param name="elem"></param>
		void Link(TLinked elem);
		bool TryLink(TLinked elem);

		void Unlink(TLinked elem);
		bool TryUnlink(TLinked elem);
	}
}
