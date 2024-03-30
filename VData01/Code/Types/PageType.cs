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
	public class PageType : BaseType<PageKind>, IEquatable<PageType?>
	{
		[JsonProperty]
		public new PageKind Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="PageType"/> class
		/// </summary>
		/// <param name="data">A <see cref="PageKind"/> kind</param>
		/// <exception cref="KindException"/>
		[JsonConstructor, MainConstructor]
		public PageType(PageKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="PageType"/> class
		/// </summary>
		/// <param name="data">A <see cref="PageType"/> Page value</param>
		/// <exception cref="KindException"/>
		public PageType(PageType data) : base(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="PageType"/> class
		/// </summary>
		[EmptyConstructor]
		public PageType() : base(Def.PageKind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
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
				throw new TypeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IEquatable{PageType}.Equals(PageType?)"/>
		/// <exception cref="TypeException"/>
		/// <exception cref="BaseException"/>
		public bool Equals(PageType? other)
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

		/// <inheritdoc cref="Base{PageType}.GetHashCode"/>
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

		/// <inheritdoc cref="Base{PageType}.ToJSON(Formatting?)"/>
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

		/// <inheritdoc cref="Base{PageType}.ToString"/>
		/// <exception cref="TypeException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string Out = "";

			try
			{
				foreach (var i in Enum.GetValues<PageKind>().Where(e => Data.HasFlag(e)))
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

		public static bool operator ==(PageType? left, PageType? right) => EqualityComparer<PageType>.Default.Equals(left, right);
		public static bool operator !=(PageType? left, PageType? right) => !(left == right);
	}
}
