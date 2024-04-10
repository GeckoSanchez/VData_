namespace VData02.Types
{
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class PageType : BaseKind<PageKind>
	{
		/// <summary>
		/// Main constructor for the <see cref="PageType"/> class
		/// </summary>
		/// <param name="data">A <see cref="PageKind"/> data value</param>
		[JsonConstructor, MainConstructor]
		public PageType([NotNull] PageKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="PageType"/> class
		/// </summary>
		/// <param name="data">A <see cref="BaseKind{PageKind}"/> data object</param>
		public PageType(BaseKind<PageKind> data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="PageType"/> kind object</param>
		/// <inheritdoc cref="PageType(BaseKind{PageKind})"/>
		public PageType(PageType data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="long"/> kind value</param>
		/// <inheritdoc cref="PageType(BaseKind{PageKind})"/>
		/// <exception cref="KindException"/>
		public PageType(long data) : this(Def.PageKind)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = Enum.GetValues<PageKind>().First(e => e.GetHashCode() == data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <summary>
		/// Empty constructor for the <see cref="PageType"/> class
		/// </summary>
		[EmptyConstructor]
		public PageType() : this(Def.PageKind) => Log.Event(new StackFrame(true)); public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as PageType);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="BaseKind{TType}.Equals(BaseKind{TType}?)"/>
		public bool Equals(PageType? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<PageKind>.Default.Equals(Data, other.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
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
				throw new KindException(ex, sf);
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
				throw new KindException(ex, sf);
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
				throw new KindException(ex, sf);
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
				throw new KindException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
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

		/// <inheritdoc cref="Base{Enum}.op_Equality"/>
		/// <exception cref="KindException"/>
		public static bool operator ==(PageType? left, PageType? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<PageKind>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{Enum}.op_Inequality"/>
		/// <exception cref="KindException"/>
		public static bool operator !=(PageType? left, PageType? right)
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
				throw new KindException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
