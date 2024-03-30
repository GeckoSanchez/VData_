namespace VData01.Types
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class DataType : BaseType<DataKind>, IEquatable<DataType?>
	{
		[JsonProperty]
		public new DataKind Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="DataType"/> class
		/// </summary>
		/// <param name="data">A <see cref="DataKind"/> kind</param>
		/// <exception cref="KindException"/>
		[JsonConstructor, MainConstructor]
		public DataType(DataKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="DataType"/> class
		/// </summary>
		/// <param name="data">A <see cref="DataType"/> data value</param>
		/// <exception cref="KindException"/>
		public DataType(DataType data) : base(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="DataType"/> class
		/// </summary>
		[EmptyConstructor]
		public DataType() : base(Def.DataKind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as DataType);
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

		/// <inheritdoc cref="IEquatable{DataType}.Equals(DataType?)"/>
		/// <exception cref="TypeException"/>
		/// <exception cref="BaseException"/>
		public bool Equals(DataType? other)
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

		/// <inheritdoc cref="Base{DataType}.GetHashCode"/>
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

		/// <inheritdoc cref="Base{DataType}.ToJSON(Formatting?)"/>
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

		/// <inheritdoc cref="Base{DataType}.ToString"/>
		/// <exception cref="TypeException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string Out = "";

			try
			{
				foreach (var i in Enum.GetValues<DataKind>().Where(e => Data.HasFlag(e)))
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

		public static bool operator ==(DataType? left, DataType? right) => EqualityComparer<DataType>.Default.Equals(left, right);
		public static bool operator !=(DataType? left, DataType? right) => !(left == right);
	}
}
