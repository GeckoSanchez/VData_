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
	public class LinkIdentity : BaseIdentity<LinkKind>, IEquatable<LinkIdentity?>
	{
		/// <summary>
		/// The <see cref="LinkName"/> name for this <see cref="LinkIdentity"/> object
		/// </summary>
		[DefaultValue(Def.Name), JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public new LinkName Name { get => (LinkName)base.Name; protected set => base.Name = value; }

		/// <summary>
		/// The <see cref="LinkType"/> type/kind for this <see cref="LinkIdentity"/> object
		/// </summary>
		[JsonProperty]
		public new LinkType Kind { get => (LinkType)base.Kind; protected set => base.Kind = value; }

		/// <summary>
		/// The <see cref="LinkID"/> ID for this <see cref="LinkIdentity"/> object
		/// </summary>
		[JsonProperty]
		public new LinkID ID { get => (LinkID)base.ID; protected set => Data = value; }

		/// <summary>
		/// Main constructor for the <see cref="LinkIdentity"/> class
		/// </summary>
		/// <param name="name">A <see cref="LinkName"/> name object</param>
		/// <param name="kind">A <see cref="LinkType"/> type object</param>
		/// <param name="id">A <see cref="LinkID"/> ID object</param>
		[JsonConstructor, MainConstructor]
		protected LinkIdentity([NotNull] LinkName name, [NotNull] LinkType kind, [NotNull] LinkID id) : base(name, kind, id) => Log.Event(new StackFrame(true));

		/// <summary>
		/// Constructor for the <see cref="LinkIdentity"/> class
		/// </summary>
		/// <inheritdoc cref="LinkIdentity(LinkName,LinkType,LinkID)"/>
		/// <param name="subID">A <see cref="ulong"/> sub-ID</param>
		/// <exception cref="BaseException"/>
		/// <exception cref="IdentityException"/>
		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkType kind, [NotNull] ulong subID) : this()
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
		/// <inheritdoc cref="LinkIdentity(LinkName,LinkType,ulong)"/>
		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkType kind, [NotNull] long subID) : this()
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

		/// <param name="kind">A <see cref="LinkKind"/> kind</param>
		/// <param name="id">A <see cref="LinkID"/> ID</param>
		/// <inheritdoc cref="LinkIdentity(LinkName,LinkType,ulong)"/>
		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkKind kind, [NotNull] LinkID id) : this()
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
		/// <inheritdoc cref="LinkIdentity(LinkName,LinkKind,LinkID)"/>
		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkKind kind, [NotNull] ulong subID) : this()
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
		/// <inheritdoc cref="LinkIdentity(LinkName,LinkKind,LinkID)"/>
		public LinkIdentity([NotNull] LinkName name, [NotNull] LinkKind kind, [NotNull] long subID) : this()
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
		/// <param name="id">A <see cref="LinkID"/> ID object</param>
		/// <inheritdoc cref="LinkIdentity(LinkName,LinkType,ulong)"/>
		public LinkIdentity([NotNull] string name, [NotNull] LinkType kind, [NotNull] LinkID id) : this()
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
		/// <inheritdoc cref="LinkIdentity(LinkName,LinkType,ulong)"/>
		public LinkIdentity([NotNull] string name, [NotNull] LinkType kind, [NotNull] ulong subID) : this()
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
		/// <inheritdoc cref="LinkIdentity(LinkName,LinkType,long)"/>
		public LinkIdentity([NotNull] string name, [NotNull] LinkType kind, [NotNull] long subID) : this()
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

		/// <param name="kind">A <see cref="LinkKind"/> kind</param>
		/// <inheritdoc cref="LinkIdentity(string,LinkType,LinkID)"/>
		public LinkIdentity([NotNull] string name, [NotNull] LinkKind kind, [NotNull] LinkID id) : this()
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
		/// <inheritdoc cref="LinkIdentity(string,LinkKind,LinkID)"/>
		public LinkIdentity([NotNull] string name, [NotNull] LinkKind kind, [NotNull] ulong subID) : this()
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
		/// <inheritdoc cref="LinkIdentity(string,LinkKind,LinkID)"/>
		public LinkIdentity([NotNull] string name, [NotNull] LinkKind kind, [NotNull] long subID) : this()
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
		/// Empty constructor for the <see cref="LinkIdentity"/> class
		/// </summary>
		[EmptyConstructor]
		public LinkIdentity() : this(new LinkName(), new LinkType(), new LinkID()) => Log.Event(new StackFrame(true));

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as LinkIdentity);
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

		/// <inheritdoc cref="BaseIdentity{LinkKind}.Equals(BaseIdentity{LinkKind}?)"/>
		public bool Equals(LinkIdentity? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
								 EqualityComparer<LinkName>.Default.Equals(Name, other.Name) &&
								 EqualityComparer<LinkType>.Default.Equals(Kind, other.Kind) &&
								 EqualityComparer<LinkID>.Default.Equals(ID, other.ID);
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

		/// <inheritdoc cref="BaseIdentity{LinkKind}.op_Equality"/>
		public static bool operator ==(LinkIdentity? left, LinkIdentity? right)
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

		/// <inheritdoc cref="BaseIdentity{LinkKind}.op_Inequality"/>
		/// <exception cref="BaseException"/>
		public static bool operator !=(LinkIdentity? left, LinkIdentity? right)
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
