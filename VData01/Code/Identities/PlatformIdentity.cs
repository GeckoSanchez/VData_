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
	public class PlatformIdentity : BaseIdentity<PlatformKind>
	{
		/// <summary>
		/// Main constructor for the <see cref="PlatformIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="PlatformName"/> name</param>
		/// <param name="kind">A <see cref="PlatformKind"/> kind</param>
		/// <param name="id">A <see cref="PlatformID"/> ID</param>
		[JsonConstructor, MainConstructor]
		public PlatformIdentity([NotNull] PlatformName name, [NotNull] PlatformType kind, [NotNull] PlatformID id) : base(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
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

		public PlatformIdentity([NotNull] BaseIdentity identity) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(identity.Name.Data);
				Type = new((PlatformKind)identity.Type.Data);
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

		public PlatformIdentity([NotNull] BaseIdentity<PlatformKind> identity) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
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

		public PlatformIdentity([NotNull] BaseName name, [NotNull] PlatformType kind) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID(kind))
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

		public PlatformIdentity([NotNull] PlatformName name, [NotNull] PlatformType kind) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID(kind))
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

		public PlatformIdentity([NotNull] string name, [NotNull] PlatformType kind) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
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

		public PlatformIdentity([NotNull] string name, [NotNull] PlatformKind kind) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
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

		public PlatformIdentity([NotNull] PlatformName name, [NotNull] PlatformType kind, ulong subID) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
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

		public PlatformIdentity([NotNull] BaseName name, [NotNull] PlatformKind kind, ulong subID) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
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

		public PlatformIdentity([NotNull] PlatformName name, [NotNull] PlatformKind kind, ulong subID) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
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

		internal PlatformIdentity([NotNull] PlatformName name, [NotNull] PlatformType kind, [NotNull] BaseID<PlatformKind> id) : this(new PlatformName(Def.Name), new PlatformType(), new PlatformID())
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
