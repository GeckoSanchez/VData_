namespace VData02.Bases
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;
	using Actions;
	using Attributes;
	using Exceptions;
	using Newtonsoft.Json;
	using VData02.IDs;
	using VData02.Kinds;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseID : Base<UInt128>, IEquatable<BaseID?>
	{
		[JsonProperty]
		public new UInt128 Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="BaseID"/> class
		/// </summary>
		/// <param name="data">A <see cref="UInt128"/> ID value</param>
		[JsonConstructor, MainConstructor]
		internal BaseID([NotNull] UInt128 data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseID"/> class
		/// </summary>
		/// <param name="kind">A <see cref="Enum"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="IDException"/>
		public BaseID([NotNull] Enum kind, [NotNull] ulong subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="BaseID(Enum,ulong)"/>
		public BaseID([NotNull] Enum kind, [NotNull] long subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="BaseID(Enum,ulong)"/>
		/// <exception cref="BaseException"/>
		public BaseID([NotNull] BaseKind kind, [NotNull] ulong subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="BaseID(Enum,ulong)"/>
		/// <exception cref="BaseException"/>
		public BaseID([NotNull] BaseKind kind, [NotNull] long subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseID(Enum,ulong)"/>
		/// <exception cref="BaseException"/>
		public BaseID([NotNull] Enum kind) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{Random.Shared.NextInt64():X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseID(Enum,ulong)"/>
		/// <exception cref="BaseException"/>
		public BaseID([NotNull] BaseKind kind) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{Random.Shared.NextInt64():X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{UInt128}.Equals(object?)"/>
		/// <exception cref="IDException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseID);
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

		/// <inheritdoc cref="Base{UInt128}.Equals(Base{UInt128}?)"/>
		/// <exception cref="IDException"/>
		public bool Equals(BaseID? other)
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

		/// <inheritdoc cref="Base{UInt128}.GetHashCode"/>
		/// <exception cref="IDException"/>
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

		/// <inheritdoc cref="Base{UInt128}.ToString"/>
		/// <exception cref="IDException"/>
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

		/// <inheritdoc cref="Base{UInt128}.Dispose(bool)"/>
		/// <exception cref="IDException"/>
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
				throw new IDException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{UInt128}.ToJSON(Formatting?)"/>
		/// <exception cref="IDException"/>
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
				throw new IDException(Def.JSONException, sf);
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

		/// <summary>
		/// Parses a string into a <see cref="BaseID"/> object.
		/// </summary>
		/// <exception cref="IDException"/>
		public static BaseID Parse(string s)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseID Out;

			try
			{
				var data = UInt128.Parse(s[..int.Min(s.Length, 32)], NumberStyles.HexNumber);
				Out = new(data);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		/// <summary>
		/// Tries to parse a string into a <see cref="BaseID"/> object.
		/// </summary>
		/// <param name="s">The string to parse into.</param>
		/// <param name="result"></param>
		/// <returns>The <see cref="BaseID"/> result of parsing s</returns>
		/// <exception cref="NotImplementedException"/>
		public static bool TryParse([NotNullWhen(true)] string s, [MaybeNullWhen(false)] out BaseID result)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				var data = UInt128.Parse(s[..int.Min(s.Length, 32)], NumberStyles.HexNumber);
				result = new(data);
				Out = true;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		/// <summary>
		/// Function to extract the sub-ID of the current <see cref="BaseID"/> object
		/// </summary>
		/// <returns>A <see cref="ulong"/> sub-ID</returns>
		/// <exception cref="IDException"/>
		public virtual ulong GetSubID()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			ulong Out;

			try
			{
				Out = ulong.Parse($"{Data:X32}"[16..], NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{UInt128}.op_Equality"/>
		/// <exception cref="IDException"/>
		public static bool operator ==(BaseID? left, BaseID? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<UInt128>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{UInt128}.op_Inequality"/>
		/// <exception cref="IDException"/>
		public static bool operator !=(BaseID? left, BaseID? right)
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
				throw new IDException(ex, new StackFrame(true));
			}

			return Out;
		}
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseID<TKind> : BaseID, IEquatable<BaseID<TKind>?> where TKind : struct, Enum
	{
		/// <summary>
		/// Main constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="data">A <see cref="UInt128"/> data value</param>
		/// <exception cref="IDException"/>
		[JsonConstructor, MainConstructor]
		internal BaseID([NotNull] UInt128 data) : base(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				string s = $"{data:X32}";

				if (s[..8] != $"{typeof(TKind).GetHashCode():X8}")
					throw new Exception($"This value {Format.ExcValue($"{data:X32}")} is not valid for an ID of this type: {typeof(TKind).Name}");
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="kind">A <typeparamref name="TKind"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="IDException"/>
		public BaseID(TKind kind, ulong subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="BaseID{TKind}(TKind,ulong)"/>
		public BaseID(TKind kind, long subID) : base(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseID{TKind}(TKind,ulong)"/>
		public BaseID(TKind kind) : base(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{Random.Shared.NextInt64():X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="BaseKind{TKind}"/> data object</param>
		/// <inheritdoc cref="BaseID{TKind}(TKind,ulong)"/>
		public BaseID(BaseKind<TKind> kind, ulong subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="BaseKind{TKind}"/> data object</param>
		/// <inheritdoc cref="BaseID{TKind}(TKind,long)"/>
		public BaseID(BaseKind<TKind> kind, long subID) : base(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseID{TKind}(BaseKind{TKind},ulong)"/>
		public BaseID(BaseKind<TKind> kind) : base(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{Random.Shared.NextInt64():X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="data">A <see cref="DeviceID"/> data object</param>
		/// <exception cref="IDException"/>
		public BaseID(DeviceID data) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				string s = data.ToString();

				if (typeof(TKind) != typeof(DeviceKind) || s[..8] != $"{typeof(TKind).GetHashCode():X8}")
					throw new Exception($"This value {Format.ExcValue($"{data}")} is not valid for an ID of this type: {typeof(TKind).Name}");

				Data = data.Data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="data">A <see cref="LinkID"/> ID object</param>
		/// <inheritdoc cref="BaseID{TKind}(DeviceID)"/>
		public BaseID(LinkID data) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				string s = data.ToString();

				if (typeof(TKind) != typeof(LinkKind) || s[..8] != $"{typeof(TKind).GetHashCode():X8}")
					throw new Exception($"This value {Format.ExcValue($"{data}")} is not valid for an ID of this type: {typeof(TKind).Name}");

				Data = data.Data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="data">A <see cref="ObjectID"/> ID object</param>
		/// <inheritdoc cref="BaseID{TKind}(DeviceID)"/>
		public BaseID(ObjectID data) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				string s = data.ToString();

				if (typeof(TKind) != typeof(ObjectKind) || s[..8] != $"{typeof(TKind).GetHashCode():X8}")
					throw new Exception($"This value {Format.ExcValue($"{data}")} is not valid for an ID of this type: {typeof(TKind).Name}");

				Data = data.Data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="data">A <see cref="PageID"/> ID object</param>
		/// <inheritdoc cref="BaseID{TKind}(DeviceID)"/>
		public BaseID(PageID data) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				string s = data.ToString();

				if (typeof(TKind) != typeof(PageKind) || s[..8] != $"{typeof(TKind).GetHashCode():X8}")
					throw new Exception($"This value {Format.ExcValue($"{data}")} is not valid for an ID of this type: {typeof(TKind).Name}");

				Data = data.Data;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <summary>
		/// Empty constructor for the <see cref="BaseID"/> class
		/// </summary>
		/// <exception cref="IDException"/>
		[EmptyConstructor]
		public BaseID() : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{Def<TKind>.Value.GetType().GetHashCode():X8}{Def<TKind>.Value.GetHashCode():X8}{0:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseID<TKind>);
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

		/// <inheritdoc cref="BaseID.Equals(BaseID?)"/>
		/// <exception cref="IDException"/>
		public bool Equals(BaseID<TKind>? other)
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
			catch (JsonException)
			{
				throw new IDException(Def.JSONException, sf);
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
				throw new IDException(ex, sf);
			}
		}

		/// <summary>
		/// Function to extract the sub-ID of the current <see cref="BaseID{TKind}"/> object
		/// </summary>
		/// <inheritdoc cref="BaseID.GetSubID"/>
		public override ulong GetSubID()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			ulong Out;

			try
			{
				Out = ulong.Parse($"{Data:X32}"[16..], NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="BaseID.op_Equality"/>
		public static bool operator ==(BaseID<TKind>? left, BaseID<TKind>? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<UInt128>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="BaseID.op_Inequality"/>
		/// <exception cref="BaseException"/>
		public static bool operator !=(BaseID<TKind>? left, BaseID<TKind>? right)
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
				throw new IDException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
