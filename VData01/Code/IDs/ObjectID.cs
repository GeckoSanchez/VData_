namespace VData01.IDs
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class ObjectID : BaseID<ObjectKind>, IEquatable<ObjectID?>
	{
		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseID{TKind}"/> class
		/// </summary>
		/// <param name="Object">
		/// A <see cref="UInt128"/> Object value
		/// </param>
		/// <exception cref="IDException"/>
		[JsonConstructor, MainConstructor]
		internal ObjectID([NotNull] UInt128 Object) : base(Object) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Empty constructor for the <see cref="ObjectID"/> class
		/// </summary>
		public ObjectID() : base(Def.ObjectKind) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="ObjectID"/> class
		/// </summary>
		/// <param name="kind">A <see cref="ObjectKind"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="IDException"/>
		public ObjectID([NotNull] ObjectKind kind, [NotNull] ulong subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="ObjectID(ObjectKind,ulong)"/>
		public ObjectID([NotNull] ObjectKind kind, [NotNull] long subID) : base(kind, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="ObjectType"/> type</param>
		/// <inheritdoc cref="ObjectID(ObjectKind,ulong)"/>
		public ObjectID([NotNull] ObjectType type, [NotNull] ulong subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <param name="type">A <see cref="ObjectType"/> type</param>
		/// <inheritdoc cref="ObjectID(ObjectKind,long)"/>
		public ObjectID([NotNull] ObjectType type, [NotNull] long subID) : base(type, subID) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="ObjectID(ObjectKind,ulong)"/>
		public ObjectID([NotNull] ObjectKind kind) : base(kind) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="ObjectID(ObjectType,ulong)"/>
		public ObjectID([NotNull] ObjectType kind) : base(kind) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as ObjectID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="IEquatable{ObjectID}.Equals(ObjectID?)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="IDException"/>
		public bool Equals(ObjectID? other)
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
				throw new IDException(ex, sf);
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
				throw new IDException(ex, sf);
			}

			return Out;
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
				throw new IDException(ex, sf);
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

		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Data:X32}";
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
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

		public override ulong GetSubID()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			ulong Out;

			try
			{
				Out = ulong.Parse($"{this}"[16..], NumberStyles.HexNumber);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IDException(ex, sf);
			}

			return Out;
		}

		public static bool operator ==(ObjectID? left, ObjectID? right)
		{
			return EqualityComparer<ObjectID>.Default.Equals(left, right);
		}

		public static bool operator !=(ObjectID? left, ObjectID? right)
		{
			return !(left == right);
		}
	}
}
