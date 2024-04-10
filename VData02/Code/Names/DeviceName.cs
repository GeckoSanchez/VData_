namespace VData02.Names
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
	public class DeviceName : BaseName<DeviceKind>, IEquatable<DeviceName?>
	{
		/// <summary>
		/// Main constructor for the <see cref="DeviceName"/> class
		/// </summary>
		/// <param name="data">A <see cref="string"/> name value</param>
		[JsonConstructor, MainConstructor]
		protected DeviceName(string data) : base(data, Enum.GetValues<DeviceKind>()) => Log.Event(new StackFrame(true));
		
		/// <summary>
		/// Constructor for the <see cref="DeviceName"/> class
		/// </summary>
		/// <param name="data">A <see cref="string"/> name value</param>
		/// <param name="kinds">An array of <see cref="DeviceKind"/> kinds</param>
		public DeviceName(string data, params DeviceKind[] kinds) : base(data, kinds) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="DeviceName"/> class
		/// </summary>
		/// <param name="data">A <see cref="BaseName{DeviceKind}"/> name object</param>
		/// <param name="kinds">A <see cref="BaseKind{DeviceKind}"/> kind object</param>
		public DeviceName(BaseName<DeviceKind> name, BaseKind<DeviceKind> kind) : base(name, kind) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="DeviceName"/> class
		/// </summary>
		[EmptyConstructor]
		public DeviceName() : this($"_DefaultDevice_") => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as DeviceName);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="BaseName{DeviceKind}.Equals(BaseName{DeviceKind}?)"/>
		public bool Equals(DeviceName? other)
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
				throw new NameException(ex, sf);
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
				throw new NameException(ex, sf);
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
				Out = Data[..int.Min(Data.Length, Def.MaxNameLength)];
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
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
				base.Dispose(disposing);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
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
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
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

		public static bool operator ==(DeviceName? left, DeviceName? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<string>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new NameException(ex, new StackFrame(true));
			}

			return Out;
		}

		public static bool operator !=(DeviceName? left, DeviceName? right)
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
				throw new NameException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
