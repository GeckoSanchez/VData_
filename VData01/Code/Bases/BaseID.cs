namespace VData01.Bases
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseID : Base<UInt128>, IEquatable<BaseID?>, IBase
	{
		/// <summary>
		/// The base <see cref="UInt128"/> data for the <see cref="BaseID"/> class
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Include)]
		public new UInt128 Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseID"/> class
		/// </summary>
		/// <param name="data">A <see cref="UInt128"/> data value</param>
		[JsonConstructor, MainConstructor]
		internal BaseID(UInt128 data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseID"/> class
		/// </summary>
		/// <param name="kind">An <see cref="Enum"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="IDException"/>
		public BaseID([NotNull] Enum kind, [NotNull] ulong subID) : this(UInt128.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (kind.GetType() != typeof(DataKind) &&
						kind.GetType() != typeof(DeviceKind) &&
						kind.GetType() != typeof(LinkKind) &&
						kind.GetType() != typeof(ObjectKind) &&
						kind.GetType() != typeof(PageKind) &&
						kind.GetType() != typeof(PlatformKind))
					throw new Exception($"This kind {Format<Enum>.ExcValue(kind)} is invalid for this {nameof(BaseID)}");
				else
					Data = UInt128.Parse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode()}{subID:X16}", NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="BaseID(Enum,ulong)"/>
		public BaseID([NotNull] Enum kind, [NotNull] long subID) : this(UInt128.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (Check.Kind(kind))
					throw new Exception($"This kind {Format<Enum>.ExcValue(kind)} is invalid for this {nameof(BaseID)}");
				else
					Data = UInt128.Parse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode()}{subID:X16}", NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="BaseType"/> kind</param>
		/// <inheritdoc cref="BaseID(Enum,ulong)"/>
		public BaseID(BaseType kind, ulong subID) : this(UInt128.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (Check.Kind(kind))
					throw new Exception($"This kind {Format<Enum>.ExcValue(kind.Data)} is invalid for this {nameof(BaseID)}");
				else
					Data = UInt128.Parse($"{kind.Data.GetType().GetHashCode():X8}{kind.Data.GetHashCode()}{subID:X16}", NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="BaseType"/> kind</param>
		/// <inheritdoc cref="BaseID(Enum,long)"/>
		public BaseID(BaseType kind, long subID) : this(UInt128.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (Check.Kind(kind))
					throw new Exception($"This kind {Format<Enum>.ExcValue(kind.Data)} is invalid for this {nameof(BaseID)}");
				else
					Data = UInt128.Parse($"{kind.Data.GetType().GetHashCode():X8}{kind.Data.GetHashCode()}{subID:X16}", NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseID(Enum,ulong)"/>
		public BaseID(Enum kind) : this(UInt128.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = UInt128.Parse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode()}{Random.Shared.NextInt64():X16}", NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseID(BaseType,ulong)"/>
		public BaseID(BaseType kind) : this(UInt128.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = UInt128.Parse($"{kind.Data.GetType().GetHashCode():X8}{kind.Data.GetHashCode()}{Random.Shared.NextInt64():X16}", NumberStyles.HexNumber);
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

		/// <inheritdoc cref="IEquatable{BaseID}.Equals(BaseID)"/>
		/// <exception cref="BaseException"/>
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
			catch (BaseException)
			{
				throw;
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

		/// <summary>
		/// Function to get the sub-ID for this <see cref="BaseID"/> class
		/// </summary>
		/// <returns>The <see cref="ulong"/> sub-ID</returns>
		/// <exception cref="IDException"/>
		public virtual ulong GetSubID()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			ulong Out;

			try
			{
				Out = ulong.Parse($"{this}"[16..]);
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

		public static bool operator ==(BaseID? left, BaseID? right) => EqualityComparer<BaseID>.Default.Equals(left, right);
		public static bool operator !=(BaseID? left, BaseID? right) => !(left == right);
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseID<TKind> : BaseID, IEquatable<BaseID<TKind>?> where TKind : struct, Enum
	{
		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="data">
		/// A <see cref="UInt128"/> data value
		/// </param>
		/// <exception cref="IDException"/>
		[JsonConstructor, MainConstructor]
		internal BaseID([NotNull] UInt128 data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="kind">A <typeparamref name="TKind"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="IDException"/>
		public BaseID([NotNull] TKind kind, [NotNull] ulong subID) : base(UInt128.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (kind.GetType() != typeof(DataKind) &&
						kind.GetType() != typeof(DeviceKind) &&
						kind.GetType() != typeof(LinkKind) &&
						kind.GetType() != typeof(ObjectKind) &&
						kind.GetType() != typeof(PageKind) &&
						kind.GetType() != typeof(PlatformKind))
					throw new Exception($"This kind {Format<Enum>.ExcValue(kind)} is invalid");
				else
					Data = UInt128.Parse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="BaseID{TKind}(TKind,ulong)"/>
		public BaseID([NotNull] TKind kind, [NotNull] long subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="BaseType{TKind}"/> kind</param>
		/// <inheritdoc cref="BaseID{TKind}(TKind,ulong)"/>
		public BaseID([NotNull] BaseType<TKind> type, [NotNull] ulong subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="BaseType{TKind}"/> kind</param>
		/// <inheritdoc cref="BaseID{TKind}(TKind,long)"/>
		public BaseID([NotNull] BaseType<TKind> type, [NotNull] long subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseID{TKind}(TKind,ulong)"/>
		public BaseID([NotNull] TKind kind) : base(kind) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseID{TKind}(BaseType{TKind},ulong)"/>
		public BaseID([NotNull] BaseType<TKind> type) : base(type) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		[EmptyConstructor]
		public BaseID() : this(Def<TKind>.Value) => Log.Event(new StackFrame(true));

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

		/// <inheritdoc cref="IEquatable{BaseID{TKind}}.Equals(BaseID{TKind})"/>
		/// <exception cref="BaseException"/>
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

		/// <summary>
		/// Function to get the sub-ID for this <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <returns>
		/// The <see cref="ulong"/> sub-ID
		/// </returns>
		/// <exception cref="IDException"/>
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

		public static bool operator ==(BaseID<TKind>? left, BaseID<TKind>? right) => EqualityComparer<BaseID<TKind>>.Default.Equals(left, right);
		public static bool operator !=(BaseID<TKind>? left, BaseID<TKind>? right) => !(left == right);
	}
}
