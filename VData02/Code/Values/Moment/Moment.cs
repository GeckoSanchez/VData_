namespace VData02.Values
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Numerics;
	using Actions;
	using Attributes;
	using Bases;
	using Blazorise.Utilities;
	using Categories;
	using Exceptions;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class Moment : Base<DateTime>, IMoment, IEquatable<Moment?>, IAdditionOperators<Moment, Moment, Moment>, IAdditionOperators<Moment, DateTime, Moment>, ISubtractionOperators<Moment, Moment, Moment>, ISubtractionOperators<Moment, DateTime, Moment>
	{
		[JsonProperty]
		public new DateTime Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="Moment"/> class
		/// </summary>
		/// <param name="data">A <see cref="DateTime"/> data value</param>
		[JsonConstructor, MainConstructor]
		public Moment(DateTime data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="Moment"/> class
		/// </summary>
		/// <param name="data">A <see cref="Moment"/> object</param>
		[SelfConstructor]
		public Moment([NotNull] Moment data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="Moment"/> class
		/// </summary>
		/// <param name="date">A <see cref="Date"/> value</param>
		/// <param name="time">A <see cref="Time"/> value</param>
		/// <exception cref="MomentException"/>
		public Moment([NotNull] Date date, [NotNull] Time time) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new(date.Data, time.Data);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <param name="date">A <see cref="DateOnly"/> value</param>
		/// <param name="time">A <see cref="TimeOnly"/> value</param>
		/// <inheritdoc cref="Moment(Date,Time)"/>
		public Moment([NotNull] DateOnly date, [NotNull] TimeOnly time) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new(date, time);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Date,Time)"/>
		public Moment([NotNull] Date date) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new(date.Data, TimeOnly.MinValue);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(DateOnly,TimeOnly)"/>
		public Moment([NotNull] DateOnly date) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new(date, TimeOnly.MinValue);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Date,Time)"/>
		public Moment([NotNull] Time time) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new(DateOnly.MinValue, time.Data);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(DateOnly,TimeOnly)"/>
		public Moment([NotNull] TimeOnly time) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new(DateOnly.MinValue, time);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Date,Time)"/>
		/// <param name="year">A <see cref="Year"/> value</param>
		/// <param name="month">A <see cref="Month"/> value</param>
		/// <param name="day">A <see cref="Day"/> value</param>
		/// <param name="hour">An <see cref="Hour"/> value</param>
		/// <param name="minute">A <see cref="Minute"/> value</param>
		/// <param name="second">A <see cref="Second"/> value</param>
		/// <param name="millisecond">A <see cref="Millisecond"/> value</param>
		public Moment([NotNull] Year year, Month month, Day day, Hour hour, Minute minute, Second second, Millisecond millisecond) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(year.Data, month.Data, day.Data, hour.Data, minute.Data, second.Data, millisecond.Data);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Year year, Month month, Day day, Hour hour, Minute minute, Second second) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(year.Data, month.Data, day.Data, hour.Data, minute.Data, second.Data, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Year year, Month month, Day day, Hour hour, Minute minute) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(year.Data, month.Data, day.Data, hour.Data, minute.Data, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Year year, Month month, Day day, Hour hour) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(year.Data, month.Data, day.Data, hour.Data, 0, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Year year, Month month, Day day) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(year.Data, month.Data, day.Data, 0, 0, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Year year, Month month) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(year.Data, month.Data, 1, 0, 0, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Year year) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(year.Data, 1, 1, 0, 0, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Month month) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(1, month.Data, 1, 0, 0, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Day day) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(1, 1, day.Data, 0, 0, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Hour hour) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(1, 1, 1, hour.Data, 0, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Minute minute) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(1, 1, 1, 0, minute.Data, 0, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Second second) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(1, 1, 1, 0, 0, second.Data, 0);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Moment(Year,Month,Day,Hour,Minute,Second,Millisecond)"/>
		public Moment([NotNull] Millisecond millisecond) : this(DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new DateTime(1, 1, 1, 0, 0, 0, millisecond.Data);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}
		}

		public static implicit operator Moment(DateTime v) => new(v);
		public static implicit operator Moment(Date v) => new(v);
		public static implicit operator Moment(DateOnly v) => new(v);
		public static implicit operator Moment(Time v) => new(v);
		public static implicit operator Moment(TimeOnly v) => new(v);
		public static implicit operator Moment(Year v) => new(v);
		public static implicit operator Moment(Month v) => new(v);
		public static implicit operator Moment(Day v) => new(v);
		public static implicit operator Moment(Hour v) => new(v);
		public static implicit operator Moment(Minute v) => new(v);
		public static implicit operator Moment(Second v) => new(v);
		public static implicit operator Moment(Millisecond v) => new(v);

		/// <inheritdoc cref="Base{DateTime}.Equals(object?)"/>
		/// <exception cref="MomentException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as Moment);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateTime}.Equals(Base{DateTime}?)"/>
		/// <exception cref="MomentException"/>
		public bool Equals(Moment? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<DateTime>.Default.Equals(Data, other.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateTime}.GetHashCode"/>
		/// <exception cref="MomentException"/>
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
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateTime}.ToString"/>
		/// <exception cref="MomentException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Data:yyyy-MM-dd HH:mm:ss.fff}";
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
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

		/// <inheritdoc cref="Base{DateTime}.Dispose(bool)"/>
		/// <exception cref="MomentException"/>
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
				throw new MomentException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{DateTime}.ToJSON(Formatting?)"/>
		/// <exception cref="MomentException"/>
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
				throw new MomentException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
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

		/// <inheritdoc cref="Base{DateTime}.op_Equality"/>
		/// <exception cref="MomentException"/>
		public static bool operator ==(Moment? left, Moment? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<DateTime>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateTime}.op_Inequality"/>
		/// <exception cref="MomentException"/>
		public static bool operator !=(Moment? left, Moment? right)
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
				throw new MomentException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateTime}.op_Equality"/>
		/// <exception cref="MomentException"/>
		public static bool operator ==(Moment? left, DateTime? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<DateTime>.Default.Equals(left.Data, right.GetValueOrDefault(DateTime.MinValue));
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{DateTime}.op_Inequality"/>
		/// <exception cref="MomentException"/>
		public static bool operator !=(Moment? left, DateTime? right)
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
				throw new MomentException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="IAdditionOperators{Moment,Moment,Moment}.op_Addition"/>
		/// <exception cref="MomentException"/>
		public static Moment operator +(Moment left, Moment right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Moment Out;

			try
			{
				Out = new DateTime(left.Data.Ticks + right.Data.Ticks);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IAdditionOperators{Moment,Moment,Moment}.op_Addition"/>
		/// <exception cref="MomentException"/>
		public static Moment operator checked +(Moment left, Moment right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Moment Out;

			try
			{
				Out = new DateTime(checked(left.Data.Ticks + right.Data.Ticks));
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IAdditionOperators{Moment,DateTime,Moment}.op_Addition"/>
		/// <exception cref="MomentException"/>
		public static Moment operator +(Moment left, DateTime right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Moment Out;

			try
			{
				Out = new DateTime(left.Data.Ticks + right.Ticks);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IAdditionOperators{Moment,DateTime,Moment}.op_Addition"/>
		/// <exception cref="MomentException"/>
		public static Moment operator checked +(Moment left, DateTime right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Moment Out;

			try
			{
				Out = new DateTime(checked(left.Data.Ticks + right.Ticks));
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="ISubtractionOperators{Moment,Moment,Moment}.op_Subtraction"/>
		/// <exception cref="MomentException"/>
		public static Moment operator -(Moment left, Moment right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Moment Out;

			try
			{
				Out = new DateTime(left.Data.Ticks - right.Data.Ticks);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="ISubtractionOperators{Moment,Moment,Moment}.op_Subtraction"/>
		/// <exception cref="MomentException"/>
		public static Moment operator checked -(Moment left, Moment right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Moment Out;

			try
			{
				Out = new DateTime(checked(left.Data.Ticks - right.Data.Ticks));
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="ISubtractionOperators{Moment,DateTime,Moment}.op_Subtraction"/>
		/// <exception cref="MomentException"/>
		public static Moment operator -(Moment left, DateTime right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Moment Out;

			try
			{
				Out = new DateTime(left.Data.Ticks - right.Ticks);
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="ISubtractionOperators{Moment,DateTime,Moment}.op_Subtraction"/>
		/// <exception cref="MomentException"/>
		public static Moment operator checked -(Moment left, DateTime right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Moment Out;

			try
			{
				Out = new DateTime(checked(left.Data.Ticks - right.Ticks));
			}
			catch (Exception ex)
			{
				throw new MomentException(ex, sf);
			}

			return Out;
		}
	}
}
