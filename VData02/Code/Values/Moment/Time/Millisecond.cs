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
	public class Millisecond : BaseNumber<int>, IEquatable<Millisecond?>
	{
		[DefaultValue(0)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
		public new int Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="Millisecond"/> class
		/// </summary>
		/// <param name="data">A <see cref="int"/> data value</param>
		/// <exception cref="TimeException"/>
		[JsonConstructor, MainConstructor]
		public Millisecond(int data) : base(data)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Data = new BaseNumber<int>(data, DateTime.MinValue.Millisecond, DateTime.MaxValue.Millisecond).Data;
			}
			catch (Exception ex)
			{
				throw new TimeException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="Millisecond"/> class
		/// </summary>
		/// <param name="data">A <see cref="DateTime"/> data value</param>
		public Millisecond(DateTime data) : this(data.Millisecond) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Time"/> time object</param>
		/// <inheritdoc cref="Millisecond(DateTime)"/>
		public Millisecond(Time data) : this(data.Data.Millisecond) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Moment"/> moment object</param>
		/// <inheritdoc cref="Millisecond(DateTime)"/>
		public Millisecond(Moment data) : this(data.Data.Millisecond) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="TimeOnly"/> time object</param>
		/// <inheritdoc cref="Millisecond(DateTime)"/>
		public Millisecond(TimeOnly data) : this(data.Millisecond) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Millisecond"/> Millisecond data</param>
		/// <inheritdoc cref="Millisecond(DateTime)"/>
		[SelfConstructor]
		public Millisecond(Millisecond data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="Millisecond"/> class
		/// </summary>
		[EmptyConstructor]
		public Millisecond() : this(DateTime.MinValue.Millisecond) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Base{int}.Equals(object?)"/>
		/// <exception cref="TimeException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as Millisecond);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new TimeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{int}.Equals(Base{int}?)"/>
		/// <exception cref="TimeException"/>
		public bool Equals(Millisecond? other)
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
				throw new TimeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{int}.GetHashCode"/>
		/// <exception cref="TimeException"/>
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
				throw new TimeException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{int}.ToJSON(Formatting?)"/>
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

		/// <inheritdoc cref="Base{int}.ToString"/>
		/// <exception cref="TimeException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Data:N3}";
			}
			catch (Exception ex)
			{
				throw new TimeException(ex, sf);
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

		/// <inheritdoc cref="Base{int}.op_Equality"/>
		/// <exception cref="TimeException"/>
		public static bool operator ==(Millisecond? left, Millisecond? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<int>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new TimeException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{int}.op_Inequality"/>
		/// <exception cref="TimeException"/>
		public static bool operator !=(Millisecond? left, Millisecond? right)
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

		/// <inheritdoc cref="Base{int}.op_Equality"/>
		/// <exception cref="TimeException"/>
		public static bool operator ==(Millisecond? left, int right)
		{
			bool Out;

			try
			{
				Out = left is not null && EqualityComparer<int>.Default.Equals(left.Data, right);
			}
			catch (Exception ex)
			{
				throw new TimeException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{int}.op_Inequality"/>
		/// <exception cref="TimeException"/>
		public static bool operator !=(Millisecond? left, int right)
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
