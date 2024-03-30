namespace VData01.Types
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class DeviceType : BaseType<DeviceKind>, IEquatable<DeviceType?>
	{
		/// <summary>
		/// Main constructor for the <see cref="DeviceType"/> class
		/// </summary>
		/// <param name="data">A <see cref="DeviceKind"/> kind</param>
		/// <exception cref="KindException"/>
		[JsonConstructor, MainConstructor]
		public DeviceType(DeviceKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="DeviceType"/> class
		/// </summary>
		/// <param name="data">A <see cref="DeviceType"/> data value</param>
		/// <exception cref="KindException"/>
		public DeviceType(DeviceType data) : base(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="DeviceType"/> class
		/// </summary>
		[EmptyConstructor]
		public DeviceType() : base(Def.DeviceKind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as DeviceType);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new TypeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IEquatable{DeviceType}.Equals(DeviceType?)"/>
		/// <exception cref="TypeException"/>
		/// <exception cref="BaseException"/>
		public bool Equals(DeviceType? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && Data == other.Data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new TypeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DeviceType}.GetHashCode"/>
		/// <exception cref="TypeException"/>
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
				throw new TypeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DeviceType}.ToJSON(Formatting?)"/>
		/// <exception cref="TypeException"/>
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
				throw new TypeException(ex, sf);
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

		/// <inheritdoc cref="Base{DeviceType}.ToString"/>
		/// <exception cref="TypeException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string Out = "";

			try
			{
				foreach (var i in Enum.GetValues<DeviceKind>().Where(e => Data.HasFlag(e)))
					Out += $"{Enum.GetName(i)}-";

				Out = Out.TrimEnd('-');
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new TypeException(ex, sf);
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

		public static bool operator ==(DeviceType? left, DeviceType? right) => EqualityComparer<DeviceType>.Default.Equals(left, right);
		public static bool operator !=(DeviceType? left, DeviceType? right) => !(left == right);
	}
}
