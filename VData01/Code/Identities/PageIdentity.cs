namespace VData01.Identities
{
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using IDs;
	using Kinds;
	using Names;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class PageIdentity : BaseIdentity<PageKind>
	{
		/// <summary>
		/// Main constructor for the <see cref="PageIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="PageName"/> name</param>
		/// <param name="kind">A <see cref="PageKind"/> kind</param>
		/// <param name="id">A <see cref="PageID"/> ID</param>
		[JsonConstructor, MainConstructor]
		public PageIdentity([NotNull] PageName name, [NotNull] PageType kind, [NotNull] PageID id) : base(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind.Data);
				ID = new(Type.Data, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] BaseIdentity identity) : this(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(identity.Name.Data);
				Type = new((PageKind)identity.Type.Data);
				ID = new(Type.Data, identity.ID.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] BaseIdentity<PageKind> identity) : this(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(identity.Name.Data);
				Type = new(identity.Type.Data);
				ID = new(Type.Data, identity.ID.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] BaseName name, [NotNull] PageType kind) : this(new PageName(Def.Name), new PageType(), new PageID(kind))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data);
				Type = new(kind.Data);
				ID = new(Type.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] PageName name, [NotNull] PageType kind) : this(new PageName(Def.Name), new PageType(), new PageID(kind))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind.Data);
				ID = new(Type.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] string name, [NotNull] PageType kind) : this(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Type = new(kind.Data);
				ID = new(Type.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] string name, [NotNull] PageKind kind) : this(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Type = new(kind);
				ID = new(Type.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] PageName name, [NotNull] PageType kind, ulong subID) : this(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind.Data);
				ID = new(Type.Data, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] BaseName name, [NotNull] PageKind kind, ulong subID) : this(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind);
				ID = new(Type.Data, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public PageIdentity([NotNull] PageName name, [NotNull] PageKind kind, ulong subID) : this(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind);
				ID = new(Type.Data, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		internal PageIdentity([NotNull] PageName name, [NotNull] PageType kind, [NotNull] BaseID<PageKind> id) : this(new PageName(Def.Name), new PageType(), new PageID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind.Data);
				ID = new(Type.Data, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}
	}
}
