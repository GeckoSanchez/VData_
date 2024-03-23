namespace VData01.Bases
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseName : Base<string>, IEquatable<BaseName?>
	{
		[DefaultValue(Def.Name)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore,NullValueHandling = NullValueHandling.Include)]
		public new string Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="BaseName"/>
		/// </summary>
		/// <param name="data">A <see cref="string"/> name</param>
		/// <exception cref="NameException"></exception>
		[JsonConstructor, MainConstructor]
		public BaseName(string data) : base(Def.Name)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (data.Length < 40)
					throw new Exception($"This name's {Format.ExcValue(data)} length {Format<int>.ExcValue(data.Length)} is invalid");
				else
					Data = data;
			}
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{String}.Equals(object?)"/>
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
			catch (NameException)
			{
				throw;
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

		/// <inheritdoc cref="Base{String}.Equals(Base{String}?)"/>
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

		/// <inheritdoc cref="Base{String}.ToString"/>
		/// <exception cref="NameException"/>
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

		public static bool operator ==(BaseName? left, BaseName? right) => EqualityComparer<BaseName>.Default.Equals(left, right);
		public static bool operator !=(BaseName? left, BaseName? right) => !(left == right);
	}

	[method: JsonConstructor, MainConstructor]
	[JsonObject(MemberSerialization.OptIn)]
	public class BaseName<TName>(string data) : Base<string>(data), IEquatable<BaseName<TName>?> where TName : struct, Enum
	{
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseName<TName>);
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

		public bool Equals(BaseName<TName>? other)
		{
			return other is not null && base.Equals(other) && Data == other.Data;
		}

		/// <inheritdoc cref="BaseName.GetHashCode"/>
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

		public override string ToJSON(Formatting? formatting = null)
		{
			return base.ToJSON(formatting);
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public static bool operator ==(BaseName<TName>? left, BaseName<TName>? right) => EqualityComparer<BaseName<TName>>.Default.Equals(left, right);
		public static bool operator !=(BaseName<TName>? left, BaseName<TName>? right) => !(left == right);
	}
}
