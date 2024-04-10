namespace VData02.Identities
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Bases;
	using Exceptions;
	using IDs;
	using Kinds;
	using Names;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class PageIdentity : BaseIdentity<PageKind>, IEquatable<PageIdentity?>
	{
		/// <summary>
		/// The <see cref="PageName"/> name for this <see cref="PageIdentity"/> object
		/// </summary>
		[DefaultValue(Def.Name), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new PageName Name { get => (PageName)base.Name; protected set => base.Name = value; }

		/// <summary>
		/// The <see cref="PageType"/> type/kind for this <see cref="PageIdentity"/> object
		/// </summary>
		[JsonProperty]
		public new PageType Kind { get => (PageType)base.Kind; protected set => base.Kind = value; }

		/// <summary>
		/// The <see cref="PageID"/> ID for this <see cref="PageIdentity"/> object
		/// </summary>
		[JsonProperty]
		public new PageID ID { get => (PageID)base.ID; protected set => Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="PageIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="PageName"/> name object</param>
		/// <param name="kind">A <see cref="PageType"/> type object</param>
		/// <param name="id">A <see cref="PageID"/> ID object</param>
		[JsonConstructor, MainConstructor]
		protected PageIdentity([NotNull] PageName name, [NotNull] PageType kind, [NotNull] PageID id) : base(name, kind, id) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="PageIdentity"/> class
		/// </summary>
		/// <inheritdoc cref="PageIdentity(PageName,PageType,PageID)"/>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IdentityException"/>
		public PageIdentity([NotNull] PageName name, [NotNull] PageType kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="PageIdentity(PageName,PageType,ulong)"/>
		public PageIdentity([NotNull] PageName name, [NotNull] PageType kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = kind;
				ID = new(Kind, subID);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="kind">A <see cref="PageKind"/> kind</param>
		/// <param name="id">A <see cref="PageID"/> ID</param>
		/// <inheritdoc cref="PageIdentity(PageName,PageType,ulong)"/>
		public PageIdentity([NotNull] PageName name, [NotNull] PageKind kind, [NotNull] PageID id) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, id.GetSubID());
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="PageIdentity(PageName,PageKind,PageID)"/>
		public PageIdentity([NotNull] PageName name, [NotNull] PageKind kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, subID);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="PageIdentity(PageName,PageKind,PageID)"/>
		public PageIdentity([NotNull] PageName name, [NotNull] PageKind kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
				ID = new(Kind, subID);
			}
			catch (Exception ex)
			{
				throw new IdentityException(ex, sf);
			}
		}

		/// <param name="name">A <see cref="string"/> name value</param>
		/// <param name="id">A <see cref="PageID"/> ID object</param>
		/// <inheritdoc cref="PageIdentity(PageName,PageType,ulong)"/>
		public PageIdentity([NotNull] string name, [NotNull] PageType kind, [NotNull] PageID id) : this()
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

		/// <param name="name">A <see cref="string"/> name value</param>
		/// <inheritdoc cref="PageIdentity(PageName,PageType,ulong)"/>
		public PageIdentity([NotNull] string name, [NotNull] PageType kind, [NotNull] ulong subID) : this()
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

		/// <param name="name">A <see cref="string"/> name value</param>
		/// <inheritdoc cref="PageIdentity(PageName,PageType,long)"/>
		public PageIdentity([NotNull] string name, [NotNull] PageType kind, [NotNull] long subID) : this()
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

		/// <param name="kind">A <see cref="PageKind"/> kind</param>
		/// <inheritdoc cref="PageIdentity(string,PageType,PageID)"/>
		public PageIdentity([NotNull] string name, [NotNull] PageKind kind, [NotNull] PageID id) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
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

		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <inheritdoc cref="PageIdentity(string,PageKind,PageID)"/>
		public PageIdentity([NotNull] string name, [NotNull] PageKind kind, [NotNull] ulong subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
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

		/// <param name="subID">A <see cref="long"/> sub-ID</param>
		/// <inheritdoc cref="PageIdentity(string,PageKind,PageID)"/>
		public PageIdentity([NotNull] string name, [NotNull] PageKind kind, [NotNull] long subID) : this()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Name = new(name, kind);
				Kind = new(kind);
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
		/// Empty constructor for the <see cref="PageIdentity"/> class
		/// </summary>
		[EmptyConstructor]
		public PageIdentity() : this(new PageName(), new PageType(), new PageID()) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as PageIdentity);
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

		/// <inheritdoc cref="BaseIdentity{PageKind}.Equals(BaseIdentity{PageKind}?)"/>
		public bool Equals(PageIdentity? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
								 EqualityComparer<PageName>.Default.Equals(Name, other.Name) &&
								 EqualityComparer<PageType>.Default.Equals(Kind, other.Kind) &&
								 EqualityComparer<PageID>.Default.Equals(ID, other.ID);
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

		/// <inheritdoc cref="BaseIdentity{PageKind}.op_Equality"/>
		public static bool operator ==(PageIdentity? left, PageIdentity? right)
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

		/// <inheritdoc cref="BaseIdentity{PageKind}.op_Inequality"/>
		/// <exception cref="BaseException"/>
		public static bool operator !=(PageIdentity? left, PageIdentity? right)
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
