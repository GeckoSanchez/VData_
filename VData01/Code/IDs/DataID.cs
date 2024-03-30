namespace VData01.IDs
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class DataID : BaseID<DataKind>, IEquatable<DataID?>
	{
		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="data">
		/// A <see cref="UInt128"/> data value
		/// </param>
		/// <exception cref="IDException"/>
		[JsonConstructor, MainConstructor]
		internal DataID([NotNull] UInt128 data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="DataID"/> class
		/// </summary>
		public DataID() : base(Def.DataKind) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="DataID"/> class
		/// </summary>
		/// <param name="kind">A <see cref="DataKind"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="IDException"/>
		public DataID([NotNull] DataKind kind, [NotNull] ulong subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="DataID(DataKind,ulong)"/>
		public DataID([NotNull] DataKind kind, [NotNull] long subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="DataType"/> type</param>
		/// <inheritdoc cref="DataID(DataKind,ulong)"/>
		public DataID([NotNull] DataType type, [NotNull] ulong subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="DataType"/> type</param>
		/// <inheritdoc cref="DataID(DataKind,long)"/>
		public DataID([NotNull] DataType type, [NotNull] long subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="DataID(DataKind,ulong)"/>
		public DataID([NotNull] DataKind kind) : base(kind) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="DataID(DataType,ulong)"/>
		public DataID([NotNull] DataType kind) : base(kind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as DataID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IEquatable{DataID}.Equals(DataID?)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="IDException"/>
		public bool Equals(DataID? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && Data.Equals(other.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
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
				throw new IDException(ex, sf);
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
				throw new IDException(ex, sf);
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
				Out = $"{Data:X32}";
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
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

		public override ulong GetSubID()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			ulong Out;

			try
			{
				Out = ulong.Parse($"{this}"[16..], NumberStyles.HexNumber);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		public static bool operator ==(DataID? left, DataID? right)
		{
			return EqualityComparer<DataID>.Default.Equals(left, right);
		}

		public static bool operator !=(DataID? left, DataID? right)
		{
			return !(left == right);
		}
	}
}
