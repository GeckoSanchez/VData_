namespace VData02.Identities
{
	using System.Collections.Generic;
	using System.ComponentModel;
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
	public class DeviceIdentity : BaseIdentity<DeviceKind>, IEquatable<DeviceIdentity?>
	{
		/// <summary>
		/// The <see cref="DeviceName"/> name for this <see cref="DeviceIdentity"/> object
		/// </summary>
		[DefaultValue(Def.Name), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new DeviceName Name { get => (DeviceName)base.Name; protected set => base.Name = value; }

		/// <summary>
		/// The <see cref="DeviceType"/> type/kind for this <see cref="DeviceIdentity"/> object
		/// </summary>
		[JsonProperty]
		public new DeviceType Kind { get => (DeviceType)base.Kind; protected set => base.Kind = value; }

		/// <summary>
		/// The <see cref="DeviceID"/> ID for this <see cref="DeviceIdentity"/> object
		/// </summary>
		[JsonProperty]
		public new DeviceID ID { get => (DeviceID)base.ID; protected set => Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="DeviceIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="DeviceName"/> name object</param>
		/// <param name="kind">A <see cref="DeviceType"/> type object</param>
		/// <param name="id">A <see cref="DeviceID"/> ID object</param>
		[JsonConstructor, MainConstructor]
		protected DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceType kind, [NotNull] DeviceID id) : base(name, kind, id) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="DeviceIdentity"/> class
		/// </summary>
		/// <inheritdoc cref="DeviceIdentity(DeviceName,DeviceType,DeviceID)"/>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IdentityException"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceType kind, [NotNull] ulong subID) : this()
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
		/// <inheritdoc cref="DeviceIdentity(DeviceName,DeviceType,ulong)"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceType kind, [NotNull] long subID) : this()
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

		/// <param name="kind">A <see cref="DeviceKind"/> kind</param>
		/// <param name="id">A <see cref="DeviceID"/> ID</param>
		/// <inheritdoc cref="DeviceIdentity(DeviceName,DeviceType,ulong)"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceKind kind, [NotNull] DeviceID id) : this()
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
		/// <inheritdoc cref="DeviceIdentity(DeviceName,DeviceKind,DeviceID)"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceKind kind, [NotNull] ulong subID) : this()
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
		/// <inheritdoc cref="DeviceIdentity(DeviceName,DeviceKind,DeviceID)"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceKind kind, [NotNull] long subID) : this()
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
		/// <param name="id">A <see cref="DeviceID"/> ID object</param>
		/// <inheritdoc cref="DeviceIdentity(DeviceName,DeviceType,ulong)"/>
		public DeviceIdentity([NotNull] string name, [NotNull] DeviceType kind, [NotNull] DeviceID id) : this()
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
		/// <inheritdoc cref="DeviceIdentity(DeviceName,DeviceType,ulong)"/>
		public DeviceIdentity([NotNull] string name, [NotNull] DeviceType kind, [NotNull] ulong subID) : this()
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
		/// <inheritdoc cref="DeviceIdentity(DeviceName,DeviceType,long)"/>
		public DeviceIdentity([NotNull] string name, [NotNull] DeviceType kind, [NotNull] long subID) : this()
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

		/// <param name="kind">A <see cref="DeviceKind"/> kind</param>
		/// <inheritdoc cref="DeviceIdentity(string,DeviceType,DeviceID)"/>
		public DeviceIdentity([NotNull] string name, [NotNull] DeviceKind kind, [NotNull] DeviceID id) : this()
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
		/// <inheritdoc cref="DeviceIdentity(string,DeviceKind,DeviceID)"/>
		public DeviceIdentity([NotNull] string name, [NotNull] DeviceKind kind, [NotNull] ulong subID) : this()
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
		/// <inheritdoc cref="DeviceIdentity(string,DeviceKind,DeviceID)"/>
		public DeviceIdentity([NotNull] string name, [NotNull] DeviceKind kind, [NotNull] long subID) : this()
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
		/// Empty constructor for the <see cref="DeviceIdentity"/> class
		/// </summary>
		[EmptyConstructor]
		public DeviceIdentity() : this(new DeviceName(), new DeviceType(), new DeviceID()) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as DeviceIdentity);
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

		/// <inheritdoc cref="BaseIdentity{DeviceKind}.Equals(BaseIdentity{DeviceKind}?)"/>
		public bool Equals(DeviceIdentity? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
								 EqualityComparer<DeviceName>.Default.Equals(Name, other.Name) &&
								 EqualityComparer<DeviceType>.Default.Equals(Kind, other.Kind) &&
								 EqualityComparer<DeviceID>.Default.Equals(ID, other.ID);
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

		/// <inheritdoc cref="BaseIdentity{DeviceKind}.op_Equality"/>
		public static bool operator ==(DeviceIdentity? left, DeviceIdentity? right)
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

		/// <inheritdoc cref="BaseIdentity{DeviceKind}.op_Inequality"/>
		/// <exception cref="BaseException"/>
		public static bool operator !=(DeviceIdentity? left, DeviceIdentity? right)
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
