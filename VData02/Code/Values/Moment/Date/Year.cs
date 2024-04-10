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
	public class Year : BaseNumber<int>, IEquatable<Year?>
	{
		[DefaultValue(1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
		public new int Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="Year"/> class
		/// </summary>
		/// <param name="data">A <see cref="int"/> data value</param>
		[JsonConstructor, MainConstructor]
		public Year(int data) : base(data, DateTime.MinValue.Year, DateTime.MaxValue.Year) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="Year"/> class
		/// </summary>
		/// <param name="data">A <see cref="DateTime"/> data value</param>
		public Year(DateTime data) : this(data.Year) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Moment"/> moment object</param>
		/// <inheritdoc cref="Year(DateTime)"/>
		public Year(Moment data) : this(data.Data.Year) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="DateOnly"/> date value</param>
		/// <inheritdoc cref="Year(DateTime)"/>
		public Year(DateOnly data) : this(data.Year) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Date"/> date object</param>
		/// <inheritdoc cref="Year(DateTime)"/>
		public Year(Date data) : this(data.Data.Year) => Log.Event(new StackFrame(true));

		/// <param name="data">A <see cref="Year"/> year value</param>
		/// <inheritdoc cref="Year(DateTime)"/>
		[SelfConstructor]
		public Year(Year data) : this(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="Year"/> class
		/// </summary>
		[EmptyConstructor]
		public Year() : this(DateTime.MinValue.Year) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Base{int}.Equals(object?)"/>
		/// <exception cref="DateException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as Year);
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
		public bool Equals(Year? other)
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
		public static bool operator ==(Year? left, Year? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && EqualityComparer<Year>.Default.Equals(left, right);
			}
			catch (Exception ex)
			{
				throw new DateException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{int}.op_Inequality"/>
		/// <exception cref="DateException"/>
		public static bool operator !=(Year? left, Year? right)
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
