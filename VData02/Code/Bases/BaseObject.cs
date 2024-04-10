namespace VData02.Bases
{
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Identities;
	using IDs;
	using Names;
	using Newtonsoft.Json;
	using Properties;
	using Types;
	using Values;

	[JsonObject(MemberSerialization.OptIn, ItemNullValueHandling = NullValueHandling.Ignore)]
	public class BaseObject : Base<ObjectIdentity>, IObject, IActivatable, ICreatable, IDeletable, IEditable, IInitializable, IEquatable<BaseObject?>, ILinkable
	{
		[JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
		public ObjectIdentity Identity { get => Data; set => Data = value; }

		[DefaultValue(true)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsActive { get; internal set; }

		[JsonProperty("Initialization moment")]
		public Moment IMoment { get; protected init; }

		[JsonProperty("Creation moment")]
		public Moment? CMoment { get; internal set; }

		[JsonProperty("Edit moments")]
		public HashSet<IMoment> EMoments { get; internal set; }

		[JsonProperty("Deletion moment")]
		public Moment? DMoment { get; internal set; }

		/// <summary>
		/// Main constructor for the <see cref="BaseObject"/> class
		/// </summary>
		/// <param name="identity">An <see cref="ObjectIdentity"/> identity value</param>
		/// <param name="isactive">Whether this <see cref="BaseObject"/> is active, or not</param>
		/// <param name="imoment">An initialization <see cref="Moment"/> value</param>
		/// <param name="cmoment">A creation <see cref="Moment"/>? value</param>
		/// <param name="emoments">An array of <see cref="Moment"/> values</param>
		/// <param name="dmoment">A deletion <see cref="Moment"/>? value</param>
		/// <exception cref="ObjectException"/>
		[JsonConstructor, MainConstructor]
		protected BaseObject([NotNull] ObjectIdentity identity, [NotNull] bool isactive, [NotNull] Moment imoment, [AllowNull] Moment? cmoment, HashSet<IMoment> emoments, [AllowNull] Moment? dmoment) : base(identity)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				IsActive = isactive;
				IMoment = imoment;
				CMoment = cmoment;
				EMoments = emoments;
				DMoment = dmoment;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseObject"/> class
		/// </summary>
		/// <inheritdoc cref="BaseObject(ObjectIdentity, bool, Moment, Moment?, HashSet{IMoment}, Moment?)"/>
		public BaseObject([NotNull] ObjectIdentity identity) : this(identity, true, DateTime.Now, null, [], null) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseObject(ObjectIdentity)"/>
		/// <param name="name">A <see cref="ObjectName"/> name value</param>
		/// <param name="type">A <see cref="ObjectType"/> type value</param>
		/// <param name="id">A <see cref="ObjectID"/> ID value</param>
		public BaseObject([NotNull] ObjectName name, [NotNull] ObjectType type, [NotNull] ObjectID id) : this(new(), true, DateTime.Now, null, [], null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, type, new ObjectID(type, id.GetSubID()));
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseObject(ObjectName,ObjectType,ObjectID)"/>
		public BaseObject([NotNull] ObjectName name, [NotNull] ObjectType type) : this(new(), true, DateTime.Now, null, [], null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, type, new ObjectID(type));
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseObject(ObjectName,ObjectType,ObjectID)"/>
		public BaseObject([NotNull] ObjectName name) : this(new(), true, DateTime.Now, null, [], null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, new ObjectType(), new ObjectID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		/// <summary>
		/// Empty constructor for the <see cref="BaseObject"/> class
		/// </summary>
		[EmptyConstructor]
		public BaseObject() : this(new(), true, DateTime.Now, null, [], null) => Log.Event(new StackFrame(true));

		public virtual void Activate()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (IsActive)
					throw new Exception($"The {Identity} could not be activated, since it was already active");
				else
					IsActive = true;
			}
			catch (Exception ex)
			{
				throw new ActivationException(ex, sf);
			}
		}

		public virtual void Deactivate()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!IsActive)
					throw new Exception($"The {Identity} could not be deactivated, since it was already inactive");
				else
					IsActive = false;
			}
			catch (Exception ex)
			{
				throw new ActivationException(ex, sf);
			}
		}

		public virtual void Create()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			FileStream? fs = null;
			StreamWriter? sw = null;

			try
			{
				if (CMoment != null)
					throw new Exception($"The {Identity} cannot be created, since it has already been created on the {IMoment.ToString}");

				CMoment = new(DateTime.Now);
				fs = File.Create($"{Def.ObjectsDir}/{Identity.Kind}s/{Identity.ID.ToString()[16..]}.json");
				
				string json = ToJSON();

				using (sw = new(fs, Def.Encoding) { AutoFlush = true })
				{
					sw.Write(json);
					fs.Flush(true);
				}
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new CreationException(ex, sf);
			}
			finally
			{
				sw?.Dispose();
				fs?.Close();
			}
		}

		public virtual bool TryCreate()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;
			FileStream? fs = null;
			StreamWriter? sw = null;

			try
			{
				fs = File.Create($"{Def.ObjectsDir}/{Identity.Kind}s/{Identity.ID.ToString()[16..]}.json");
				string json = ToJSON();

				using (sw = new(fs, Def.Encoding) { AutoFlush = true })
					sw.Write(json);

				Out = true;
			}
			catch (Exception ex)
			{
				Log.Exception(new ObjectException(ex, sf));
				Out = false;
			}
			finally
			{
				sw?.Dispose();
				fs?.Dispose();
			}

			return Out;
		}

		public virtual void Delete()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				File.Delete($"{Def.ObjectsDir}/{Identity.Kind}s/{Identity.ID.ToString()[16..]}.json");
			}
			catch (Exception ex)
			{
				throw new DeletionException(ex, sf);
			}
		}

		public virtual bool TryDelete()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				File.Delete($"{Def.ObjectsDir}/{Identity.Kind}s/{Identity.ID.ToString()[16..]}.json");
				Out = true;
			}
			catch (Exception ex)
			{
				Log.Exception(new ObjectException(ex, sf));
				Out = false;
			}

			return Out;
		}

		public void Edit(BaseName value)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new((ObjectName)value, Identity.Kind, Identity.ID);
			}
			catch (Exception ex)
			{
				throw new DeletionException(ex, sf);
			}
		}

		public bool TryEdit(BaseName value)
		{
			throw new NotImplementedException();
		}

		public void Edit(BaseKind value)
		{
			throw new NotImplementedException();
		}

		public bool TryEdit(BaseKind value)
		{
			throw new NotImplementedException();
		}

		public void Edit(BaseID value)
		{
			throw new NotImplementedException();
		}

		public void Edit(ulong subID)
		{
			throw new NotImplementedException();
		}

		public bool TryEdit(BaseID value)
		{
			throw new NotImplementedException();
		}

		public bool TryEdit(ulong subID)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc cref="Base{ObjectIdentity}.Equals(object?)"/>
		/// <exception cref="ObjectException"/>
		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseObject);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{ObjectIdentity}.Equals(Base{ObjectIdentity}?)"/>
		/// <exception cref="ObjectException"/>
		public bool Equals(BaseObject? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && IsActive.Equals(other.IsActive) &&
						 EqualityComparer<ObjectIdentity>.Default.Equals(Identity, other.Identity) &&
						 EqualityComparer<Moment>.Default.Equals(IMoment, other.IMoment) &&
						 EqualityComparer<Moment?>.Default.Equals(CMoment, other.CMoment) &&
						 EqualityComparer<Moment?>.Default.Equals(DMoment, other.DMoment);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{ObjectIdentity}.GetHashCode"/>
		/// <exception cref="ObjectException"/>
		public override int GetHashCode()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			int Out;

			try
			{
				Out = HashCode.Combine(Identity, IsActive, IMoment, CMoment, DMoment, base.GetHashCode());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="Base{ObjectIdentity}.ToString"/>
		/// <exception cref="ObjectException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = Identity.ToString();
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
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

		/// <inheritdoc cref="Base{ObjectIdentity}.Dispose(bool)"/>
		/// <exception cref="ObjectException"/>
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
				throw new ObjectException(ex, sf);
			}
		}

		/// <inheritdoc cref="Base{ObjectIdentity}.ToJSON(Formatting?)"/>
		/// <exception cref="ObjectException"/>
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
				throw new ObjectException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
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

		/// <inheritdoc cref="Base{ObjectIdentity}.op_Equality"/>
		/// <exception cref="ObjectException"/>
		public static bool operator ==(BaseObject? left, BaseObject? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<BaseObject>.Default.Equals(left, right);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="Base{ObjectIdentity}.op_Inequality"/>
		/// <exception cref="ObjectException"/>
		public static bool operator !=(BaseObject? left, BaseObject? right)
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
				throw new ObjectException(ex, new StackFrame(true));
			}

			return Out;
		}
	}

	[JsonObject(MemberSerialization.OptIn, ItemNullValueHandling = NullValueHandling.Ignore)]
	[method: JsonConstructor, MainConstructor]
	public class BaseObject<TLinked>([NotNull] ObjectIdentity data, bool isactive, Moment imoment, HashSet<BaseID> linkedids, Moment? cmoment, HashSet<IMoment> emoments, Moment? dmoment) : BaseObject(data, isactive, imoment, cmoment, emoments, dmoment), ILinkable<TLinked>, IEquatable<BaseObject<TLinked>?> where TLinked : BaseObject
	{
		[JsonProperty]
		public HashSet<BaseID> LinkedIDs { get; protected set; } = linkedids;

		public BaseObject([NotNull] ObjectIdentity data, bool isactive, Moment imoment, Moment? cmoment, Moment? dmoment) : this(data, isactive, imoment, [], cmoment, [], dmoment) => Log.Event(new StackFrame(true));

		protected BaseObject([NotNull] ObjectIdentity identity, [NotNull] bool isactive, [NotNull] Moment imoment, [AllowNull] Moment? cmoment, HashSet<IMoment> emoments, [AllowNull] Moment? dmoment) : this(identity, isactive, imoment, [], cmoment, emoments, dmoment) => Log.Event(new StackFrame(true));

		public BaseObject([NotNull] ObjectIdentity identity) : this(identity, true, DateTime.Now, null, [], null) => Log.Event(new StackFrame(true));

		public BaseObject([NotNull] ObjectName name, [NotNull] ObjectType type, [NotNull] ObjectID id) : this(new ObjectIdentity(), true, DateTime.Now, null, [], null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, type, id);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		public BaseObject([NotNull] ObjectName name, [NotNull] ObjectType type) : this(new ObjectIdentity(), true, DateTime.Now, null, [], null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, type, new ObjectID(type));
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		public BaseObject([NotNull] ObjectName name) : this(new ObjectIdentity(), true, DateTime.Now, null, [], null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, new ObjectType(), new ObjectID());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}


		public override void Activate()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (IsActive)
					throw new Exception($"The {Identity} could not be activated, since it was already active");
				else
					IsActive = true;
			}
			catch (Exception ex)
			{
				throw new ActivationException(ex, sf);
			}
		}

		public override void Deactivate()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!IsActive)
					throw new Exception($"The {Identity} could not be deactivated, since it was already inactive");
				else
					IsActive = false;
			}
			catch (Exception ex)
			{
				throw new ActivationException(ex, sf);
			}
		}

		public override void Create()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			FileStream? fs = null;
			StreamWriter? sw = null;

			try
			{
				var di = Directory.CreateDirectory($"{Def.ObjectsDir}/{Identity.Kind}s");
				fs = File.Create($"{di.FullName}/{Identity.ID.ToString()[16..]}.json");
				string json = ToJSON();

				using (sw = new(fs, Def.Encoding) { AutoFlush = true })
				{
					sw.Write(json);
					fs.Flush(true);
				}
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new CreationException(ex, sf);
			}
			finally
			{
				sw?.Close();
				fs?.Close();
			}
		}

		public override void Delete()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				File.Delete($"{Def.ObjectsDir}/{Identity.Kind}s/{Identity.ID.ToString()[16..]}.json");
			}
			catch (Exception ex)
			{
				throw new DeletionException(ex, sf);
			}
		}

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as BaseObject<TLinked>);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}

			return Out;
		}

		/// <inheritdoc cref="BaseObject.Equals(BaseObject?)"/>
		public bool Equals(BaseObject<TLinked>? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && IsActive.Equals(other.IsActive) &&
						 EqualityComparer<ObjectIdentity>.Default.Equals(Identity, other.Identity) &&
						 EqualityComparer<Moment>.Default.Equals(IMoment, other.IMoment) &&
						 EqualityComparer<Moment?>.Default.Equals(CMoment, other.CMoment) &&
						 EqualityComparer<Moment?>.Default.Equals(DMoment, other.DMoment) &&
						 EqualityComparer<HashSet<BaseID>>.Default.Equals(LinkedIDs, other.LinkedIDs);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
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
				Out = HashCode.Combine(Identity, IsActive, IMoment, CMoment, DMoment, base.GetHashCode());
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
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
			catch (JsonException)
			{
				throw new ObjectException(Def.JSONException, sf);
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
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
				Out = Identity.ToString();
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
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

		public override bool TryCreate()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;
			FileStream? fs = null;
			StreamWriter? sw = null;

			try
			{
				fs = File.Create($"{Def.ObjectsDir}/{Identity.Kind}s/{Identity.ID.ToString()[16..]}.json");
				string json = ToJSON();

				using (sw = new(fs, Def.Encoding) { AutoFlush = true })
					sw.Write(json);

				Out = true;
			}
			catch (Exception ex)
			{
				Log.Exception(new ObjectException(ex, sf));
				Out = false;
			}
			finally
			{
				sw?.Dispose();
				fs?.Dispose();
			}

			return Out;
		}

		public override bool TryDelete()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = true;
			}
			catch (Exception ex)
			{
				Log.Exception(new ObjectException(ex, sf));
				Out = false;
			}

			return Out;
		}

		public void Link(TLinked elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				switch (elem.Identity.Kind.Data)
				{
					case Kinds.ObjectKind.Database:
						if (Identity.Kind.Data != Kinds.ObjectKind.Table)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}");
						break;
					case Kinds.ObjectKind.Object:
						if (Identity.Kind.Data != Kinds.ObjectKind.Table)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}");
						break;
					case Kinds.ObjectKind.Table:
						if (Identity.Kind.Data != Kinds.ObjectKind.Field)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}");
						break;
					case Kinds.ObjectKind.Field:
					case Kinds.ObjectKind.None:
					case Kinds.ObjectKind.User:
					default:
						throw new Exception($"The {elem.Identity} could not be linked to the {Identity}");
				}

				if (!LinkedIDs.Add(elem.Identity.ID))
					throw new Exception($"The {elem.Identity} could not be linked to the {Identity}, since it was already linked to it");
			}
			catch (Exception ex)
			{
				throw new LinkException(ex, sf);
			}
		}

		public bool TryLink(TLinked elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				switch (elem.Identity.Kind.Data)
				{
					case Kinds.ObjectKind.Database:
						if (Identity.Kind.Data != Kinds.ObjectKind.Table)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}");
						break;
					case Kinds.ObjectKind.Object:
						if (Identity.Kind.Data != Kinds.ObjectKind.Table)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}");
						break;
					case Kinds.ObjectKind.Table:
						if (Identity.Kind.Data != Kinds.ObjectKind.Field)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}");
						break;
					case Kinds.ObjectKind.Field:
					case Kinds.ObjectKind.None:
					case Kinds.ObjectKind.User:
					default:
						throw new Exception($"The {elem.Identity} could not be linked to the {Identity}");
				}

				if (!LinkedIDs.Add(elem.Identity.ID))
					throw new Exception($"The {elem.Identity} could not be linked to the {Identity}, since it was already linked to it");

				Out = true;
			}
			catch (Exception ex)
			{
				Log.Exception(new ObjectException(ex, sf));
			}

			return Out;
		}

		public void Unlink(TLinked elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!LinkedIDs.Remove(elem.Identity.ID))
					throw new Exception($"The {elem.Identity} could not be unlinked from {Identity}, since it was not already linked to it");
			}
			catch (Exception ex)
			{
				throw new LinkException(ex, sf);
			}
		}

		public bool TryUnlink(TLinked elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				if (!LinkedIDs.Remove(elem.Identity.ID))
					throw new Exception($"The {elem.Identity} could not be unlinked from {Identity}, since it was not already linked to it");

				Out = true;
			}
			catch (Exception ex)
			{
				Log.Exception(new LinkException(ex, sf));
			}

			return Out;
		}

		protected override void Dispose(bool disposing)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity.Dispose();
				IMoment.Dispose();
				CMoment?.Dispose();
				EMoments = [];
				DMoment?.Dispose();
				IsActive = false;
				base.Dispose(disposing);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseObject.op_Equality"/>
		public static bool operator ==(BaseObject<TLinked>? left, BaseObject<TLinked>? right)
		{
			bool Out;

			try
			{
				Out = (left is null && right is null) || left is not null && right is not null && EqualityComparer<BaseObject<TLinked>>.Default.Equals(left, right);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, new StackFrame(true));
			}

			return Out;
		}

		/// <inheritdoc cref="BaseObject.op_Inequality"/>
		public static bool operator !=(BaseObject<TLinked>? left, BaseObject<TLinked>? right)
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
				throw new ObjectException(ex, new StackFrame(true));
			}

			return Out;
		}
	}
}
