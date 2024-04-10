namespace VData02.Names
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class PageName : BaseName<PageKind>, IEquatable<PageName?>
	{
		/// <summary>
		/// Main constructor for the <see cref="PageName"/> class
		/// </summary>
		/// <param name="data">A <see cref="string"/> name value</param>
		[JsonConstructor, MainConstructor]
		protected PageName(string data) : base(data, Enum.GetValues<PageKind>()) => Log.Event(new StackFrame(true));
		
		/// <summary>
		/// Constructor for the <see cref="PageName"/> class
		/// </summary>
		/// <param name="data">A <see cref="string"/> name value</param>
		/// <param name="kinds">An array of <see cref="PageKind"/> kinds</param>
		public PageName(string data, params PageKind[] kinds) : base(data, kinds) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="PageName"/> class
		/// </summary>
		/// <param name="data">A <see cref="BaseName{PageKind}"/> name object</param>
		/// <param name="kinds">A <see cref="BaseKind{PageKind}"/> kind object</param>
		public PageName(BaseName<PageKind> name, BaseKind<PageKind> kind) : base(name, kind) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="PageName"/> class
		/// </summary>
		[EmptyConstructor]
		public PageName() : this("_DefaultPage_") => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as PageName);
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

		/// <inheritdoc cref="BaseName{PageKind}.Equals(BaseName{PageKind}?)"/>
		public bool Equals(PageName? other)
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

		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = Data[..int.Min(Data.Length, Def.MaxNameLength)];
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
				throw new NameException(ex, sf);
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

		public static bool operator ==(PageName? left, PageName? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<string>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new NameException(ex, new StackFrame(true));
			}

			return Out;
		}

		public static bool operator !=(PageName? left, PageName? right)
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
				throw new NameException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
