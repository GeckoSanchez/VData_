namespace VData02.Bases
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Exceptions;
	using Newtonsoft.Json;
	using VData02.Categories;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseKind : Base<Enum>, IEquatable<BaseKind?>, IKind
	{
		[JsonProperty]
		public new Enum Data { get => base.Data; protected set => base.Data = value; }

		public static readonly BaseKind DeviceKind = new(Def.DeviceKind);
		public static readonly BaseKind LinkKind = new(Def.LinkKind);
		public static readonly BaseKind ObjectKind = new(Def.ObjectKind);
		public static readonly BaseKind PageKind = new(Def.PageKind);

		/// <summary>
		/// Main constructor for the <see cref="BaseKind"/> class
		/// </summary>
		/// <param name="data">A <see cref="Enum"/> kind</param>
		[JsonConstructor, MainConstructor]
		public BaseKind(Enum data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseKind"/> class
		/// </summary>
		/// <param name="data">A <see cref="Base{Enum}"/> data object</param>
		public BaseKind(Base<Enum> data) : this(data.Data) => Log.Event(new StackFrame(true));

		public static implicit operator BaseKind(Enum v) => new(v);

		/// <inheritdoc cref="Base{Enum}.Equals(object?)"/>
		/// <exception cref="KindException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseKind);
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

		/// <inheritdoc cref="Base{Enum}.Equals(Base{Enum}?)"/>
		/// <exception cref="KindException"/>
		public bool Equals(BaseKind? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<Enum>.Default.Equals(Data, other.Data);
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

		/// <inheritdoc cref="Base{Enum}.Dispose(bool)"/>
		/// <exception cref="KindException"/>
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
		public static bool operator ==(BaseKind? left, BaseKind? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<Enum>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{Enum}.op_Inequality"/>
		/// <exception cref="KindException"/>
		public static bool operator !=(BaseKind? left, BaseKind? right)
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

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseKind<TKind> : BaseKind, IEquatable<BaseKind<TKind>?>, IKind<TKind> where TKind : struct, Enum
	{
		[JsonProperty]
		public new TKind Data { get => (TKind)base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="BaseKind{TKind}"/> class
		/// </summary>
		/// <param name="data">A <typeparamref name="TKind"/> data kind</param>
		[JsonConstructor, MainConstructor]
		public BaseKind([NotNull] TKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseKind{TKind}"/> class
		/// </summary>
		/// <param name="data">A <see cref="Base{TKind}"/> data object</param>
		public BaseKind(Base<TKind> data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="BaseKind"/> data object</param>
		/// <inheritdoc cref="BaseKind{TKind}(Base{TKind})"/>
		public BaseKind(BaseKind data) : this((TKind)data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="BaseKind{TKind}"/> data object</param>
		/// <inheritdoc cref="BaseKind{TKind}(Base{TKind})"/>
		public BaseKind(BaseKind<TKind> data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="long"/> data value</param>
		/// <inheritdoc cref="BaseKind{TKind}(Base{TKind})"/>
		/// <exception cref="KindException"/>
		public BaseKind(long data) : this(Enum.GetValues<TKind>().First())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = Enum.GetValues<TKind>().First(e => e.GetHashCode() == data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <summary>
		/// Empty constructor for the <see cref="BaseKind{TKind}"/> class
		/// </summary>
		[EmptyConstructor]
		public BaseKind() : this(Def<TKind>.Value) => Log.Event(new StackFrame(true));

		public static implicit operator BaseKind<TKind>(TKind v) => new(v);

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseKind<TKind>);
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

		/// <inheritdoc cref="BaseKind.Equals(BaseKind?)"/>
		public bool Equals(BaseKind<TKind>? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<TKind>.Default.Equals(Data, other.Data);
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
		public static bool operator ==(BaseKind<TKind>? left, BaseKind<TKind>? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<TKind>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{Enum}.op_Inequality"/>
		/// <exception cref="KindException"/>
		public static bool operator !=(BaseKind<TKind>? left, BaseKind<TKind>? right)
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
