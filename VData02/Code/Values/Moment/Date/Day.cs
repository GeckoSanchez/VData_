namespace VData02.Values
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class Day : BaseNumber<int>, IEquatable<Day?>
	{
		[DefaultValue(1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
		public new int Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="Day"/> class
		/// </summary>
		/// <param name="data">A <see cref="int"/> data value</param>
		[JsonConstructor, MainConstructor]
		public Day(int data) : base(data, DateTime.MinValue.Day, DateTime.MaxValue.Day) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="Day"/> class
		/// </summary>
		/// <param name="data">A <see cref="DateTime"/> data value</param>
		public Day(DateTime data) : this(data.Day) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Moment"/> moment object</param>
		/// <inheritdoc cref="Day(DateTime)"/>
		public Day(Moment data) : this(data.Data.Day) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="DateOnly"/> date value</param>
		/// <inheritdoc cref="Day(DateTime)"/>
		public Day(DateOnly data) : this(data.Day) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Date"/> date object</param>
		/// <inheritdoc cref="Day(DateTime)"/>
		public Day(Date data) : this(data.Data.Day) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Day"/> day value</param>
		/// <inheritdoc cref="Day(DateTime)"/>
		[SelfConstructor]
		public Day(Day data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="Day"/> class
		/// </summary>
		[EmptyConstructor]
		public Day() : this(DateTime.MinValue.Day) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Base{int}.Equals(object?)"/>
		/// <exception cref="DateException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as Day);
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

		/// <inheritdoc cref="Base{int}.Equals(Base{int}?)"/>
		/// <exception cref="DateException"/>
		public bool Equals(Day? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<int>.Default.Equals(Data, other.Data);
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

		/// <inheritdoc cref="Base{int}.GetHashCode"/>
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

		/// <inheritdoc cref="Base{int}.ToJSON(Formatting?)"/>
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

		/// <inheritdoc cref="Base{int}.ToString"/>
		/// <exception cref="DateException"/>	
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Data:D4}";
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

		/// <inheritdoc cref="Base{int}.Dispose(bool)"/>
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

		/// <inheritdoc cref="Base{int}.op_Equality"/>
		/// <exception cref="DateException"/>
		public static bool operator ==(Day? left, Day? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && EqualityComparer<Day>.Default.Equals(left, right);
			}
			catch (Exception ex)
			{
				throw new DateException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{int}.op_Inequality"/>
		/// <exception cref="DateException"/>
		public static bool operator !=(Day? left, Day? right)
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
