namespace VData01.Bases
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Newtonsoft.Json;

	public class Base : IEquatable<Base?>, IComparable<Base>
	{
		public object Data { get; protected set; }

		/// <summary>
		/// Main constructor for the <see cref="Base"/> class
		/// </summary>
		/// <param name="data">A <see cref="object"/> data value</param>
		[MainConstructor]
		public Base(object data)
		{
			Log.Event(new StackFrame(true));
			Data = data;
		}

		/// <summary>
		/// [PRIVATE] Empty constructor for the <see cref="Base"/> class
		/// </summary>
		[EmptyConstructor]
		private Base() : this(null!) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="object.Equals(object?)"/>
		/// <exception cref="BaseException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as Base);
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

		/// <inheritdoc cref="IEquatable{Base}.Equals(Base)"/>
		/// <exception cref="BaseException"/>
		public bool Equals(Base? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && EqualityComparer<object>.Default.Equals(Data, other.Data);
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="object.GetHashCode"/>
		/// <exception cref="BaseException"/>
		public override int GetHashCode()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = HashCode.Combine(Data, Data.GetHashCode(), base.GetHashCode());
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparable{Base}.CompareTo(Base)"/>
		/// <exception cref="BaseException"/>
		public int CompareTo(Base? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = Comparer<Base>.Default.Compare(this, other);
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="object.ToString"/>
		/// <exception cref="BaseException"/>
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
				throw new BaseException(ex, sf);
			}
			finally
			{
				Out ??= "";
			}

			return Out;
		}

		/// <summary>
		/// Function to serialize the contents of this element into the JSON format
		/// </summary>
		/// <param name="formatting"></param>
		/// <returns>A JSON-formatted string</returns>
		/// <exception cref="BaseException"/>
		public virtual string ToJSON(Formatting? formatting = null)
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
				throw new BaseException(ex, sf);
			}
			finally
			{
				Out ??= Def.JSON;
			}

			return Out;
		}

		public static bool operator ==(Base? left, Base? right) => EqualityComparer<Base>.Default.Equals(left, right);
		public static bool operator !=(Base? left, Base? right) => !(left == right);
	}

	public class Base<T> : Base, IEquatable<Base<T>?> where T : notnull
	{
		public new T Data { get => (T)base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="Base{T}"/> class
		/// </summary>
		/// <param name="data">A <typeparamref name="T"/> data value</param>
		[JsonConstructor, MainConstructor]
		public Base(T data) : base(data) => Log.Event(new StackFrame(true));

		public static implicit operator Base<T>(T data) => new(data);

		/// <inheritdoc cref="IComparable{Base{T}}.CompareTo(Base{T}?)"/>
		/// <exception cref="BaseException"/>
		public int CompareTo(Base<T>? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = Comparer<Base<T>>.Default.Compare(this, other);
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

		/// <inheritdoc cref="object.Equals(object?)"/>
		/// <exception cref="BaseException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as Base<T>);
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

		/// <inheritdoc cref="IEquatable{Base{T}}.Equals(Base{T}?)"/>
		/// <exception cref="BaseException"/>
		public bool Equals(Base<T>? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<T>.Default.Equals(Data, other.Data);
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
				throw new BaseException(ex, sf);
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
				throw new BaseException(ex, sf);
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
				Out = $"{Data}";
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
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

		public static bool operator ==(Base<T>? left, Base<T>? right) => EqualityComparer<Base<T>>.Default.Equals(left, right);
		public static bool operator !=(Base<T>? left, Base<T>? right) => !(left == right);
	}
}
