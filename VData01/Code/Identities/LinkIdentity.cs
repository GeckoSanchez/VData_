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
	public class LinkIdentity : BaseIdentity<LinkKind>
	{
		/// <summary>
		/// Main constructor for the <see cref="LinkIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="LinkName"/> name</param>
		/// <param name="kind">A <see cref="LinkKind"/> kind</param>
		/// <param name="id">A <see cref="LinkID"/> ID</param>
		[JsonConstructor, MainConstructor]
		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkType kind, [NotNull] LinkID id) : base(new LinkName(Def.Name), new LinkType(), new LinkID())
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

		public LinkIdentity([NotNull] BaseIdentity identity) : this(new LinkName(Def.Name), new LinkType(), new LinkID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(identity.Name.Data);
				Type = new((LinkKind)identity.Type.Data);
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

		public LinkIdentity([NotNull] BaseIdentity<LinkKind> identity) : this(new LinkName(Def.Name), new LinkType(), new LinkID())
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

		public LinkIdentity([NotNull] BaseName name, [NotNull] LinkType kind) : this(new LinkName(Def.Name), new LinkType(), new LinkID(kind))
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

		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkType kind) : this(new LinkName(Def.Name), new LinkType(), new LinkID(kind))
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

		public LinkIdentity([NotNull] string name, [NotNull] LinkType kind) : this(new LinkName(Def.Name), new LinkType(), new LinkID())
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

		public LinkIdentity([NotNull] string name, [NotNull] LinkKind kind) : this(new LinkName(Def.Name), new LinkType(), new LinkID())
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

		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkType kind, ulong subID) : this(new LinkName(Def.Name), new LinkType(), new LinkID())
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

		public LinkIdentity([NotNull] BaseName name, [NotNull] LinkKind kind, ulong subID) : this(new LinkName(Def.Name), new LinkType(), new LinkID())
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

		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkKind kind, ulong subID) : this(new LinkName(Def.Name), new LinkType(), new LinkID())
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

		internal LinkIdentity([NotNull] LinkName name, [NotNull] LinkType kind, [NotNull] BaseID<LinkKind> id) : this(new LinkName(Def.Name), new LinkType(), new LinkID())
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
