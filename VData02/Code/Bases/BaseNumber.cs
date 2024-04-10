namespace VData02.Bases
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Numerics;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Newtonsoft.Json;

	/// <summary>
	/// Base numeric <see cref="decimal"/> type
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public class BaseNumber : Base<decimal>, IEquatable<BaseNumber>, IAdditionOperators<BaseNumber, BaseNumber, BaseNumber>, ISubtractionOperators<BaseNumber, BaseNumber, BaseNumber>, IMultiplyOperators<BaseNumber, BaseNumber, BaseNumber>, IDivisionOperators<BaseNumber, BaseNumber, BaseNumber>, IModulusOperators<BaseNumber, BaseNumber, BaseNumber>, IIncrementOperators<BaseNumber>, IDecrementOperators<BaseNumber>, IComparisonOperators<BaseNumber, BaseNumber, bool>, INumber
	{
		[DefaultValue(0)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Include, ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
		public new decimal Data { get => base.Data; protected set => base.Data = value; }

		[DefaultValue(0.0)]
		public decimal Minimum { get; protected init; }

		[DefaultValue(256.0)]
		public decimal Maximum { get; protected init; }

		/// <summary>
		/// Main constructor for the <see cref="BaseNumber"/> class
		/// </summary>
		/// <param name="current">A <see cref="decimal"/> current data value</param>
		/// <param name="minimum">A <see cref="decimal"/> minimum data value</param>
		/// <param name="maximum">A <see cref="decimal"/> maximum data value</param>
		/// <exception cref="NumberException"/>
		[JsonConstructor, MainConstructor]
		public BaseNumber(decimal current, decimal minimum, decimal maximum) : base(decimal.Zero)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (minimum == maximum && minimum != current)
					throw new Exception($"The minimum value {Format<decimal>.ExcValue(minimum)} is equal to the maximum value {Format<decimal>.ExcValue(maximum)}");
				else if (current < minimum)
					throw new Exception($"The current value {Format<decimal>.ExcValue(current)} is lesser than the minimum value {Format<decimal>.ExcValue(minimum)}");
				else if (current > maximum)
					throw new Exception($"The current value {Format<decimal>.ExcValue(current)} is greater than the maximum value {Format<decimal>.ExcValue(maximum)}");
				else
				{
					Data = current;
					Minimum = minimum;
					Maximum = maximum;
				}
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseNumber"/> class
		/// </summary>
		/// <inheritdoc cref="BaseNumber(decimal,decimal,decimal)"/>
		public BaseNumber(decimal current, decimal maximum) : this(current, decimal.MinValue, maximum) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseNumber(decimal,decimal)"/>
		public BaseNumber(decimal current) : this(current, decimal.MinValue, decimal.MaxValue) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="BaseNumber"/> class
		/// </summary>
		/// <exception cref="NumberException"/>
		[EmptyConstructor]
		public BaseNumber() : this(decimal.Zero, decimal.MinValue, decimal.MaxValue) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Base{Decimal}.Equals(object?)"/>
		/// <exception cref="NumberException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseNumber);
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

		/// <inheritdoc cref="Base{Decimal}.Equals(Base{Decimal}?)"/>
		/// <exception cref="NumberException"/>
		public bool Equals(BaseNumber? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<decimal>.Default.Equals(Data, other.Data);
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

		/// <inheritdoc cref="Base{Decimal}.GetHashCode"/>
		/// <exception cref="NumberException"/>
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
				throw new BaseException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{Decimal}.ToJSON(Formatting?)"/>
		/// <exception cref="NumberException"/>
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
				throw new NumberException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
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

		/// <inheritdoc cref="Base{Decimal}.ToString"/>
		/// <exception cref="NumberException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"[{Data:D}|{Minimum:D}|{Maximum:D}]";
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
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

		/// <inheritdoc cref="Base{Decimal}.Dispose(bool)"/>
		/// <exception cref="NumberException"/>
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
				throw new NumberException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{Decimal}.op_Equality"/>
		/// <exception cref="NumberException"/>
		public static bool operator ==(BaseNumber? left, BaseNumber? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && EqualityComparer<BaseNumber>.Default.Equals(left, right);
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{Decimal}.op_Inequality"/>
		/// <exception cref="NumberException"/>
		public static bool operator !=(BaseNumber? left, BaseNumber? right)
		{
			bool Out;

			try
			{
				Out = !(left == right);
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="IAdditionOperators{BaseNumber,BaseNumber,BaseNumber}.op_Addition"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator +(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				Out = new(left.Data + right.Data);
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IAdditionOperators{BaseNumber,BaseNumber,BaseNumber}.op_Addition"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator checked +(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				Out = new(checked(left.Data + right.Data));
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="ISubtractionOperators{BaseNumber,BaseNumber,BaseNumber}.op_Subtraction"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator -(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				left.Data -= right.Data;
				Out = left;
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="ISubtractionOperators{BaseNumber,BaseNumber,BaseNumber}.op_Subtraction"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator checked -(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				left.Data = checked(left.Data - right.Data);
				Out = left;
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IMultiplyOperators{BaseNumber,BaseNumber,BaseNumber}.op_Multiply"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator *(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				left.Data *= right.Data;
				Out = left;
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IMultiplyOperators{BaseNumber,BaseNumber,BaseNumber}.op_Multiply"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator checked *(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				left.Data = checked(left.Data * right.Data);
				Out = left;
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDivisionOperators{BaseNumber,BaseNumber,BaseNumber}.op_Division"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator /(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				left.Data /= right.Data;
				Out = left;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDivisionOperators{BaseNumber,BaseNumber,BaseNumber}.op_Division"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator checked /(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				left.Data = checked(left.Data / right.Data);
				Out = left;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IModulusOperators{BaseNumber,BaseNumber,BaseNumber}.op_Modulus"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator %(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				left.Data %= right.Data;
				Out = left;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IIncrementOperators{BaseNumber}.op_Increment"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator ++(BaseNumber value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				value.Data += 1;
				Out = value;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IIncrementOperators{BaseNumber}.op_Increment"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator checked ++(BaseNumber value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				value.Data = checked(value.Data + 1);
				Out = value;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDecrementOperators{BaseNumber}.op_Decrement"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator --(BaseNumber value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				value.Data--;
				Out = value;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDecrementOperators{BaseNumber}.op_Decrement"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber operator checked --(BaseNumber value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber Out;

			try
			{
				value.Data = checked(value.Data - 1);
				Out = value;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparisonOperators{BaseNumber,BaseNumber,bool}.op_GreaterThan"/>
		/// <exception cref="NumberException"/>
		public static bool operator >(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = left.Data > right.Data;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparisonOperators{BaseNumber,BaseNumber,bool}.op_GreaterThanOrEqual"/>
		/// <exception cref="NumberException"/>
		public static bool operator >=(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = left.Data >= right.Data;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparisonOperators{BaseNumber,BaseNumber,bool}.op_LessThan"/>
		/// <exception cref="NumberException"/>
		public static bool operator <(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = left.Data < right.Data;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparisonOperators{BaseNumber,BaseNumber,bool}.op_LessThanOrEqual"/>
		/// <exception cref="NumberException"/>
		public static bool operator <=(BaseNumber left, BaseNumber right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = left.Data <= right.Data;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}
	}

	/// <summary>
	/// Base numeric <typeparamref name="TNum"/> type
	/// </summary>
	/// <typeparam name="TNum">
	/// The <typeparamref name="TNum"/> sub-type for this base number type
	/// </typeparam>
	[JsonObject(MemberSerialization.OptIn)]
	public class BaseNumber<TNum> : BaseNumber, IEquatable<BaseNumber<TNum>?>, IEqualityOperators<BaseNumber<TNum>, TNum, bool>, IAdditionOperators<BaseNumber<TNum>, BaseNumber<TNum>, BaseNumber<TNum>>, ISubtractionOperators<BaseNumber<TNum>, BaseNumber<TNum>, BaseNumber<TNum>>, IMultiplyOperators<BaseNumber<TNum>, BaseNumber<TNum>, BaseNumber<TNum>>, IDivisionOperators<BaseNumber<TNum>, BaseNumber<TNum>, BaseNumber<TNum>>, IModulusOperators<BaseNumber<TNum>, BaseNumber<TNum>, BaseNumber<TNum>>, IIncrementOperators<BaseNumber<TNum>>, IDecrementOperators<BaseNumber<TNum>>, IComparisonOperators<BaseNumber<TNum>, BaseNumber<TNum>, bool>, Categories.INumber<TNum> where TNum : notnull, System.Numerics.INumber<TNum>, IMinMaxValue<TNum>
	{
		[DefaultValue(0L)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Include, ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
		public new TNum Data { get => TNum.CreateTruncating(base.Data); protected set => base.Data = decimal.CreateTruncating(value); }

		[DefaultValue(0x0)]
		public new TNum Minimum { get; protected init; }

		[DefaultValue(1111_1111)]
		public new TNum Maximum { get; protected init; }

		/// <summary>
		/// Main constructor for the <see cref="BaseNumberConverter{TNum}"/> class
		/// </summary>
		/// <param name="current">The current <typeparamref name="TNum"/> data value</param>
		/// <param name="minimum">The minimum <typeparamref name="TNum"/> data value</param>
		/// <param name="maximum">The maximum <typeparamref name="TNum"/> data value</param>
		/// <exception cref="NumberException"/>
		[JsonConstructor, MainConstructor]
		public BaseNumber([NotNull] TNum current, [NotNull] TNum minimum, [NotNull] TNum maximum) : base(decimal.Zero, decimal.MinValue, decimal.MaxValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (minimum == maximum && minimum != current)
					throw new Exception($"The minimum value {Format<TNum>.ExcValue(minimum)} is equal to the maximum value {Format<TNum>.ExcValue(maximum)}");
				else if (current < minimum)
					throw new Exception($"The current value {Format<TNum>.ExcValue(current)} is lesser than the minimum value {Format<TNum>.ExcValue(minimum)}");
				else if (current > maximum)
					throw new Exception($"The current value {Format<TNum>.ExcValue(current)} is greater than the maximum value {Format<TNum>.ExcValue(maximum)}");
				else
				{
					Data = current;
					Minimum = minimum;
					Maximum = maximum;
				}
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseNumber{TNum}"/> class
		/// </summary>
		/// <inheritdoc cref="BaseNumber{TNum}(TNum,TNum,TNum)"/>
		public BaseNumber([NotNull] TNum current, [NotNull] TNum maximum) : this(current, TNum.MinValue, maximum) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseNumber{TNum}(TNum,TNum)"/>
		public BaseNumber([NotNull] TNum current) : this(current, TNum.MinValue, TNum.MaxValue) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="BaseNumber{TNum}"/> class
		/// </summary>
		/// <exception cref="NumberException"/>
		[EmptyConstructor]
		public BaseNumber() : this(TNum.Zero, TNum.MinValue, TNum.MaxValue) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Base{TNum}.Equals(object?)"/>
		/// <exception cref="NumberException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseNumber<TNum>);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TNum}.Equals(Base{TNum}?)"/>
		/// <exception cref="NumberException"/>
		public bool Equals(BaseNumber<TNum>? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && EqualityComparer<TNum>.Default.Equals(Data, other.Data);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TNum}.GetHashCode"/>
		/// <exception cref="NumberException"/>
		public override int GetHashCode()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = HashCode.Combine(Data, Data.GetHashCode(), Minimum, Minimum.GetHashCode(), Maximum, Maximum.GetHashCode(), base.GetHashCode());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TNum}.op_Equality"/>
		/// <exception cref="NumberException"/>
		public static bool operator ==(BaseNumber<TNum>? left, BaseNumber<TNum>? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && EqualityComparer<BaseNumber<TNum>>.Default.Equals(left, right);
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TNum}.op_Inequality"/>
		/// <exception cref="NumberException"/>
		public static bool operator !=(BaseNumber<TNum>? left, BaseNumber<TNum>? right)
		{
			bool Out;

			try
			{
				Out = !(left == right);
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TNum}.op_Equality"/>
		/// <exception cref="NumberException"/>
		public static bool operator ==(BaseNumber<TNum>? left, TNum? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && EqualityComparer<TNum>.Default.Equals(left.Data, right);
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{TNum}.op_Inequality"/>
		/// <exception cref="NumberException"/>
		public static bool operator !=(BaseNumber<TNum>? left, TNum? right)
		{
			bool Out;

			try
			{
				Out = !(left == right);
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="IAdditionOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Addition"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator +(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				Out = new(left.Data + right.Data);
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IAdditionOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Addition"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator checked +(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				Out = new(checked(left.Data + right.Data));
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="ISubtractionOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Subtraction"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator -(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				left.Data -= right.Data;
				Out = left;
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="ISubtractionOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Subtraction"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator checked -(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				left.Data = checked(left.Data - right.Data);
				Out = left;
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IMultiplyOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Multiply"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator *(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				left.Data *= right.Data;
				Out = left;
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IMultiplyOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Multiply"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator checked *(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				left.Data = checked(left.Data * right.Data);
				Out = left;
			}
			catch (NumberException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDivisionOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Division"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator /(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				left.Data /= right.Data;
				Out = left;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDivisionOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Division"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator checked /(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				left.Data = checked(left.Data / right.Data);
				Out = left;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IModulusOperators{BaseNumber<TNum>,BaseNumber<TNum>,BaseNumber<TNum>}.op_Modulus"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator %(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				left.Data %= right.Data;
				Out = left;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IIncrementOperators{BaseNumber<TNum>}.op_Increment"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator ++(BaseNumber<TNum> value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				value.Data += TNum.One;
				Out = value;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IIncrementOperators{BaseNumber<TNum>}.op_Increment"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator checked ++(BaseNumber<TNum> value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				value.Data = checked(value.Data + TNum.One);
				Out = value;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDecrementOperators{BaseNumber<TNum>}.op_Decrement"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator --(BaseNumber<TNum> value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				value.Data--;
				Out = value;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IDecrementOperators{BaseNumber<TNum>}.op_Decrement"/>
		/// <exception cref="NumberException"/>
		public static BaseNumber<TNum> operator checked --(BaseNumber<TNum> value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			BaseNumber<TNum> Out;

			try
			{
				value.Data = checked(value.Data - TNum.One);
				Out = value;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparisonOperators{BaseNumber<TNum>,BaseNumber<TNum>,bool}.op_GreaterThan"/>
		/// <exception cref="NumberException"/>
		public static bool operator >(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = left.Data > right.Data;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparisonOperators{BaseNumber<TNum>,BaseNumber<TNum>,bool}.op_GreaterThanOrEqual"/>
		/// <exception cref="NumberException"/>
		public static bool operator >=(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = left.Data >= right.Data;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparisonOperators{BaseNumber<TNum>,BaseNumber<TNum>,bool}.op_LessThan"/>
		/// <exception cref="NumberException"/>
		public static bool operator <(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = left.Data < right.Data;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IComparisonOperators{BaseNumber<TNum>,BaseNumber<TNum>,bool}.op_LessThanOrEqual"/>
		/// <exception cref="NumberException"/>
		public static bool operator <=(BaseNumber<TNum> left, BaseNumber<TNum> right)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = left.Data <= right.Data;
			}
			catch (Exception ex)
			{
				throw new NumberException(ex, sf);
			}

			return Out;
		}
	}
}
