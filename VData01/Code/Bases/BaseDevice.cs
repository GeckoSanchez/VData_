namespace VData01.Bases
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Identities;
	using IDs;
	using Names;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseDevice : Base<DeviceIdentity>, IEquatable<BaseDevice?>, IDevice
	{
		[JsonProperty]
		public DeviceIdentity Identity { get; protected init; }

		[JsonProperty("Is active?")]
		public bool IsActive { get; protected set; }

		[JsonProperty("Init moment")]
		public DateTime InitMoment { get; protected init; }

		public DateTime? CMoment
		{
			get
			{
				DateTime? Out = null;
				string file = $"{Def.DevicesDir}/{Identity.Type}s/{$"{Identity.ID}"[16..]}.json";

				if (!File.Exists(file))
					Out = null;
				else
				{
					try
					{
						Out = new FileInfo(file).CreationTime;
					}
					catch (Exception ex)
					{
						Log.Exception(new BaseException(ex, new StackFrame(true)));
					}
				}

				return Out;
			}
		}

		[JsonProperty("Deletion moment", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? DMoment { get; protected set; }

		/// <summary>
		/// Main constructor for the <see cref="BaseDevice"/> class
		/// </summary>
		/// <param name="identity">A <see cref="DeviceIdentity"/> identity</param>
		/// <param name="isactive">A <see cref="bool"/> activity status</param>
		/// <param name="initmoment">A <see cref="DateTime"/> initialization moment</param>
		/// <param name="dmoment">A <see cref="DateTime"/><![CDATA[?]]> deletion moment</param>
		/// <exception cref="DeviceException"/>
		[JsonConstructor, MainConstructor]
		public BaseDevice(DeviceIdentity identity, bool isactive, DateTime initmoment, DateTime? dmoment = null) : base(identity)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = identity;
				IsActive = isactive;
				InitMoment = initmoment;
				DMoment = dmoment;
			}
			catch (Exception ex)
			{
				throw new DeviceException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseDevice"/> class
		/// </summary>
		/// <inheritdoc cref="BaseDevice(DeviceIdentity,bool,DateTime,DateTime?)"/>
		public BaseDevice(DeviceIdentity identity) : this(identity, true, DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = identity;
				IsActive = true;
				InitMoment = DateTime.Now;
				DMoment = null;
			}
			catch (Exception ex)
			{
				throw new DeviceException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseDevice(DeviceIdentity)"/>
		/// <param name="name">A <see cref="DeviceName"/> name</param>
		/// <param name="type">A <see cref="DeviceType"/> type</param>
		/// <param name="id">A <see cref="DeviceID"/> ID</param>
		/// <exception cref="DeviceException"/>
		public BaseDevice(DeviceName name, DeviceType type, DeviceID id) : this(new DeviceIdentity("", Def.DeviceKind), true, DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, type, id);
				InitMoment = DateTime.Now;
			}
			catch (Exception ex)
			{
				throw new DeviceException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseDevice(DeviceName,DeviceType,DeviceID)"/>
		public BaseDevice(DeviceName name, DeviceType type) : this(new DeviceIdentity("", Def.DeviceKind), true, DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, type);
				InitMoment = DateTime.Now;
			}
			catch (Exception ex)
			{
				throw new DeviceException(ex, sf);
			}
		}

		public void Activate()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (IsActive)
					throw new Exception($"The {Identity} could not be activated, since it was already active");
				else
					IsActive = true;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ActivationException(ex, sf);
			}
		}

		public void Deactivate()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!IsActive)
					throw new Exception($"The {Identity} could not be deactivated, since it was already inactive");
				else
					IsActive = false;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ActivationException(ex, sf);
			}
		}

		public void Create()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				string json = ToJSON();
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new CreationException(ex, sf);
			}
		}

		public void Delete()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{

			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DeletionException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{DeviceIdentity}.Equals(object?)"/>
		/// <exception cref="DeviceException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseDevice);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IEquatable{Base{DeviceIdentity}}.Equals(Base{DeviceIdentity}?)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="DeviceException"/>
		public bool Equals(BaseDevice? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
						 EqualityComparer<DeviceIdentity>.Default.Equals(Identity, other.Identity) &&
						 IsActive == other.IsActive && InitMoment == other.InitMoment &&
						 CMoment == other.CMoment && DMoment == other.DMoment;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DeviceException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DeviceIdentity}.GetHashCode"/>
		/// <exception cref="DeviceException"/>
		public override int GetHashCode()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = HashCode.Combine(base.GetHashCode(), Identity, Identity.GetHashCode(), IsActive, InitMoment, CMoment, DMoment);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DeviceException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DeviceIdentity}.ToJSON(Formatting?)"/>
		/// <exception cref="DeviceException"/>
		public override string ToJSON(Formatting? formatting = null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = JsonConvert.SerializeObject(this, formatting ?? Def.JSONFormatting);
			}
			catch (Exception ex)
			{
				throw new DeviceException(ex, sf);
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

		/// <inheritdoc cref="Base{DeviceIdentity}.ToString"/>
		/// <exception cref="DeviceException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Identity}";
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DeviceException(ex, sf);
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

		public static bool operator ==(BaseDevice? left, BaseDevice? right) => EqualityComparer<BaseDevice>.Default.Equals(left, right);
		public static bool operator !=(BaseDevice? left, BaseDevice? right) => !(left == right);
	}
}
