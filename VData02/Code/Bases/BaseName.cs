namespace VData02.Bases
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseName : Base<string>, IEquatable<BaseName?>, IName
	{
		[DefaultValue(Def.Name), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Include)]
		public new string Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="BaseName"/> class
		/// </summary>
		/// <param name="data">A <see cref="string"/> name string</param>
		/// <exception cref="NameException"/>
		[JsonConstructor, MainConstructor]
		internal BaseName(string data) : base(Def.Name)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (int.Clamp(data.Length, Def.MinNameLength, Def.MaxNameLength) != data.Length)
					throw new Exception($"The name's {Format.ExcValue(data)} length {Format<int>.ExcValue(data.Length)} is not between the minimum length {Format<int>.ExcValue(Def.MinNameLength)} and the maximum length {Format<int>.ExcValue(Def.MaxNameLength)}");
				else if (data.Any(e => !Def.GoodNameChars.Contains(e)))
					throw new Exception($"This name {Format.ExcValue(data)} contains the following illegal character(s): {string.Join(", ", data.Where(e => !Def.GoodNameChars.Contains(e)))}");
				else
					Data = data;
			}
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseName"/> class
		/// </summary>
		/// <param name="kinds">An array of <see cref="Enum"/> kinds</param>
		/// <inheritdoc cref="BaseName(string)"/>
		public BaseName(string data, params Enum[] kinds) : this(Def.Name)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (int.Clamp(data.Length, Def.MinNameLength, Def.MaxNameLength) != data.Length)
					throw new Exception($"The name's {Format.ExcValue(data)} length {Format<int>.ExcValue(data.Length)} is not between the minimum length {Format<int>.ExcValue(Def.MinNameLength)} and the maximum length {Format<int>.ExcValue(Def.MaxNameLength)}");
				else
				{
					foreach (var i in kinds)
						if (data.Contains(i.ToString(), StringComparison.InvariantCultureIgnoreCase))
							throw new Exception($"A reserved keyword {Format.ExcValue(i.ToString())} was found in the given name {Format.ExcValue(data)}");

					Data = data;
				}
			}
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{string}.Equals(object?)"/>
		/// <exception cref="NameException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseName);
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

		/// <inheritdoc cref="Base{string}.Equals(Base{string}?)"/>
		/// <exception cref="NameException"/>
		public bool Equals(BaseName? other)
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

		/// <inheritdoc cref="Base{String}.GetHashCode"/>
		/// <exception cref="NameException"/>
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

		/// <inheritdoc cref="Base{String}.ToString"/>
		/// <exception cref="NameException"/>
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

		/// <inheritdoc cref="Base{String}.Dispose(bool)"/>
		/// <exception cref="NameException"/>
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

		/// <inheritdoc cref="Base{String}.ToJSON(Formatting?)"/>
		/// <exception cref="NameException"/>
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
				throw new NameException(Def.JSONException, sf);
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

		/// <inheritdoc cref="Base{String}.op_Equality"/>
		/// <exception cref="NameException"/>
		public static bool operator ==(BaseName? left, BaseName? right)
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

		/// <inheritdoc cref="Base{String}.op_Inequality"/>
		/// <exception cref="NameException"/>
		public static bool operator !=(BaseName? left, BaseName? right)
		{
			bool Out;

			try
			{
				Out = !(left == right);
			}
			catch (NameException)
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

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseName<TKind> : BaseName, IEquatable<BaseName<TKind>?> where TKind : struct, Enum
	{
		/// <summary>
		/// [PROTECTED] Main constructor for the <see cref="BaseName{TKind}"/> class
		/// </summary>
		/// <param name="data">A <see cref="string"/> name string</param>
		/// <exception cref="NameException"/>
		[JsonConstructor, MainConstructor]
		protected BaseName(string data) : base(Def.Name)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (int.Clamp(data.Length, Def.MinNameLength, Def.MaxNameLength) != data.Length)
					throw new Exception($"The name's {Format.ExcValue(data)} length {Format<int>.ExcValue(data.Length)} is not between the minimum length {Format<int>.ExcValue(Def.MinNameLength)} and the maximum length {Format<int>.ExcValue(Def.MaxNameLength)}");
				else if (data.Any(e => !Def.GoodNameChars.Contains(e)))
					throw new Exception($"This name {Format.ExcValue(data)} contains the following illegal character(s): {string.Join(", ", data.Where(e => !Def.GoodNameChars.Contains(e)))}");
				else
					Data = data;
			}
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseName{TKind}"/> class
		/// </summary>
		/// <param name="kinds">An array of <typeparamref name="TKind"/> kinds</param>
		/// <inheritdoc cref="BaseName(string)"/>
		public BaseName(string data, params TKind[] kinds) : base(data, [.. kinds]) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseName{TKind}"/> class
		/// </summary>
		/// <param name="name">A <see cref="BaseName{TKind}"/> name object</param>
		/// <param name="kind">A <see cref="BaseKind{TKind}"/> kind object</param>
		public BaseName(BaseName<TKind> name, BaseKind<TKind> kind) : base(name.Data, [kind.Data]) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseName<TKind>);
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

		/// <inheritdoc cref="BaseName.Equals(BaseName?)"/>
		public bool Equals(BaseName<TKind>? other)
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

		/// <inheritdoc cref="BaseName.op_Equality"/>
		public static bool operator ==(BaseName<TKind>? left, BaseName<TKind>? right)
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

		/// <inheritdoc cref="BaseName.op_Inequality"/>
		public static bool operator !=(BaseName<TKind>? left, BaseName<TKind>? right)
		{
			bool Out;

			try
			{
				Out = !(left == right);
			}
			catch (NameException)
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
