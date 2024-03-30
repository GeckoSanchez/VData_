using VData01.Exceptions;

namespace VData01.Bases
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Kinds;
	using Microsoft.Office.Interop.Excel;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseIdentity : Base<BaseID>, IEquatable<BaseIdentity?>, IBase, IIdentity
	{
		[JsonProperty]
		public BaseName Name { get; protected set; }

		/// <summary>
		/// The <see cref="BaseType"/> kind for this <see cref="BaseIdentity"/>
		/// </summary>
		[JsonProperty]
		public BaseType Type { get; protected init; }

		/// <summary>
		/// The <see cref="BaseID"/> ID for this <see cref="BaseIdentity"/>
		/// </summary>
		[JsonProperty]
		public BaseID ID { get => Data; protected init => Data = value; }

		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="BaseName"/> name</param>
		/// <param name="kind">A <see cref="BaseType"/> kind</param>
		/// <param name="id">A <see cref="BaseID"/> ID</param>
		/// <exception cref="IdentityException"/>
		[JsonConstructor, MainConstructor]
		internal BaseIdentity([NotNull] BaseName name, [NotNull] BaseType kind, [NotNull] BaseID id) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = name;
				Type = kind;
				ID = id;
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
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseType,BaseID)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] BaseType kind, [NotNull] ulong subID) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind);
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

		/// <param name="kind">A <see cref="Enum"/> kind</param>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseType)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] Enum kind, [NotNull] ulong subID) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind);
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

		/// <summary>
		/// Constructor for the <see cref="BaseIdentity"/> class
		/// </summary>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseType,BaseID)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] BaseType kind) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind);
				ID = new(kind);
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

		/// <param name="kind">A <see cref="Enum"/> kind</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseType)"/>
		public BaseIdentity([NotNull] BaseName name, [NotNull] Enum kind) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind);
				ID = new(kind);
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
		/// <inheritdoc cref="BaseIdentity(BaseName,BaseType)"/>
		public BaseIdentity([NotNull] string name, [NotNull] BaseType kind) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Type = new(kind);
				ID = new(kind);
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
		/// <inheritdoc cref="BaseIdentity(BaseName,Enum)"/>
		public BaseIdentity([NotNull] string name, [NotNull] Enum kind) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Type = new(kind);
				ID = new(kind);
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

		/// <param name="identity">A <see cref="BaseIdentity"/> identity</param>
		/// <inheritdoc cref="BaseIdentity(BaseName,Enum)"/>
		public BaseIdentity([NotNull] BaseIdentity identity) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = identity.Name;
				Type = identity.Type;
				ID = identity.ID;
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

		/// <param name="identity">A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="DataKind"/><![CDATA[>]]></param>
		/// <inheritdoc cref="BaseIdentity(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<DataKind> identity) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = identity.Name;
				Type = identity.Type;
				ID = identity.ID;
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

		/// <param name="identity">A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="DeviceKind"/><![CDATA[>]]></param>
		/// <inheritdoc cref="BaseIdentity(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<DeviceKind> identity) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = identity.Name;
				Type = identity.Type;
				ID = identity.ID;
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

		/// <param name="identity">A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="LinkKind"/><![CDATA[>]]></param>
		/// <inheritdoc cref="BaseIdentity(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<LinkKind> identity) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = identity.Name;
				Type = identity.Type;
				ID = identity.ID;
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

		/// <param name="identity">A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="ObjectKind"/><![CDATA[>]]></param>
		/// <inheritdoc cref="BaseIdentity(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<ObjectKind> identity) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = identity.Name;
				Type = identity.Type;
				ID = identity.ID;
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

		/// <param name="identity">A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="PageKind"/><![CDATA[>]]></param>
		/// <inheritdoc cref="BaseIdentity(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<PageKind> identity) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = identity.Name;
				Type = identity.Type;
				ID = identity.ID;
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

		/// <param name="identity">A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="PlatformKind"/><![CDATA[>]]></param>
		/// <inheritdoc cref="BaseIdentity(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<PlatformKind> identity) : base(new BaseID(0))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = identity.Name;
				Type = identity.Type;
				ID = identity.ID;
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

		/// <inheritdoc cref="IEquatable{BaseIdentity}.Equals(BaseIdentity)"/>
		/// <exception cref="BaseException"/>
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
						 EqualityComparer<BaseType>.Default.Equals(Type, other.Type) &&
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
				Out = HashCode.Combine(Name, Name.GetHashCode(), Type, Type.GetHashCode(), ID, ID.GetHashCode(), base.GetHashCode());
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

		/// <inheritdoc cref="Base{BaseID}.ToString"/>
		/// <exception cref="IdentityException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Name} {Type.ToString().ToLower()} (#{ID.ToString()[16..]})";
			}
			catch (BaseException)
			{
				throw;
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

		public static bool operator ==(BaseIdentity? left, BaseIdentity? right) => EqualityComparer<BaseIdentity>.Default.Equals(left, right);
		public static bool operator !=(BaseIdentity? left, BaseIdentity? right) => !(left == right);
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseIdentity<TKind> : BaseIdentity, IEquatable<BaseIdentity<TKind>?>, IIdentity<TKind>
		where TKind : struct, Enum
	{
		[DefaultValue(Def.Name)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new BaseName<TKind> Name { get => (BaseName<TKind>)base.Name; internal set => base.Name = value; }

		[JsonProperty]
		public new BaseType<TKind> Type { get => (BaseType<TKind>)base.Type; protected init => base.Type = value; }

		[DefaultValue(0)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new BaseID<TKind> ID { get => (BaseID<TKind>)Data; protected init => Data = value; }

		/// <summary>
		/// [INTERNAL] Main constructor for the <see cref="BaseIdentity{TKind}"/> class
		/// </summary>
		/// <param name="name">A <see cref="BaseName{TKind}"/> name</param>
		/// <param name="kind">A <see cref="BaseType{TKind}"/> kind</param>
		/// <param name="id">A <see cref="BaseID{TKind}"/> ID</param>
		/// <exception cref="IdentityException"/>
		[JsonConstructor, MainConstructor]
		internal BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseType<TKind> kind, [NotNull] BaseID<TKind> id) : base(name, kind, id) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="BaseIdentity{TKind}"/> class
		/// </summary>
		/// <param name="identity">A <see cref="BaseIdentity"/> identity</param>
		/// <exception cref="IdentityException"/>
		public BaseIdentity([NotNull] BaseIdentity identity) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>(Def<TKind>.Value))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (identity.Type.GetType() != typeof(TKind))
					throw new Exception($"The type {Format<BaseType>.ExcValue(identity.Type)} of the given identity {Format.ExcValue($"{identity}")} is not valid for a {GetType().Name}");
				else
				{
					Name = (BaseName<TKind>)identity.Name;
					Type = (BaseType<TKind>)identity.Type;
					ID = (BaseID<TKind>)identity.ID;
				}
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

		/// <param name="identity">
		/// A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="DataKind"/><![CDATA[>]]> identity
		/// </param>
		/// <inheritdoc cref="BaseIdentity{TKind}(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<DataKind> identity) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>(Def<TKind>.Value))
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (identity.Type.GetType() != typeof(TKind))
					throw new Exception($"The type {Format<BaseType>.ExcValue(identity.Type)} of the given identity {Format.ExcValue($"{identity}")} is not valid for a {GetType().Name}");
				else
				{
					Name = new BaseName<TKind>(identity.Name.Data);
					Type = new BaseType<TKind>(identity.Type.Data);
					ID = new BaseID<TKind>(identity.ID.Data);
				}
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

		/// <param name="identity">
		/// A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="DeviceKind"/><![CDATA[>]]> identity
		/// </param>
		/// <inheritdoc cref="BaseIdentity{TKind}(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<DeviceKind> identity) : base(identity)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (identity.Type.GetType() != typeof(TKind))
					throw new Exception($"The type {Format<BaseType>.ExcValue(identity.Type)} of the given identity {Format.ExcValue($"{identity}")} is not valid for a {GetType().Name}");
				else
				{
					Name = new BaseName<TKind>(identity.Name.Data);
					Type = new BaseType<TKind>(identity.Type.Data);
					ID = new BaseID<TKind>(identity.ID.Data);
				}
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

		/// <param name="identity">
		/// A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="LinkKind"/><![CDATA[>]]> identity
		/// </param>
		/// <inheritdoc cref="BaseIdentity{TKind}(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<LinkKind> identity) : base(identity)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (identity.Type.GetType() != typeof(TKind))
					throw new Exception($"The type {Format<BaseType>.ExcValue(identity.Type)} of the given identity {Format.ExcValue($"{identity}")} is not valid for a {GetType().Name}");
				else
				{
					Name = new BaseName<TKind>(identity.Name.Data);
					Type = new BaseType<TKind>(identity.Type.Data);
					ID = new BaseID<TKind>(identity.ID.Data);
				}
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

		/// <param name="identity">
		/// A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="ObjectKind"/><![CDATA[>]]> identity
		/// </param>
		/// <inheritdoc cref="BaseIdentity{TKind}(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<ObjectKind> identity) : base(identity)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (identity.Type.GetType() != typeof(TKind))
					throw new Exception($"The type {Format<BaseType>.ExcValue(identity.Type)} of the given identity {Format.ExcValue($"{identity}")} is not valid for a {GetType().Name}");
				else
				{
					Name = new BaseName<TKind>(identity.Name.Data);
					Type = new BaseType<TKind>(identity.Type.Data);
					ID = new BaseID<TKind>(identity.ID.Data);
				}
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

		/// <param name="identity">
		/// A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="PageKind"/><![CDATA[>]]> identity
		/// </param>
		/// <inheritdoc cref="BaseIdentity{TKind}(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<PageKind> identity) : base(identity)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (identity.Type.GetType() != typeof(TKind))
					throw new Exception($"The type {Format<BaseType>.ExcValue(identity.Type)} of the given identity {Format.ExcValue($"{identity}")} is not valid for a {GetType().Name}");
				else
				{
					Name = new BaseName<TKind>(identity.Name.Data);
					Type = new BaseType<TKind>(identity.Type.Data);
					ID = new BaseID<TKind>(identity.ID.Data);
				}
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

		/// <param name="identity">
		/// A <see cref="BaseIdentity"/><![CDATA[<]]><see cref="PlatformKind"/><![CDATA[>]]> identity
		/// </param>
		/// <inheritdoc cref="BaseIdentity{TKind}(BaseIdentity)"/>
		public BaseIdentity([NotNull] BaseIdentity<PlatformKind> identity) : base(identity)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (identity.Type.GetType() != typeof(TKind))
					throw new Exception($"The type {Format<BaseType>.ExcValue(identity.Type)} of the given identity {Format.ExcValue($"{identity}")} is not valid for a {GetType().Name}");
				else
				{
					Name = new BaseName<TKind>(identity.Name.Data);
					Type = new BaseType<TKind>(identity.Type.Data);
					ID = new BaseID<TKind>(identity.ID.Data);
				}
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

		public BaseIdentity([NotNull] BaseName name, [NotNull] BaseType kind) : this(name, kind, new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				ID = new((TKind)kind.Data);
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

		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseType<TKind> kind) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind.Data);
				Type = new(kind.Data);
				ID = new(kind.Data);
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

		public BaseIdentity([NotNull] BaseName name, [NotNull] Enum kind) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind);
				Type = new((TKind)kind);
				ID = new((TKind)kind);
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

		public BaseIdentity([NotNull] string name, [NotNull] BaseType kind) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, (TKind)kind.Data);
				Type = new((TKind)kind.Data);
				ID = new((TKind)kind.Data);
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

		public BaseIdentity([NotNull] string name, [NotNull] BaseType<TKind> kind) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind.Data);
				Type = new(kind.Data);
				ID = new(kind.Data);
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

		public BaseIdentity([NotNull] string name, [NotNull] Enum kind) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, (TKind)kind);
				Type = new((TKind)kind);
				ID = new((TKind)kind);
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

		public BaseIdentity([NotNull] string name, [NotNull] TKind kind) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Type = new(kind);
				ID = new(kind);
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

		public BaseIdentity([NotNull] BaseName name, [NotNull] BaseType kind, ulong subID) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind.Data);
				Type = new((TKind)kind.Data);
				ID = new((TKind)kind.Data, subID);
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

		public BaseIdentity([NotNull] BaseName name, [NotNull] BaseType<TKind> kind, ulong subID) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind.Data);
				Type = new(kind.Data);
				ID = new(kind.Data, subID);
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

		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseType kind, ulong subID) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind.Data);
				Type = new((TKind)kind.Data);
				ID = new((TKind)kind.Data, subID);
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

		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseType<TKind> kind, ulong subID) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind.Data);
				Type = new(kind.Data);
				ID = new(kind.Data, subID);
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

		public BaseIdentity([NotNull] BaseName name, [NotNull] Enum kind, ulong subID) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind);
				Type = new((TKind)kind);
				ID = new((TKind)kind, subID);
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

		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] Enum kind, ulong subID) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind);
				Type = new((TKind)kind);
				ID = new((TKind)kind, subID);
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

		public BaseIdentity([NotNull] BaseName name, [NotNull] TKind kind, ulong subID) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind);
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

		public BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] TKind kind, ulong subID) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind);
				Type = new(kind);
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

		internal BaseIdentity([NotNull] BaseName name, [NotNull] BaseType kind, [NotNull] BaseID id) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind.Data);
				Type = new((TKind)kind.Data);
				ID = new((TKind)kind.Data, id.GetSubID());
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

		internal BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseType kind, [NotNull] BaseID id) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind.Data);
				Type = new((TKind)kind.Data);
				ID = new((TKind)kind.Data, id.GetSubID());
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

		internal BaseIdentity([NotNull] BaseName name, [NotNull] BaseType<TKind> kind, [NotNull] BaseID id) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind.Data);
				Type = new((TKind)kind.Data);
				ID = new((TKind)kind.Data, id.GetSubID());
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

		internal BaseIdentity([NotNull] BaseName<TKind> name, [NotNull] BaseType<TKind> kind, [NotNull] BaseID id) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind.Data);
				Type = new((TKind)kind.Data);
				ID = new((TKind)kind.Data, id.GetSubID());
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

		internal BaseIdentity([NotNull] BaseName name, [NotNull] BaseType kind, [NotNull] BaseID<TKind> id) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, (TKind)kind.Data);
				Type = new((TKind)kind.Data);
				ID = new((TKind)kind.Data, id.GetSubID());
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

		internal BaseIdentity([NotNull] BaseName name, [NotNull] BaseType<TKind> kind, [NotNull] BaseID<TKind> id) : this(new BaseName<TKind>(Def.Name), new BaseType<TKind>(Def<TKind>.Value), new BaseID<TKind>())
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name.Data, kind.Data);
				Type = new(kind.Data);
				ID = new(kind.Data, id.GetSubID());
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

		/// <inheritdoc cref="IEquatable{BaseIdentity{TKind}}.Equals(BaseIdentity{TKind}?)"/>
		/// <exception cref="BaseException"/>
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
						 EqualityComparer<BaseType<TKind>>.Default.Equals(Type, other.Type) &&
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

		public override int GetHashCode()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = HashCode.Combine(Name, Name.GetHashCode(), Type, Type.GetHashCode(), ID, ID.GetHashCode(), base.GetHashCode());
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

		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Name} {Type.ToString().ToLower()} (#{ID.ToString()[16..]})";
			}
			catch (BaseException)
			{
				throw;
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

		public static bool operator ==(BaseIdentity<TKind>? left, BaseIdentity<TKind>? right) => EqualityComparer<BaseIdentity<TKind>>.Default.Equals(left, right);
		public static bool operator !=(BaseIdentity<TKind>? left, BaseIdentity<TKind>? right) => !(left == right);
	}
}
