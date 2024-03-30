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
	public class PageID : BaseID<PageKind>, IEquatable<PageID?>
	{
		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="Page">
		/// A <see cref="UInt128"/> Page value
		/// </param>
		/// <exception cref="IDException"/>
		[JsonConstructor, MainConstructor]
		internal PageID([NotNull] UInt128 Page) : base(Page) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="PageID"/> class
		/// </summary>
		public PageID() : base(Def.PageKind) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="PageID"/> class
		/// </summary>
		/// <param name="kind">A <see cref="PageKind"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="IDException"/>
		public PageID([NotNull] PageKind kind, [NotNull] ulong subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="PageID(PageKind,ulong)"/>
		public PageID([NotNull] PageKind kind, [NotNull] long subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="PageType"/> type</param>
		/// <inheritdoc cref="PageID(PageKind,ulong)"/>
		public PageID([NotNull] PageType type, [NotNull] ulong subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="PageType"/> type</param>
		/// <inheritdoc cref="PageID(PageKind,long)"/>
		public PageID([NotNull] PageType type, [NotNull] long subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="PageID(PageKind,ulong)"/>
		public PageID([NotNull] PageKind kind) : base(kind) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="PageID(PageType,ulong)"/>
		public PageID([NotNull] PageType kind) : base(kind) => Log.Event(new StackFrame(true));

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

		/// <inheritdoc cref="IEquatable{PageID}.Equals(PageID?)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="IDException"/>
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

		public static bool operator ==(PageID? left, PageID? right)
		{
			return EqualityComparer<PageID>.Default.Equals(left, right);
		}

		public static bool operator !=(PageID? left, PageID? right)
		{
			return !(left == right);
		}
	}
}
