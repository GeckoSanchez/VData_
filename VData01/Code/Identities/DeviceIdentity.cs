namespace VData01.Identities
{
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
	public class DeviceIdentity : BaseIdentity<DeviceKind>
	{
		[DefaultValue(Def.Name)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new DeviceName Name { get => (DeviceName)base.Name; internal set => base.Name = value; }

		[JsonProperty]
		public new DeviceType Type { get => (DeviceType)base.Type; protected init => base.Type = value; }

		[DefaultValue(0UL)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new DeviceID ID { get => (DeviceID)Data; protected init => Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="DeviceIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="DeviceName"/> name</param>
		/// <param name="kind">A <see cref="DeviceKind"/> kind</param>
		/// <param name="id">A <see cref="DeviceID"/> ID</param>
		/// <exception cref="IdentityException"/>
		[JsonConstructor, MainConstructor]
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceType kind, [NotNull] DeviceID id) : base(new DeviceName(Def.Name), new DeviceType(), new DeviceID())
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

		/// <summary>
		/// Constructor for the <see cref="DeviceIdentity"/> class
		/// </summary>
		/// <param name="identity">A <see cref="BaseIdentity"/> identity</param>
		/// <exception cref="IdentityException"/>
		public DeviceIdentity([NotNull] BaseIdentity identity) : this(new DeviceName(Def.Name), new DeviceType(), new DeviceID())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(identity.Name.Data);
				Type = new((DeviceKind)identity.Type.Data);
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

		/// <param name="identity">A <see cref="DeviceIdentity"/> identity</param>
		/// <inheritdoc cref="DeviceIdentity(BaseIdentity)"/>
		public DeviceIdentity([NotNull] DeviceIdentity identity) : this(new DeviceName(Def.Name), new DeviceType(), new DeviceID())
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

		/// <param name="name">A <see cref="BaseName"/> name</param>
		/// <param name="type">A <see cref="DeviceType"/> type</param>
		/// <inheritdoc cref="DeviceIdentity(BaseIdentity)"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceType type) : this(new DeviceName(Def.Name), new DeviceType(), new DeviceID(type))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = name;
				Type = type;
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

		/// <param name="name">A <see cref="string"/> name</param>
		/// <param name="type">A <see cref="DeviceType"/> type</param>
		/// <inheritdoc cref="DeviceIdentity(BaseIdentity)"/>
		public DeviceIdentity([NotNull] string name, [NotNull] DeviceType kind) : this(new DeviceName(Def.Name), new DeviceType(), new DeviceID())
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

		/// <param name="name">A <see cref="string"/> name</param>
		/// <param name="type">A <see cref="DeviceKind"/> kind</param>
		/// <inheritdoc cref="DeviceIdentity(BaseIdentity)"/>
		public DeviceIdentity([NotNull] string name, [NotNull] DeviceKind kind) : this(new DeviceName(Def.Name), new DeviceType(), new DeviceID())
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

		/// <param name="name">A <see cref="DeviceName"/> name</param>
		/// <param name="type">A <see cref="DeviceType"/> type</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="DeviceIdentity(BaseIdentity)"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceType kind, ulong subID) : this(new DeviceName(Def.Name), new DeviceType(), new DeviceID())
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

		/// <param name="name">A <see cref="DeviceName"/> name</param>
		/// <param name="type">A <see cref="DeviceKind"/> type</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="DeviceIdentity(BaseIdentity)"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceKind kind, ulong subID) : this(new DeviceName(Def.Name), new DeviceType(), new DeviceID())
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

		/// <param name="name">A <see cref="DeviceName"/> name</param>
		/// <param name="type">A <see cref="DeviceKind"/> type</param>
		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="DeviceIdentity(BaseIdentity)"/>
		public DeviceIdentity([NotNull] DeviceName name, [NotNull] DeviceKind kind, long subID) : this(new DeviceName(Def.Name), new DeviceType(), new DeviceID())
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
	}
}
