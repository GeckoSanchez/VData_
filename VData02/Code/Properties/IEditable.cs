namespace VData02.Properties
{
	using Bases;
	using Categories;
	using Exceptions;

	public interface IEditable : IProperty
	{
		HashSet<IMoment> EMoments { get; }

		/// <summary>
		/// Function to change the current name for this <see cref="IEditable"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseName"/> data value</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="NameException"/>
		void Edit(BaseName value);

		/// <summary>
		/// Function to change the current name for this <see cref="IEditable"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseName"/> data value</param>
		/// <returns><see langword="true"/> if this operation succeeded, otherwise <see langword="false"/></returns>
		bool TryEdit(BaseName value);

		/// <summary>
		/// Function to change the current kind for this <see cref="IEditable"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseKind"/> data value</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="NameException"/>
		void Edit(BaseKind value);

		/// <summary>
		/// Function to change the current kind for this <see cref="IEditable"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseKind"/> data value</param>
		/// <returns><see langword="true"/> if this operation succeeded, otherwise <see langword="false"/></returns>
		bool TryEdit(BaseKind value);

		/// <summary>
		/// Function to change the current ID for this <see cref="IEditable"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseID"/> data value</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IDException"/>
		void Edit(BaseID value);

		/// <summary>
		/// Function to change the current ID's sub-ID for this <see cref="IEditable"/> element
		/// </summary>
		/// <param name="subID">The new <see cref="ulong"/> sub-ID for this <see cref="IEditable"/></param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IDException"/>
		void Edit(ulong subID);

		/// <summary>
		/// Function to try to change the current ID for this <see cref="IEditable"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseID"/> data value</param>
		/// <returns><see langword="true"/> if this operation succeeded, otherwise <see langword="false"/></returns>
		bool TryEdit(BaseID value);

		/// <summary>
		/// Function to try to change the current ID's sub-ID for this <see cref="IEditable"/> element
		/// </summary>
		/// <param name="subID">The new <see cref="ulong"/> sub-ID for this <see cref="IEditable"/></param>
		/// <returns><see langword="true"/> if this operation succeeded, otherwise <see langword="false"/></returns>
		bool TryEdit(ulong subID);
	}

	public interface IEditable<TKind> where TKind : struct, Enum
	{
		/// <summary>
		/// Function to change the current name for this <see cref="IEditable{TKind}"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseName{TKind}"/> data value</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="NameException"/>
		void Edit(BaseName<TKind> value);

		/// <summary>
		/// Function to change the current name for this <see cref="IEditable{TKind}"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseName{TKind}"/> data value</param>
		/// <returns><see langword="true"/> if this operation succeeded, otherwise <see langword="false"/></returns>
		bool TryEdit(BaseName<TKind> value);

		/// <summary>
		/// Function to change the current kind for this <see cref="IEditable{TKind}"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseKind{TKind}"/> data value</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="NameException"/>
		void Edit(BaseKind<TKind> value);

		/// <summary>
		/// Function to change the current kind for this <see cref="IEditable{TKind}"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseKind{TKind}"/> data value</param>
		/// <returns><see langword="true"/> if this operation succeeded, otherwise <see langword="false"/></returns>
		bool TryEdit(BaseKind<TKind> value);

		/// <summary>
		/// Function to change the current ID for this <see cref="IEditable{TKind}"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseID{TKind}"/> data value</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IDException"/>
		void Edit(BaseID<TKind> value);

		/// <summary>
		/// Function to change the current ID's sub-ID for this <see cref="IEditable{TKind}"/> element
		/// </summary>
		/// <param name="subID">The new <see cref="ulong"/> sub-ID for this <see cref="IEditable"/></param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IDException"/>
		void Edit(ulong subID);

		/// <summary>
		/// Function to try to change the current ID for this <see cref="IEditable{TKind}"/> element
		/// </summary>
		/// <param name="value">The new <see cref="BaseID{TKind}"/> data value</param>
		/// <returns><see langword="true"/> if this operation succeeded, otherwise <see langword="false"/></returns>
		bool TryEdit(BaseID<TKind> value);

		/// <summary>
		/// Function to try to change the current ID's sub-ID for this <see cref="IEditable{TKind}"/> element
		/// </summary>
		/// <param name="subID">The new <see cref="ulong"/> sub-ID for this <see cref="IEditable"/></param>
		/// <returns><see langword="true"/> if this operation succeeded, otherwise <see langword="false"/></returns>
		bool TryEdit(ulong subID);
	}
}
