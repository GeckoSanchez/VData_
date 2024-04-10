namespace VData02.Bases
{
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Numerics;
	using Actions;
	using Attributes;
	using Categories;
	using Newtonsoft.Json;

	/// <summary>
	/// Base type for all of <see cref="VData02"/> program
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public class Base : IDisposable, IEquatable<Base>, IBase, IEqualityOperators<Base, Base, bool>, IEqualityOperators<Base, object, bool>
	{
		private bool _disposed;

		public object Data { get; protected set; }

		[JsonConstructor, MainConstructor]
		public Base([NotNull] object data)
		{
			Log.Event(new StackFrame(true));
			Data = data;
		}

		~Base()
		{
			Log.Event(new StackFrame(true));
			Dispose();
		}

		/// <inheritdoc cref="IDisposable.Dispose"/>
		/// <exception cref="BaseException"/>
		protected virtual void Dispose(bool disposing)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!_disposed)
				{
					if (disposing)
					{
						Data = default!;
						GC.Collect();
					}

					_disposed = true;
				}
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
			}
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
				Out = other is not null && EqualityComparer<Base>.Default.Equals(this, other);
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
				Out = Equals(obj as Base);
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDisposable.Dispose"/>
		/// <exception cref="BaseException"/>
		public void Dispose()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
				Dispose(true);
				GC.SuppressFinalize(this);
				GC.Collect();
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
			}
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

		/// <inheritdoc cref="IEqualityOperators{Base, Base, bool}.op_Equality"/>
		/// <exception cref="BaseException"/>
		public static bool operator ==(Base? left, Base? right)
		{
			bool Out;

			try
			{
				Out = EqualityComparer<Base>.Default.Equals(left, right);
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="IEqualityOperators{Base, Base, bool}.op_Inequality"/>
		/// <exception cref="BaseException"/>
		public static bool operator !=(Base? left, Base? right)
		{
			bool Out;

			try
			{
				Out = !EqualityComparer<Base>.Default.Equals(left, right);
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="IEqualityOperators{Base, Object, bool}.op_Equality"/>
		/// <exception cref="BaseException"/>
		public static bool operator ==(Base? left, object? right)
		{
			bool Out;

			try
			{
				Out = left is not null && EqualityComparer<object>.Default.Equals(left.Data, right);
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="IEqualityOperators{Base, Object, bool}.op_Inequality"/>
		/// <exception cref="BaseException"/>
		public static bool operator !=(Base? left, object? right)
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
				throw new BaseException(ex, new StackFrame(true));
			}

			return Out;
		}
	}

	/// <summary>
	/// Base type for all of <see cref="VData02"/> program
	/// </summary>
	/// <typeparam name="T">The <typeparamref name="T"/> sub-type for this base type</typeparam>
	[JsonObject(MemberSerialization.OptIn)]
	public class Base<T> : Base, IEquatable<Base<T>?>, IEqualityOperators<Base<T>, Base<T>, bool>, IEqualityOperators<Base<T>, T, bool> where T : notnull
	{
		public new T Data { get => (T)base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="Base{T}"/> class
		/// </summary>
		/// <param name="data">A <typeparamref name="T"/> data value</param>
		public Base([NotNull] T data) : base(data)
		{
			Log.Event(new StackFrame(true));
			Data = data;
		}

		public static implicit operator Base<T>(T v) => new(v);

		~Base()
		{
			Log.Event(new StackFrame(true));
			Dispose();
		}

		/// <summary>
		/// Constructor for the <see cref="Base{T}"/> class
		/// </summary>
		/// <param name="data">A <see cref="Base{T}"/> data object</param>
		public Base(Base<T> data) : this(data.Data) => Log.Event(new StackFrame(true));

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
				throw new BaseException(ex, sf);
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
				throw new BaseException(Def.JSONException, sf);
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

		/// <inheritdoc cref="IEqualityOperators{Base{T}, Base{T}, bool}.op_Equality"/>
		/// <exception cref="BaseException"/>
		public static bool operator ==(Base<T>? left, Base<T>? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<T>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="IEqualityOperators{Base{T}, Base{T}, bool}.op_Inequality"/>
		/// <exception cref="BaseException"/>
		public static bool operator !=(Base<T>? left, Base<T>? right)
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
				throw new BaseException(ex, new StackFrame(true));
			}

			return Out;
		}

		public static bool operator ==(Base<T>? left, T? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && !EqualityComparer<T>.Default.Equals(left.Data, right);
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, new StackFrame(true));
			}

			return Out;
		}

		public static bool operator !=(Base<T>? left, T? right)
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
				throw new BaseException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
