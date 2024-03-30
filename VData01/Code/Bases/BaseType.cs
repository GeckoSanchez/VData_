namespace VData01.Bases
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseType : Base<Enum>, IEquatable<BaseType?>, IBase, IType
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Include)]
		public new Enum Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="BaseType"/> class
		/// </summary>
		/// <param name="data">
		/// A <see cref="Enum"/> data value
		/// </param>
		/// <exception cref="KindException"/>
		[JsonConstructor, MainConstructor]
		public BaseType(Enum data) : base(data)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (Check.Kind(data))
					throw new Exception($"This kind {Format<Enum>.ExcValue(data)} is invalid");
				else
					Data = data;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseType"/> class
		/// </summary>
		/// <param name="data">A <see cref="Base{Enum}"/> data value</param>
		/// <exception cref="KindException"/>
		public BaseType(Base<Enum> data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Base{Enum}.Equals(object?)"/>
		/// <exception cref="KindException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseType);
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

		/// <inheritdoc cref="IEquatable{BaseKind}.Equals(BaseKind)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="KindException"/>
		public bool Equals(BaseType? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
						 EqualityComparer<Enum>.Default.Equals(Data, other.Data);
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

		/// <inheritdoc cref="Base{Enum}.GetHashCode"/>
		/// <exception cref="KindException"/>
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

		/// <inheritdoc cref="Base{Enum}.ToJSON(Formatting?)"/>
		/// <exception cref="KindException"/>
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

		/// <inheritdoc cref="Base{Enum}.ToString"/>
		/// <exception cref="KindException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Data}";
			}
			catch (BaseException)
			{
				throw;
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

		public static bool operator ==(BaseType? left, BaseType? right) => EqualityComparer<BaseType>.Default.Equals(left, right);
		public static bool operator !=(BaseType? left, BaseType? right) => !(left == right);
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseType<TKind> : BaseType, IEquatable<BaseType<TKind>?>, IType<TKind> where TKind : struct, Enum
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Include)]
		public new TKind Data { get => (TKind)base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="BaseType{TKind}"/> class
		/// </summary>
		/// <param name="data">
		/// A/an <typeparamref name="TKind"/> kind
		/// </param>
		/// <exception cref="KindException"/>
		[JsonConstructor, MainConstructor]
		public BaseType(TKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseType{TKind}"/> class
		/// </summary>
		/// <param name="data">A <see cref="DataKind"/> kind</param>
		/// <exception cref="KindException"/>
		public BaseType(DataKind data) : this(Def<TKind>.Value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (data.GetType() != typeof(TKind))
					throw new Exception($"The kind {Format.ExcValue($"{data}")} of the given kind {Format.ExcValue($"{data}")} is not valid for a {GetType().Name}");
				else
					Data = (TKind)(Enum)data;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <param name="data">A <see cref="DeviceKind"/> kind</param>
		/// <inheritdoc cref="BaseType{TKind}(DataKind)"/>
		public BaseType(DeviceKind data) : this(Def<TKind>.Value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (data.GetType() != typeof(TKind))
					throw new Exception($"The kind {Format.ExcValue($"{data.GetType()}")} of the given kind {Format.ExcValue($"{data}")} is not valid for a {GetType().Name}");
				else
					Data = (TKind)(Enum)data;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <param name="data">A <see cref="LinkKind"/> kind</param>
		/// <inheritdoc cref="BaseType{TKind}(DataKind)"/>
		public BaseType(LinkKind data) : this(Def<TKind>.Value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (data.GetType() != typeof(TKind))
					throw new Exception($"The kind {Format.ExcValue($"{data.GetType()}")} of the given kind {Format.ExcValue($"{data}")} is not valid for a {GetType().Name}");
				else
					Data = (TKind)(Enum)data;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <param name="data">A <see cref="ObjectKind"/> kind</param>
		/// <inheritdoc cref="BaseType{TKind}(DataKind)"/>
		public BaseType(ObjectKind data) : this(Def<TKind>.Value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (data.GetType() != typeof(TKind))
					throw new Exception($"The kind {Format.ExcValue($"{data.GetType()}")} of the given kind {Format.ExcValue($"{data}")} is not valid for a {GetType().Name}");
				else
					Data = (TKind)(Enum)data;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <param name="data">A <see cref="PageKind"/> kind</param>
		/// <inheritdoc cref="BaseType{TKind}(DataKind)"/>
		public BaseType(PageKind data) : this(Def<TKind>.Value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (data.GetType() != typeof(TKind))
					throw new Exception($"The kind {Format.ExcValue($"{data.GetType()}")} of the given kind {Format.ExcValue($"{data}")} is not valid for a {GetType().Name}");
				else
					Data = (TKind)(Enum)data;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <param name="data">A <see cref="PlatformKind"/> kind</param>
		/// <inheritdoc cref="BaseType{TKind}(DataKind)"/>
		public BaseType(PlatformKind data) : this(Def<TKind>.Value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (data.GetType() != typeof(TKind))
					throw new Exception($"The kind {Format.ExcValue($"{data.GetType()}")} of the given kind {Format.ExcValue($"{data}")} is not valid for a {GetType().Name}");
				else
					Data = (TKind)(Enum)data;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseType<TKind>);
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

		/// <inheritdoc cref="IEquatable{BaseType{TKind}}.Equals(BaseType{TKind})"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="KindException"/>
		public bool Equals(BaseType<TKind>? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
						 EqualityComparer<TKind>.Default.Equals(Data, other.Data);
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

		/// <inheritdoc cref="BaseType.ToJSON(Formatting?)"/>
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

		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string Out = "";

			try
			{
				foreach (var i in Enum.GetValues<TKind>().Where(e => Data.HasFlag(e)))
					Out += $"{Enum.GetName(i)}-";

				Out = Out.TrimEnd('-');
			}
			catch (BaseException)
			{
				throw;
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

		public static bool operator ==(BaseType<TKind>? left, BaseType<TKind>? right) => EqualityComparer<BaseType<TKind>>.Default.Equals(left, right);
		public static bool operator !=(BaseType<TKind>? left, BaseType<TKind>? right) => !(left == right);
	}
}
