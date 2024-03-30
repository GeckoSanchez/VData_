namespace VData01.Bases
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseName : Base<string>, IEquatable<BaseName?>, IBase
	{
		/// <summary>
		/// The base <see cref="string"/> data for the <see cref="BaseName"/>
		/// class
		/// </summary>
		[DefaultValue(Def.Name)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Include)]
		public new string Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseName"/>
		/// </summary>
		/// <param name="data">
		/// A <see cref="string"/> name
		/// </param>
		/// <exception cref="NameException"/>
		[JsonConstructor, MainConstructor]
		internal BaseName(string data) : base(Def.Name)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (data.Length > Def.MaxNameLength)
					throw new Exception($"This name's {Format.ExcValue(data)} length {Format<int>.ExcValue(data.Length)} is invalid");
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
		/// <param name="kind">
		/// An <see cref="Enum"/> value from the <see cref="Kinds"/>
		/// </param>
		/// <inheritdoc cref="BaseName(string)"/>
		public BaseName(string data, Enum kind) : base(Def.Name)
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
					throw new Exception($"The given type {Format<Enum>.ExcValue(kind)} is not a valid kind");
				else
					Data = data;
			}
			catch (Exception ex)
			{
				throw new NameException(ex, sf);
			}
		}

		/// <param name="kind">
		/// A <see cref="BaseType"/> kind
		/// </param>
		/// <inheritdoc cref="BaseName(string,Enum)"/>
		public BaseName(string data, BaseType kind) : base(Def.Name)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (kind.Data.GetType() != typeof(DataKind) &&
						kind.Data.GetType() != typeof(DeviceKind) &&
						kind.Data.GetType() != typeof(LinkKind) &&
						kind.Data.GetType() != typeof(ObjectKind) &&
						kind.Data.GetType() != typeof(PageKind) &&
						kind.Data.GetType() != typeof(PlatformKind))
					throw new Exception($"The given type {Format<Enum>.ExcValue(kind.Data)} is not a valid kind");
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

		/// <inheritdoc cref="IEquatable{BaseName}.Equals(BaseName)"/>
		/// <exception cref="BaseException"/>
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

		public static bool operator ==(BaseName? left, BaseName? right) => EqualityComparer<BaseName>.Default.Equals(left, right);
		public static bool operator !=(BaseName? left, BaseName? right) => !(left == right);
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseName<TKind> : BaseName, IEquatable<BaseName<TKind>?> where TKind : struct, Enum
	{
		/// <summary>
		/// The base <see cref="string"/> data for the <see cref="BaseName{TKind}"/> class
		/// </summary>
		[DefaultValue(Def.Name)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Include)]
		public new string Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseName{TKind}"/> class
		/// </summary>
		/// <inheritdoc cref="BaseName(string)"/>
		[JsonConstructor, MainConstructor]
		internal BaseName(string data) : base(data) => Log.Event(new StackFrame(true));
		
		/// <summary>
		/// Constructor for the <see cref="BaseName{TKind}"/> class
		/// </summary>
		/// <param name="kind">A <typeparamref name="TKind"/> kind</param>
		/// <inheritdoc cref="BaseName(string,Enum)"/>
		public BaseName(string name, TKind kind) : base(name, kind) => Log.Event(new StackFrame(true));

		/// <param name="kind">
		/// A <see cref="BaseType"/><![CDATA[<]]><typeparamref name="TKind"/><![CDATA[>]]> kind
		/// </param>
		/// <inheritdoc cref="BaseName{TKind}(string,TKind)"/>
		public BaseName(string name, BaseType<TKind> kind) : base(name, kind.Data) => Log.Event(new StackFrame(true));

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
				throw new BaseException(ex, sf);
			}

			return Out;
		}

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

		public static bool operator ==(BaseName<TKind>? left, BaseName<TKind>? right) => EqualityComparer<BaseName<TKind>>.Default.Equals(left, right);
		public static bool operator !=(BaseName<TKind>? left, BaseName<TKind>? right) => !(left == right);
	}
}
