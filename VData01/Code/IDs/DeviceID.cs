namespace VData01.IDs
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class DeviceID : BaseID<DeviceKind>, IEquatable<DeviceID?>
	{
		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="Device">
		/// A <see cref="UInt128"/> Device value
		/// </param>
		/// <exception cref="IDException"/>
		[JsonConstructor, MainConstructor]
		internal DeviceID([NotNull] UInt128 Device) : base(Device) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="DeviceID"/> class
		/// </summary>
		public DeviceID() : base(Def.DeviceKind) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="DeviceID"/> class
		/// </summary>
		/// <param name="kind">A <see cref="DeviceKind"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="IDException"/>
		public DeviceID([NotNull] DeviceKind kind, [NotNull] ulong subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="DeviceID(DeviceKind,ulong)"/>
		public DeviceID([NotNull] DeviceKind kind, [NotNull] long subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="DeviceType"/> type</param>
		/// <inheritdoc cref="DeviceID(DeviceKind,ulong)"/>
		public DeviceID([NotNull] DeviceType type, [NotNull] ulong subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="DeviceType"/> type</param>
		/// <inheritdoc cref="DeviceID(DeviceKind,long)"/>
		public DeviceID([NotNull] DeviceType type, [NotNull] long subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="DeviceID(DeviceKind,ulong)"/>
		public DeviceID([NotNull] DeviceKind kind) : base(kind) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="DeviceID(DeviceType,ulong)"/>
		public DeviceID([NotNull] DeviceType kind) : base(kind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as DeviceID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IEquatable{DeviceID}.Equals(DeviceID?)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="IDException"/>
		public bool Equals(DeviceID? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && Data.Equals(other.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
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
				Out = HashCode.Combine(Data, Data.GetHashCode(), base.GetHashCode());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
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
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
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

		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Data:X32}";
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
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

		public override ulong GetSubID()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			ulong Out;

			try
			{
				Out = ulong.Parse($"{this}"[16..], NumberStyles.HexNumber);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		public static bool operator ==(DeviceID? left, DeviceID? right)
		{
			return EqualityComparer<DeviceID>.Default.Equals(left, right);
		}

		public static bool operator !=(DeviceID? left, DeviceID? right)
		{
			return !(left == right);
		}
	}
}
