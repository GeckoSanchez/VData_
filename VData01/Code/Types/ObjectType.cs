namespace VData01.Types
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Resources;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class ObjectType : BaseType<ObjectKind>, IEquatable<ObjectType?>
	{
		[JsonProperty]
		public new ObjectKind Data { get => base.Data; protected set => base.Data = value; }

		public static readonly ObjectType Database = new(ObjectKind.Database);
		public static readonly ObjectType Field = new(ObjectKind.Field);
		public static readonly ObjectType None = new(ObjectKind.None);
		public static readonly ObjectType Object = new(ObjectKind.Object);
		public static readonly ObjectType Table = new(ObjectKind.Table);
		public static readonly ObjectType User = new(ObjectKind.User);

		/// <summary>
		/// Main constructor for the <see cref="ObjectType"/> class
		/// </summary>
		/// <param name="data">A <see cref="ObjectKind"/> kind</param>
		/// <exception cref="KindException"/>
		[JsonConstructor, MainConstructor]
		public ObjectType(ObjectKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="ObjectType"/> class
		/// </summary>
		/// <param name="data">A <see cref="ObjectType"/> Object value</param>
		/// <exception cref="KindException"/>
		public ObjectType(ObjectType data) : base(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="ObjectType"/> class
		/// </summary>
		[EmptyConstructor]
		public ObjectType() : base(Def.ObjectKind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;
			
			ResourceManager mgr = new(typeof(Values));
			mgr.GetString("AppName");

			try
			{
				Out = Equals(obj as ObjectType);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new TypeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IEquatable{ObjectType}.Equals(ObjectType?)"/>
		/// <exception cref="TypeException"/>
		/// <exception cref="BaseException"/>
		public bool Equals(ObjectType? other)
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
				throw new TypeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{ObjectType}.GetHashCode"/>
		/// <exception cref="TypeException"/>
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
				throw new TypeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{ObjectType}.ToJSON(Formatting?)"/>
		/// <exception cref="TypeException"/>
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
				throw new TypeException(ex, sf);
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

		/// <inheritdoc cref="Base{ObjectType}.ToString"/>
		/// <exception cref="TypeException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string Out = "";

			try
			{
				foreach (var i in Enum.GetValues<ObjectKind>().Where(e => Data.HasFlag(e)))
					Out += $"{Enum.GetName(i)}-";

				Out = Out.TrimEnd('-');
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new TypeException(ex, sf);
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

		public static bool operator ==(ObjectType? left, ObjectType? right) => EqualityComparer<ObjectType>.Default.Equals(left, right);
		public static bool operator !=(ObjectType? left, ObjectType? right) => !(left == right);
	}
}
