namespace VData02.Values
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Bases;
	using Newtonsoft.Json;
	using VData02.Exceptions;

	[JsonObject(MemberSerialization.OptIn)]
	public class Time : Base<TimeOnly>, IEquatable<Time?>
	{
		[JsonProperty]
		public new TimeOnly Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="Time"/> class
		/// </summary>
		/// <param name="data">A <see cref="TimeOnly"/> time value</param>
		[JsonConstructor, MainConstructor]
		public Time(TimeOnly data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="Time"/> class
		/// </summary>
		/// <param name="data">A <see cref="DateTime"/> date <![CDATA[&]]> time value</param>
		public Time(DateTime data) : this(new TimeOnly(data.Hour, data.Minute, data.Second, data.Millisecond, data.Microsecond)) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Moment"/> moment object</param>
		/// <inheritdoc cref="Time(DateTime)"/>
		public Time(Moment data) : this(new TimeOnly(data.Data.Hour, data.Data.Minute, data.Data.Second, data.Data.Millisecond, data.Data.Microsecond)) => Log.Event(new StackFrame(true));

		/// <param name="hour">An <see cref="Hour"/> hour value</param>
		/// <param name="minute">An <see cref="Minute"/> minute value</param>
		/// <param name="second">An <see cref="Second"/> second value</param>
		/// <param name="millisecond">An <see cref="Millisecond"/> millisecond value</param>
		/// <inheritdoc cref="Time(DateTime)"/>
		public Time(Hour hour, Minute minute, Second second, Millisecond millisecond) : this(new TimeOnly(hour.Data, minute.Data, second.Data, millisecond.Data, 0)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Time(Hour,Minute,Second,Millisecond)"/>
		public Time(Hour hour, Minute minute, Second second) : this(new TimeOnly(hour.Data, minute.Data, second.Data, 0, 0)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Time(Hour,Minute,Second,Millisecond)"/>
		public Time(Hour hour, Minute minute) : this(new TimeOnly(hour.Data, minute.Data, 0, 0, 0)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Time(Hour,Minute,Second,Millisecond)"/>
		public Time(Hour hour) : this(new TimeOnly(hour.Data, 0, 0, 0, 0)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Time(Hour,Minute,Second,Millisecond)"/>
		public Time(Minute minute) : this(new TimeOnly(0, minute.Data, 0, 0, 0)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Time(Hour,Minute,Second,Millisecond)"/>
		public Time(Second second) : this(new TimeOnly(0, 0, second.Data, 0, 0)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Time(Hour,Minute,Second,Millisecond)"/>
		public Time(Millisecond millisecond) : this(new TimeOnly(0, 0, 0, millisecond.Data, 0)) => Log.Event(new StackFrame(true));

		public static implicit operator Time(DateTime v) => new(v);
		public static implicit operator Time(TimeOnly v) => new(v);
		public static implicit operator Time(Moment v) => new(v);
		public static implicit operator Time(Hour v) => new(v);
		public static implicit operator Time(Minute v) => new(v);
		public static implicit operator Time(Second v) => new(v);
		public static implicit operator Time(Millisecond v) => new(v);

		public override bool Equals(object? obj)
		{
			return Equals(obj as Time);
		}

		public bool Equals(Time? other)
		{
			return other is not null &&
						 base.Equals(other) &&
						 Data.Equals(other.Data);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(base.GetHashCode(), Data);
		}

		public override string ToString()
		{
			return base.ToString();
		}

		/// <inheritdoc cref="Base{TimeOnly}.Dispose(bool)"/>
		/// <exception cref="TimeException"/>
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
				throw new TimeException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{TimeOnly}.ToJSON(Formatting?)"/>
		/// <exception cref="TimeException"/>
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
				throw new TimeException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new TimeException(ex, sf);
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

		/// <inheritdoc cref="Base{TimeOnly}.op_Equality"/>
		/// <exception cref="TimeException"/>
		public static bool operator ==(Time? left, Time? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<TimeOnly>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new TimeException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TimeOnly}.op_Inequality"/>
		/// <exception cref="TimeException"/>
		public static bool operator !=(Time? left, Time? right)
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
				throw new TimeException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TimeOnly}.op_Equality"/>
		/// <exception cref="TimeException"/>
		public static bool operator ==(Time? left, TimeOnly? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && EqualityComparer<TimeOnly>.Default.Equals(left.Data, right.GetValueOrDefault(TimeOnly.MinValue));
			}
			catch (Exception ex)
			{
				throw new TimeException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TimeOnly}.op_Inequality"/>
		/// <exception cref="TimeException"/>
		public static bool operator !=(Time? left, TimeOnly? right)
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
				throw new TimeException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}