namespace VData02.Bases
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseIdentity : Base<BaseID>, IEquatable<BaseIdentity?>, IIdentity
	{
		/// <summary>
		/// The <see cref="BaseName"/> name for this <see cref="BaseIdentity"/> object
		/// </summary>
		[DefaultValue(Def.Name), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BaseName Name { get; protected set; }

		/// <summary>
		/// The <see cref="BaseKind"/> kind for this <see cref="BaseIdentity"/> object
		/// </summary>
		[JsonProperty]
		public BaseKind Kind { get; protected set; }

		/// <summary>
		/// The <see cref="BaseID"/> ID for this <see cref="BaseIdentity"/> object
		/// </summary>
		[JsonProperty]
		public BaseID ID { get => Data; protected set => Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="BaseIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="BaseName"/> name value</param>
		/// <param name="kind">A <see cref="BaseKind"/> kind value</param>
		/// <param name="id">A <see cref="BaseID"/> ID value</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IdentityException"/>
		[JsonConstructor, MainConstructor]
		protected BaseIdentity([NotNull] BaseName name, [NotNull] BaseKind kind, [NotNull] BaseID id) : base(id)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, [kind.Data]);
				Kind = kind;
				ID = new(Kind, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseIdentity"/> class
		/// </summary>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseKind,BaseID)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] BaseKind kind, [NotNull] ulong subID) : this(new BaseName(Def.Name.Replace("Name", "Identity")), kind, new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, [kind.Data]);
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseKind,BaseID)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] BaseKind kind, [NotNull] long subID) : this(new BaseName(Def.Name.Replace("Name", "Identity")), kind, new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, [kind.Data]);
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="kind">An <see cref="Enum"/> kind</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseKind,BaseID)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] Enum kind, [NotNull] BaseID id) : this(new BaseName(Def.Name.Replace("Name", "Identity")), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, [kind]);
				ID = new(kind, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="kind">An <see cref="Enum"/> kind</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseKind,ulong)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] Enum kind, [NotNull] ulong subID) : this(new BaseName(Def.Name.Replace("Name", "Identity")), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, [kind]);
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="kind">An <see cref="Enum"/> kind</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseKind,long)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] Enum kind, [NotNull] long subID) : this(new BaseName(Def.Name.Replace("Name", "Identity")), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, [kind]);
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="name">A <see cref="string"/> name</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,Enum,ulong)"/>
		public BaseIdentity([NotNull] string name, [NotNull] BaseKind kind, [NotNull] BaseID id) : this(new BaseName(name), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				ID = new(kind, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="name">A <see cref="string"/> name</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseKind,ulong)"/>
		public BaseIdentity([NotNull] string name, [NotNull] BaseKind kind, [NotNull] ulong subID) : this(new BaseName(name), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="name">A <see cref="string"/> name</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseKind,long)"/>
		public BaseIdentity([NotNull] string name, [NotNull] BaseKind kind, [NotNull] long subID) : this(new BaseName(name), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="name">A <see cref="string"/> name</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,Enum,BaseID)"/>
		public BaseIdentity([NotNull] string name, [NotNull] Enum kind, [NotNull] BaseID id) : this(new BaseName(name), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				ID = new(kind, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="name">A <see cref="string"/> name</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,Enum,ulong)"/>
		public BaseIdentity([NotNull] string name, [NotNull] Enum kind, [NotNull] ulong subID) : this(new BaseName(name), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="name">A <see cref="string"/> name</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,Enum,long)"/>
		public BaseIdentity([NotNull] string name, [NotNull] Enum kind, [NotNull] long subID) : this(new BaseName(name), new BaseKind(kind), new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{BaseID}.Equals(object?)"/>
		/// <exception cref="IdentityException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseIdentity);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{BaseID}.Equals(Base{BaseID}?)"/>
		/// <exception cref="IdentityException"/>
		public bool Equals(BaseIdentity? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
								 EqualityComparer<BaseName>.Default.Equals(Name, other.Name) &&
								 EqualityComparer<BaseKind>.Default.Equals(Kind, other.Kind) &&
								 EqualityComparer<BaseID>.Default.Equals(ID, other.ID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{BaseID}.GetHashCode"/>
		/// <exception cref="IdentityException"/>
		public override int GetHashCode()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = HashCode.Combine(Name, Name.GetHashCode(), Kind, Kind.GetHashCode(), ID, ID.GetHashCode(), base.GetHashCode());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{BaseID}.ToString"/>
		/// <exception cref="IdentityException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Name} {Kind.ToString().ToLower()} (#{Data.ToString()[16..]})";
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
			finally
			{
				Out ??= "";
			}

			return Out;
		}

		/// <inheritdoc cref="Base{BaseID}.Dispose(bool)"/>
		/// <exception cref="IdentityException"/>
		protected override void Dispose(bool disposing)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (disposing)
				{
					Name.Dispose();
					Kind.Dispose();
					ID.Dispose();
				}

				base.Dispose(disposing);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{BaseID}.ToJSON(Formatting?)"/>
		/// <exception cref="IdentityException"/>
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
				throw new IdentityException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
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

		/// <inheritdoc cref="Base{BaseID}.op_Equality"/>
		/// <exception cref="IdentityException"/>
		public static bool operator ==(BaseIdentity? left, BaseIdentity? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<BaseID>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{BaseID}.op_Inequality"/>
		/// <exception cref="IdentityException"/>
		public static bool operator !=(BaseIdentity? left, BaseIdentity? right)
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
				throw new IdentityException(ex, new StackFrame(true));
			}

			return Out;
		}
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseIdentity<TKind> : BaseIdentity, IIdentity<TKind> where TKind : struct, Enum
	{
		[DefaultValue(Def.Name), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new BaseName<TKind> Name { get => (BaseName<TKind>)base.Name; protected set => base.Name = value; }

		[JsonProperty]
		public new BaseKind<TKind> Kind { get => (BaseKind<TKind>)base.Kind; protected set => base.Kind = value; }

		[JsonProperty]
		public new BaseID<TKind> ID { get => (BaseID<TKind>)base.ID; protected set => Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="BaseIdentity{TKind}"/> class
		/// </summary>
		/// <param name="name">A <see cref="BaseName{TKind}"/> name value</param>
		/// <param name="kind">A <see cref="BaseKind{TKind}"/> kind value</param>
		/// <param name="id">A <see cref="BaseID{TKind}"/> ID value</param>
		[JsonConstructor, MainConstructor]
		protected BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseKind<TKind> kind, [NotNull] BaseID<TKind> id) : base(name, kind, id) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseIdentity{TKind}"/> class
		/// </summary>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="BaseIdentity{TKind}(BaseName{TKind},BaseKind{TKind},BaseID{TKind})"/>
		/// <exception cref="IdentityException"/>
		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseKind<TKind> kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="BaseIdentity{TKind}(BaseName{TKind},BaseKind{TKind},ulong)"/>
		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseKind<TKind> kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] TKind kind, [NotNull] BaseID<TKind> id) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] TKind kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] TKind kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] string name, [NotNull] BaseKind<TKind> kind, [NotNull] BaseID<TKind> id) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				Kind = kind;
				ID = new(Kind, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] string name, [NotNull] BaseKind<TKind> kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] string name, [NotNull] BaseKind<TKind> kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] string name, [NotNull] TKind kind, [NotNull] BaseID<TKind> id) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, id.GetSubID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] string name, [NotNull] TKind kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		public BaseIdentity([NotNull] string name, [NotNull] TKind kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <summary>
		/// Empty constructor for the <see cref="BaseIdentity{TKind}"/> class
		/// </summary>
		[EmptyConstructor]
		public BaseIdentity() : this(new BaseName<TKind>(Def.Name.Replace("Name", "Identity")), new BaseKind<TKind>(Def<TKind>.Value), new BaseID<TKind>(0)) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="Base{BaseID}.Equals(object?)"/>
		/// <exception cref="IdentityException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseIdentity<TKind>);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{BaseID}.Equals(Base{BaseID}?)"/>
		/// <exception cref="IdentityException"/>
		public bool Equals(BaseIdentity<TKind>? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
								 EqualityComparer<BaseName<TKind>>.Default.Equals(Name, other.Name) &&
								 EqualityComparer<BaseKind<TKind>>.Default.Equals(Kind, other.Kind) &&
								 EqualityComparer<BaseID<TKind>>.Default.Equals(ID, other.ID);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{BaseID}.GetHashCode"/>
		/// <exception cref="IdentityException"/>
		public override int GetHashCode()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = HashCode.Combine(Name, Name.GetHashCode(), Kind, Kind.GetHashCode(), ID, ID.GetHashCode(), base.GetHashCode());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{BaseID}.ToString"/>
		/// <exception cref="IdentityException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Name} {Kind.ToString().ToLower()} (#{Data.ToString()[16..]})";
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
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

		/// <inheritdoc cref="Base{BaseID}.Dispose(bool)"/>
		/// <exception cref="IdentityException"/>
		protected override void Dispose(bool disposing)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (disposing)
				{
					Name.Dispose();
					Kind.Dispose();
					ID.Dispose();
				}

				base.Dispose(disposing);
				GC.Collect();
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{BaseID}.ToJSON(Formatting?)"/>
		/// <exception cref="IdentityException"/>
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
				throw new IdentityException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
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

		/// <inheritdoc cref="BaseIdentity.op_Equality"/>
		public static bool operator ==(BaseIdentity<TKind>? left, BaseIdentity<TKind>? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<BaseID>.Default.Equals(left.Data, right.Data);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="BaseIdentity.op_Inequality"/>
		public static bool operator !=(BaseIdentity<TKind>? left, BaseIdentity<TKind>? right)
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
				throw new IdentityException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
