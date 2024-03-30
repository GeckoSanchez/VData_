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
	public class ObjectIdentity : BaseIdentity<ObjectKind>
	{
		/// <summary>
		/// Main constructor for the <see cref="ObjectIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="ObjectName"/> name</param>
		/// <param name="kind">A <see cref="ObjectKind"/> kind</param>
		/// <param name="id">A <see cref="ObjectID"/> ID</param>
		[JsonConstructor, MainConstructor]
		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectType kind, [NotNull] ObjectID id) : base(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
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

		public ObjectIdentity([NotNull] BaseIdentity identity) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(identity.Name.Data);
				Type = new((ObjectKind)identity.Type.Data);
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

		public ObjectIdentity([NotNull] BaseIdentity<ObjectKind> identity) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
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

		public ObjectIdentity([NotNull] BaseName name, [NotNull] ObjectType kind) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID(kind))
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

		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectType kind) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID(kind))
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

		public ObjectIdentity([NotNull] string name, [NotNull] ObjectType kind) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
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

		public ObjectIdentity([NotNull] string name, [NotNull] ObjectKind kind) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
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

		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectType kind, ulong subID) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
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

		public ObjectIdentity([NotNull] BaseName name, [NotNull] ObjectKind kind, ulong subID) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
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

		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectKind kind, ulong subID) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
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

		internal ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectType kind, [NotNull] BaseID<ObjectKind> id) : this(new ObjectName(Def.Name), new ObjectType(), new ObjectID())
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
