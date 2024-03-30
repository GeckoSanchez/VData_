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
	public class PlatformType : BaseType<PlatformKind>, IEquatable<PlatformType?>
	{
		[JsonProperty]
		public new PlatformKind Data { get => base.Data; protected set => base.Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="PlatformType"/> class
		/// </summary>
		/// <param name="data">A <see cref="PlatformKind"/> kind</param>
		/// <exception cref="KindException"/>
		[JsonConstructor, MainConstructor]
		public PlatformType(PlatformKind data) : base(data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="PlatformType"/> class
		/// </summary>
		/// <param name="data">A <see cref="PlatformType"/> Platform value</param>
		/// <exception cref="KindException"/>
		public PlatformType(PlatformType data) : base(data.Data) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="PlatformType"/> class
		/// </summary>
		[EmptyConstructor]
		public PlatformType() : base(Def.PlatformKind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as PlatformType);
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

		/// <inheritdoc cref="IEquatable{PlatformType}.Equals(PlatformType?)"/>
		/// <exception cref="TypeException"/>
		/// <exception cref="BaseException"/>
		public bool Equals(PlatformType? other)
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

		/// <inheritdoc cref="Base{PlatformType}.GetHashCode"/>
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

		/// <inheritdoc cref="Base{PlatformType}.ToJSON(Formatting?)"/>
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

		/// <inheritdoc cref="Base{PlatformType}.ToString"/>
		/// <exception cref="TypeException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string Out = "";

			try
			{
				foreach (var i in Enum.GetValues<PlatformKind>().Where(e => Data.HasFlag(e)))
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

		public static bool operator ==(PlatformType? left, PlatformType? right) => EqualityComparer<PlatformType>.Default.Equals(left, right);
		public static bool operator !=(PlatformType? left, PlatformType? right) => !(left == right);
	}
}
