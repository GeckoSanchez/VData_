namespace VData02.Identities
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Bases;
	using Categories;
	using Exceptions;
	using IDs;
	using Kinds;
	using Names;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class ObjectIdentity : BaseIdentity<ObjectKind>, IEquatable<ObjectIdentity?>, IDefaultValue<ObjectIdentity>
	{
		/// <summary>
		/// The <see cref="ObjectName"/> name for this <see cref="ObjectIdentity"/> object
		/// </summary>
		[DefaultValue(Def.Name), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new ObjectName Name { get => (ObjectName)base.Name; protected set => base.Name = value; }

		/// <summary>
		/// The <see cref="ObjectType"/> type/kind for this <see cref="ObjectIdentity"/> object
		/// </summary>
		[JsonProperty]
		public new ObjectType Kind { get => (ObjectType)base.Kind; protected set => base.Kind = value; }

		/// <summary>
		/// The <see cref="ObjectID"/> ID for this <see cref="ObjectIdentity"/> object
		/// </summary>
		[JsonProperty]
		public new ObjectID ID { get => (ObjectID)base.ID; protected set => Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="ObjectIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="ObjectName"/> name object</param>
		/// <param name="kind">A <see cref="ObjectType"/> type object</param>
		/// <param name="id">A <see cref="ObjectID"/> ID object</param>
		[JsonConstructor, MainConstructor]
		internal ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectType kind, [NotNull] ObjectID id) : base(name, kind, id) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="ObjectIdentity"/> class
		/// </summary>
		/// <inheritdoc cref="ObjectIdentity(ObjectName,ObjectType,ObjectID)"/>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IdentityException"/>
		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectType kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="ObjectIdentity(ObjectName,ObjectType,ulong)"/>
		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectType kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="ObjectKind"/> kind</param>
		/// <param name="id">A <see cref="ObjectID"/> ID</param>
		/// <inheritdoc cref="ObjectIdentity(ObjectName,ObjectType,ulong)"/>
		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectKind kind, [NotNull] ObjectID id) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, id.GetSubID());
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="ObjectIdentity(ObjectName,ObjectKind,ObjectID)"/>
		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectKind kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, subID);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="ObjectIdentity(ObjectName,ObjectKind,ObjectID)"/>
		public ObjectIdentity([NotNull] ObjectName name, [NotNull] ObjectKind kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, subID);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="name">A <see cref="string"/> name value</param>
		/// <param name="id">A <see cref="ObjectID"/> ID object</param>
		/// <inheritdoc cref="ObjectIdentity(ObjectName,ObjectType,ulong)"/>
		public ObjectIdentity([NotNull] string name, [NotNull] ObjectType kind, [NotNull] ObjectID id) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				Kind = kind;
				ID = new(Kind, id.GetSubID());
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

		/// <param name="name">A <see cref="string"/> name value</param>
		/// <inheritdoc cref="ObjectIdentity(ObjectName,ObjectType,ulong)"/>
		public ObjectIdentity([NotNull] string name, [NotNull] ObjectType kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				Kind = kind;
				ID = new(Kind, subID);
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

		/// <param name="name">A <see cref="string"/> name value</param>
		/// <inheritdoc cref="ObjectIdentity(ObjectName,ObjectType,long)"/>
		public ObjectIdentity([NotNull] string name, [NotNull] ObjectType kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				Kind = kind;
				ID = new(Kind, subID);
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

		/// <param name="kind">A <see cref="ObjectKind"/> kind</param>
		/// <inheritdoc cref="ObjectIdentity(string,ObjectType,ObjectID)"/>
		public ObjectIdentity([NotNull] string name, [NotNull] ObjectKind kind, [NotNull] ObjectID id) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, id.GetSubID());
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

		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="ObjectIdentity(string,ObjectKind,ObjectID)"/>
		public ObjectIdentity([NotNull] string name, [NotNull] ObjectKind kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, subID);
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

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="ObjectIdentity(string,ObjectKind,ObjectID)"/>
		public ObjectIdentity([NotNull] string name, [NotNull] ObjectKind kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, subID);
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

		/// <summary>
		/// Empty constructor for the <see cref="ObjectIdentity"/> class
		/// </summary>
		[EmptyConstructor]
		public ObjectIdentity() : this(new ObjectName(), new ObjectType(), new ObjectID()) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as ObjectIdentity);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="BaseIdentity{ObjectKind}.Equals(BaseIdentity{ObjectKind}?)"/>
		public bool Equals(ObjectIdentity? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
								 EqualityComparer<ObjectName>.Default.Equals(Name, other.Name) &&
								 EqualityComparer<ObjectType>.Default.Equals(Kind, other.Kind) &&
								 EqualityComparer<ObjectID>.Default.Equals(ID, other.ID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		public override int GetHashCode()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = HashCode.Combine(Name, Name.GetHashCode(), Kind, Kind.GetHashCode(), ID, ID.GetHashCode(), base.GetHashCode());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Name} {Kind.ToString().ToLower()} (#{Data.ToString()[16..]})";
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
			finally
			{
				try
				{
					Out ??= base.ToString();
				}
				catch (Exception)
				{
					Out = "";
				}
			}

			return Out;
		}

		protected override void Dispose(bool disposing)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (disposing)
				{
					Name.Dispose();
					Kind.Dispose();
					ID.Dispose();
				}

				base.Dispose(disposing);
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

		public override string ToJSON(Formatting? formatting = null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = JsonConvert.SerializeObject(this, formatting ?? Def.JSONFormatting);
			}
			catch (JsonException)
			{
				throw new IdentityException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
			finally
			{
				try
				{
					Out ??= base.ToJSON(formatting);
				}
				catch (Exception)
				{
					Out = Def.JSON;
				}
			}

			return Out;
		}

		/// <inheritdoc cref="BaseIdentity{ObjectKind}.op_Equality"/>
		public static bool operator ==(ObjectIdentity? left, ObjectIdentity? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<BaseID>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="BaseIdentity{ObjectKind}.op_Inequality"/>
		/// <exception cref="BaseException"/>
		public static bool operator !=(ObjectIdentity? left, ObjectIdentity? right)
		{
			bool Out;

			try
			{
				Out = !(left == right);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
