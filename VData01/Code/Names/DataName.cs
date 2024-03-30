namespace VData01.Names
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class DataName : BaseName<DataKind>, IEquatable<DataName?>
	{
		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="DataName"/> class
		/// </summary>
		/// <param name="name">A <see cref="string"/> name</param>
		/// <exception cref="NameException"/>
		[JsonConstructor, MainConstructor]
		internal DataName(string name) : base(name) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="DataName"/> class
		/// </summary>
		/// <param name="name">A <see cref="string"/> name</param>
		/// <param name="kind">A <see cref="DataKind"/> kind</param>
		/// <exception cref="NameException"/>
		public DataName(string name, DataKind kind) : base(name, kind) => Log.Event(new StackFrame(true));

		/// <param name="kind">A <see cref="DataType"/> type</param>
		/// <inheritdoc cref="DataName(string,DataKind)"/>
		public DataName(string data, DataType kind) : base(data, kind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as DataName);
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

		/// <inheritdoc cref="IEquatable{DataName}.Equals(DataName)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="NameException"/>
		public bool Equals(DataName? other)
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

		public static bool operator ==(DataName? left, DataName? right) => EqualityComparer<DataName>.Default.Equals(left, right);
		public static bool operator !=(DataName? left, DataName? right) => !(left == right);
	}
}
