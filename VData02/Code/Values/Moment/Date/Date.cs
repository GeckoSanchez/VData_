namespace VData02.Values
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Bases;
	using Categories;
	using Exceptions;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class Date : Base<DateOnly>, IDate, IEquatable<Date?>
	{
		[JsonProperty]
		public new DateOnly Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="Date"/> class
		/// </summary>
		/// <param name="data">A <see cref="DateOnly"/> data value</param>
		[JsonConstructor, MainConstructor]
		public Date(DateOnly data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="Date"/> class
		/// </summary>
		/// <param name="data">A <see cref="DateTime"/> data value</param>
		public Date(DateTime data) : this(new DateOnly(data.Year, data.Month, data.Day)) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Date"/> date object</param>
		/// <inheritdoc cref="Date(DateTime)"/>
		[SelfConstructor]
		public Date(Date data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Date(DateTime)"/>
		/// <param name="year">A <see cref="Year"/> year object</param>
		/// <param name="month">A <see cref="Month"/> month object</param>
		/// <param name="day">A <see cref="Day"/> day object</param>
		public Date(Year year, Month month, Day day) : this(new DateOnly(year.Data, month.Data, day.Data)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Date(Year,Month,Day)"/>
		public Date(Year year, Month month) : this(new DateOnly(year.Data, month.Data, 1)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Date(Year,Month,Day)"/>
		public Date(Year year) : this(new DateOnly(year.Data, 1, 1)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Date(Year,Month,Day)"/>
		public Date(Month month) : this(new DateOnly(1, month.Data, 1)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Date(Year,Month,Day)"/>
		public Date(Day day) : this(new DateOnly(1, 1, day.Data)) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="Date"/> class
		/// </summary>
		[EmptyConstructor]
		public Date() : this(DateOnly.MinValue) => Log.Event(new StackFrame(true));

		public static implicit operator Date(DateOnly v) => new(v);
		public static implicit operator Date(DateTime v) => new(v);
		public static implicit operator Date(Moment v) => new(v);
		public static implicit operator Date(Year v) => new(v);
		public static implicit operator Date(Month v) => new(v);
		public static implicit operator Date(Day v) => new(v);

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as Date);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BaseException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateOnly}.Equals(Base{DateOnly}?)"/>
		/// <exception cref="DateException"/>
		public bool Equals(Date? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<DateOnly>.Default.Equals(Data, other.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DateException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateOnly}.GetHashCode"/>
		/// <exception cref="DateException"/>
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
				throw new DateException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateOnly}.ToString"/>
		/// <exception cref="DateException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Data:yyyy-MM-dd}";
			}
			catch (Exception ex)
			{
				throw new DateException(ex, sf);
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

		/// <inheritdoc cref="Base{DateOnly}.Dispose(bool)"/>
		/// <exception cref="DateException"/>
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
				throw new DateException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{DateOnly}.ToJSON(Formatting?)"/>
		/// <exception cref="DateException"/>
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
				throw new DateException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new DateException(ex, sf);
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

		/// <inheritdoc	 cref="Base{DateOnly}.op_Equality"/>
		/// <exception cref="DateException"/>
		public static bool operator ==(Date? left, Date? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<DateOnly>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new DateException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc	 cref="Base{DateOnly}.op_Inequality"/>
		/// <exception cref="DateException"/>
		public static bool operator !=(Date? left, Date? right)
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
				throw new DateException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}