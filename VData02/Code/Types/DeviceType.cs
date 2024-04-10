namespace VData02.Types
{
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class DeviceType : BaseKind<DeviceKind>
	{
		/// <summary>
		/// Main constructor for the <see cref="DeviceType"/> class
		/// </summary>
		/// <param name="data">A <see cref="DeviceKind"/> data value</param>
		[JsonConstructor, MainConstructor]
		public DeviceType([NotNull] DeviceKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="DeviceType"/> class
		/// </summary>
		/// <param name="data">A <see cref="BaseKind{DeviceKind}"/> data object</param>
		public DeviceType(BaseKind<DeviceKind> data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="DeviceType"/> kind object</param>
		/// <inheritdoc cref="DeviceType(BaseKind{DeviceKind})"/>
		public DeviceType(DeviceType data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="long"/> kind value</param>
		/// <inheritdoc cref="DeviceType(BaseKind{DeviceKind})"/>
		/// <exception cref="KindException"/>
		public DeviceType(long data) : this(Def.DeviceKind)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = Enum.GetValues<DeviceKind>().First(e => e.GetHashCode() == data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <summary>
		/// Empty constructor for the <see cref="DeviceType"/> class
		/// </summary>
		[EmptyConstructor]
		public DeviceType() : this(Def.DeviceKind) => Log.Event(new StackFrame(true)); public override bool Equals(object? obj)
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
				throw new KindException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="BaseKind{TType}.Equals(BaseKind{TType}?)"/>
		public bool Equals(DeviceType? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<DeviceKind>.Default.Equals(Data, other.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
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
				throw new KindException(ex, sf);
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
				Out = $"{Data}";
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
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
				throw new KindException(ex, sf);
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
				throw new KindException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
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

		/// <inheritdoc cref="Base{Enum}.op_Equality"/>
		/// <exception cref="KindException"/>
		public static bool operator ==(DeviceType? left, DeviceType? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<DeviceKind>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{Enum}.op_Inequality"/>
		/// <exception cref="KindException"/>
		public static bool operator !=(DeviceType? left, DeviceType? right)
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
				throw new KindException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
