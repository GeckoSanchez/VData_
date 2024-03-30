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
	public class DataIdentity : BaseIdentity<DataKind>
	{
		/// <summary>
		/// Main constructor for the <see cref="DataIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="DataName"/> name</param>
		/// <param name="kind">A <see cref="DataKind"/> kind</param>
		/// <param name="id">A <see cref="DataID"/> ID</param>
		[JsonConstructor, MainConstructor]
		public DataIdentity([NotNull] DataName name, [NotNull] DataType kind, [NotNull] DataID id) : base(new DataName(Def.Name), new DataType(), new DataID())
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

		public DataIdentity([NotNull] BaseIdentity identity) : this(new DataName(Def.Name), new DataType(), new DataID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(identity.Name.Data);
				Type = new((DataKind)identity.Type.Data);
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

		public DataIdentity([NotNull] BaseIdentity<DataKind> identity) : this(new DataName(Def.Name), new DataType(), new DataID())
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

		public DataIdentity([NotNull] BaseName name, [NotNull] DataType kind) : this(new DataName(Def.Name), new DataType(), new DataID(kind))
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

		public DataIdentity([NotNull] DataName name, [NotNull] DataType kind) : this(new DataName(Def.Name), new DataType(), new DataID(kind))
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

		public DataIdentity([NotNull] string name, [NotNull] DataType kind) : this(new DataName(Def.Name), new DataType(), new DataID())
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

		public DataIdentity([NotNull] string name, [NotNull] DataKind kind) : this(new DataName(Def.Name), new DataType(), new DataID())
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

		public DataIdentity([NotNull] DataName name, [NotNull] DataType kind, ulong subID) : this(new DataName(Def.Name), new DataType(), new DataID())
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

		public DataIdentity([NotNull] BaseName name, [NotNull] DataKind kind, ulong subID) : this(new DataName(Def.Name), new DataType(), new DataID())
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

		public DataIdentity([NotNull] DataName name, [NotNull] DataKind kind, ulong subID) : this(new DataName(Def.Name), new DataType(), new DataID())
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

		internal DataIdentity([NotNull] DataName name, [NotNull] DataType kind, [NotNull] BaseID<DataKind> id) : this(new DataName(Def.Name), new DataType(), new DataID())
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
