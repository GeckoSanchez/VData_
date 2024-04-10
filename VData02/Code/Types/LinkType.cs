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
	public class LinkType : BaseKind<LinkKind>
	{
		/// <summary>
		/// Main constructor for the <see cref="LinkType"/> class
		/// </summary>
		/// <param name="data">A <see cref="LinkKind"/> data value</param>
		[JsonConstructor, MainConstructor]
		public LinkType([NotNull] LinkKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="LinkType"/> class
		/// </summary>
		/// <param name="data">A <see cref="BaseKind{LinkKind}"/> data object</param>
		public LinkType(BaseKind<LinkKind> data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="LinkType"/> kind object</param>
		/// <inheritdoc cref="LinkType(BaseKind{LinkKind})"/>
		public LinkType(LinkType data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="long"/> kind value</param>
		/// <inheritdoc cref="LinkType(BaseKind{LinkKind})"/>
		/// <exception cref="KindException"/>
		public LinkType(long data) : this(Def.LinkKind)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = Enum.GetValues<LinkKind>().First(e => e.GetHashCode() == data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, sf);
			}
		}

		/// <summary>
		/// Empty constructor for the <see cref="LinkType"/> class
		/// </summary>
		[EmptyConstructor]
		public LinkType() : this(Def.LinkKind) => Log.Event(new StackFrame(true)); public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as LinkType);
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
		public bool Equals(LinkType? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<LinkKind>.Default.Equals(Data, other.Data);
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
		public static bool operator ==(LinkType? left, LinkType? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<LinkKind>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new KindException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{Enum}.op_Inequality"/>
		/// <exception cref="KindException"/>
		public static bool operator !=(LinkType? left, LinkType? right)
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
