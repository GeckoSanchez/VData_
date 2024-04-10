namespace VData02.IDs
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

	[JsonObject(MemberSerialization.OptIn)]
	public class PageID : BaseID<PageKind>, IEquatable<PageID?>
	{
		/// <summary>
		/// [PROTECTED] Main constructor for the <see cref="PageID"/> class
		/// </summary>
		/// <param name="data">A <see cref="UInt128"/> data value</param>
		[JsonConstructor, MainConstructor]
		protected PageID([NotNull] UInt128 data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="PageID"/> clas
		/// </summary>
		/// <param name="kind">A <see cref="PageKind"/> kind</param>
		/// <exception cref="IDException"/>
		public PageID(PageKind kind) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{Random.Shared.NextInt64():X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="BaseKind{PageKind}"/> data Page</param>
		/// <inheritdoc cref="PageID(PageKind)"/>
		public PageID(BaseKind<PageKind> kind) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.Data.GetHashCode():X8}{Random.Shared.NextInt64():X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="PageID(PageKind)"/>
		public PageID(PageKind kind, ulong subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="PageID(PageKind)"/>
		public PageID(PageKind kind, long subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.GetType().GetHashCode():X8}{kind.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="BaseKind{PageKind}"/> kind Page</param>
		/// <inheritdoc cref="PageID(PageKind, ulong)"/>
		public PageID(BaseKind<PageKind> kind, ulong subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.Data.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="BaseKind{PageKind}"/> kind Page</param>
		/// <inheritdoc cref="PageID(PageKind, long)"/>
		public PageID(BaseKind<PageKind> kind, long subID) : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{kind.Data.GetType().GetHashCode():X8}{kind.Data.GetHashCode():X8}{subID:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		/// <summary>
		/// Empty constructor for the <see cref="PageID"/> class
		/// </summary>
		/// <exception cref="IDException"/>
		[EmptyConstructor]
		public PageID() : this(UInt128.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!UInt128.TryParse($"{Def.PageKind.GetType().GetHashCode():X8}{Def.PageKind.GetHashCode():X8}{0:X16}", NumberStyles.HexNumber, null, out UInt128 data))
					throw new Exception($"This ID could not be generated");

				Data = data;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}
		}

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as PageID);
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

		/// <inheritdoc cref="BaseID{TKind}.Equals(BaseID{TKind})"/>
		public bool Equals(PageID? other)
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
			catch (JsonException)
			{
				throw new IDException(Def.JSONException, sf);
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
				throw new IDException(ex, sf);
			}
		}

		/// <summary>
		/// Function to extract the sub-ID of the current <see cref="PageID"/> object
		/// </summary>
		/// <inheritdoc cref="BaseID.GetSubID"/>
		public override ulong GetSubID()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			ulong Out;

			try
			{
				Out = ulong.Parse($"{Data:X32}"[16..], NumberStyles.HexNumber);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="BaseID{TKind}.op_Equality"/>
		public static bool operator ==(PageID? left, PageID? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<UInt128>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new IDException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="BaseID{TKind}.op_Inequality"/>
		public static bool operator !=(PageID? left, PageID? right)
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
				throw new IDException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
