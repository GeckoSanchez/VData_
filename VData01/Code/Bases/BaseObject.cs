namespace VData01.Bases
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Identities;
	using IDs;
	using Kinds;
	using Names;
	using Newtonsoft.Json;
	using Properties;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseObject : Base<ObjectIdentity>, IEquatable<BaseObject?>, IObject
	{
		[JsonProperty(nameof(Identity))]
		public ObjectIdentity Identity { get => Data; protected init => Data = value; }

		[JsonProperty("Is active?")]
		public bool IsActive { get; protected set; }

		[JsonProperty("Init moment")]
		public DateTime InitMoment { get; protected init; }

		public DateTime? CMoment
		{
			get
			{
				DateTime? Out = null;

				if (!File.Exists($"{Def.ObjectsDir}/{Identity.Type.Data}s/{$"{Identity.ID}"[16..]}.json"))
					Out = null;
				else
					try
					{
						Out = new FileInfo($"{Def.ObjectsDir}/{Identity.Type.Data}s/{$"{Identity.ID}"[16..]}.json").CreationTime;
					}
					catch (Exception ex)
					{
						Log.Exception(new BaseException(ex, new StackFrame(true)));
					}

				return Out;
			}
		}

		[JsonProperty("Deletion moment", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? DMoment { get; protected set; }

		/// <summary>
		/// Main constructor for the <see cref="BaseObject"/> class
		/// </summary>
		/// <param name="identity">A <see cref="ObjectIdentity"/> identity</param>
		/// <param name="isactive">A <see cref="bool"/> activity status</param>
		/// <param name="initmoment">A <see cref="DateTime"/> initialization moment</param>
		/// <param name="dmoment">A <see cref="DateTime"/><![CDATA[?]]> deletion moment</param>
		/// <exception cref="ObjectException"/>
		[JsonConstructor, MainConstructor]
		public BaseObject(ObjectIdentity identity, bool isactive, DateTime initmoment, DateTime? dmoment = null) : base(identity)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = identity;
				IsActive = isactive;
				InitMoment = initmoment;
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
		/// <inheritdoc cref="BaseObject(ObjectIdentity,bool,DateTime,DateTime?)"/>
		public BaseObject(ObjectIdentity identity) : this(identity, true, DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = identity;
				InitMoment = DateTime.Now;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseObject(ObjectIdentity)"/>
		/// <param name="name">A <see cref="ObjectName"/> name</param>
		/// <param name="type">A <see cref="ObjectType"/> type</param>
		/// <param name="id">A <see cref="ObjectID"/> ID</param>
		/// <exception cref="ObjectException"/>
		public BaseObject(ObjectName name, ObjectType type, ObjectID id) : this(new ObjectIdentity("", Def.ObjectKind), true, DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, type, id);
				InitMoment = DateTime.Now;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		/// <inheritdoc cref="BaseObject(ObjectName,ObjectType,ObjectID)"/>
		public BaseObject(ObjectName name, ObjectType type) : this(new ObjectIdentity("", Def.ObjectKind), true, DateTime.MinValue)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				Identity = new(name, type);
				InitMoment = DateTime.Now;
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		public void Activate()
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
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ActivationException(ex, sf);
			}
		}

		public void Deactivate()
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
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new ActivationException(ex, sf);
			}
		}

		public void Create()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				string json = ToJSON();
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new CreationException(ex, sf);
			}
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public void Delete()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{

			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DeletionException(ex, sf);
			}
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

		/// <inheritdoc cref="IEquatable{Base{ObjectIdentity}}.Equals(Base{ObjectIdentity}?)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="ObjectException"/>
		public bool Equals(BaseObject? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
						 EqualityComparer<ObjectIdentity>.Default.Equals(Identity, other.Identity) &&
						 IsActive == other.IsActive && InitMoment == other.InitMoment &&
						 CMoment == other.CMoment && DMoment == other.DMoment;
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
				Out = HashCode.Combine(base.GetHashCode(), Identity, Identity.GetHashCode(), IsActive, InitMoment, CMoment, DMoment);
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

		/// <inheritdoc cref="Base{ObjectIdentity}.ToString"/>
		/// <exception cref="ObjectException"/>
		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			string? Out = null;

			try
			{
				Out = $"{Identity}";
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

		public static bool operator ==(BaseObject? left, BaseObject? right) => EqualityComparer<BaseObject>.Default.Equals(left, right);
		public static bool operator !=(BaseObject? left, BaseObject? right) => !(left == right);
	}

	public class BaseObject<TLinked> : BaseObject, ILinkable<BaseObject>, ILinkable<BaseObject<TLinked>>, IEquatable<BaseObject<TLinked>?> where TLinked : IObject
	{
		[JsonProperty("Linked IDs")]
		public HashSet<BaseID> LinkedIDs { get; protected set; }

		/// <summary>
		/// Main constructor for the <see cref="BaseObject{TLinked}"/> class
		/// </summary>
		/// <param name="identity">
		/// A <see cref="ObjectIdentity"/> identity
		/// </param>
		/// <param name="isactive">
		/// Whether this <see cref="BaseObject{TLinked}"/> is active, or not
		/// </param>
		/// <param name="initmoment">
		/// The <see cref="DateTime"/> at which this object was initialized
		/// </param>
		/// <param name="linkedids">
		/// A <see cref="ICollection{BaseID}"/> of <see cref="BaseID"/>s of the elements linked to it
		/// </param>
		/// <param name="initmoment">
		/// The <see cref="DateTime"/> at which this object will be deleted
		/// </param>
		/// <exception cref="ObjectException"/>
		[JsonConstructor, MainConstructor]
		public BaseObject(ObjectIdentity identity, bool isactive, DateTime initmoment, HashSet<BaseID> linkedids, DateTime? dmoment = null) : base(identity, isactive, initmoment, dmoment)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				LinkedIDs = [.. linkedids.DistinctBy(e => e.Data)];
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		/// <summary>
		/// Constructor for the <see cref="BaseObject{TLinked}"/> class
		/// </summary>
		/// <inheritdoc cref="BaseObject{TLinked}(ObjectIdentity, bool, DateTime, HashSet{BaseID}, DateTime?)"/>
		public BaseObject(ObjectIdentity identity, bool isactive, DateTime initmoment, DateTime? dmoment = null) : this(identity, isactive, initmoment, [], dmoment) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseObject{TLinked}(ObjectIdentity,bool,DateTime,DateTime?)"/>
		public BaseObject(ObjectIdentity identity) : this(identity, true, DateTime.Now, [], null) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseObject{TLinked}(ObjectIdentity,bool,DateTime,DateTime?)"/>
		public BaseObject(ObjectIdentity identity, params BaseObject[] objects) : this(identity, true, DateTime.Now, [], null)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (identity.Type == ObjectType.Database)
					LinkedIDs = [.. objects.Where(e => e.Identity.Type == ObjectType.Table).Select(e => e.Identity.ID)];
				else if (identity.Type == ObjectType.Table)
					LinkedIDs = [.. objects.Where(e => e.Identity.Type == ObjectType.Field).Select(e => e.Identity.ID)];
				else
					LinkedIDs = [];
			}
			catch (Exception ex)
			{
				throw new ObjectException(ex, sf);
			}
		}

		public BaseObject(ObjectName name, ObjectType type) : this(new ObjectIdentity(name, type), true, DateTime.Now, [], null) => Log.Event(new StackFrame(true));

		public BaseObject(ObjectName name, ObjectType type, ObjectID id) : this(new ObjectIdentity(name, type, id), true, DateTime.Now, [], null) => Log.Event(new StackFrame(true));

		public void Link(BaseObject elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				switch (Identity.Type.Data)
				{
					case ObjectKind.Database:
						if (elem.Identity.Type != ObjectType.Table)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}, since a {elem.Identity.Type.Data} cannot be linked to a {elem.Identity.Type.Data}");
						break;
					case ObjectKind.Table:
						if (elem.Identity.Type != ObjectType.Field)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}, since a {elem.Identity.Type.Data} cannot be linked to a {elem.Identity.Type.Data}");
						break;
					case ObjectKind.Field:
					case ObjectKind.None:
					case ObjectKind.User:
					case ObjectKind.Object:
					default:
						throw new Exception($"The {elem.Identity} cannot not be linked to any type of object");
				}

				if (!LinkedIDs.Add(elem.Identity.ID))
					throw new Exception($"The {elem.Identity} could not be linked to the {Identity}, since it is already linked to it");
			}
			catch (Exception ex)
			{
				throw new LinkException(ex, sf);
			}
		}

		public bool TryLink(BaseObject elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				Link(elem);
				Out = true;
			}
			catch (LinkException) { }
			catch (Exception ex)
			{
				Log.Exception(new(ex, sf, ExceptKind.Link));
			}

			return Out;
		}

		public void Unlink(BaseObject elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!LinkedIDs.Add(elem.Identity.ID))
					throw new Exception($"The {elem.Identity} could not linked to the {Identity}, since it was not already linked to it");
			}
			catch (Exception ex)
			{
				throw new LinkException(ex, sf);
			}
		}

		public bool TryUnlink(BaseObject elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				Unlink(elem);
				Out = true;
			}
			catch (LinkException) { }
			catch (Exception ex)
			{
				Log.Exception(new(ex, sf, ExceptKind.Link));
			}

			return Out;
		}

		public void Link(BaseObject<TLinked> elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				switch (Identity.Type.Data)
				{
					case ObjectKind.Database:
						if (elem.Identity.Type != ObjectType.Table)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}, since a {elem.Identity.Type.Data} cannot be linked to a {elem.Identity.Type.Data}");
						break;
					case ObjectKind.Table:
						if (elem.Identity.Type != ObjectType.Field)
							throw new Exception($"The {elem.Identity} could not be linked to the {Identity}, since a {elem.Identity.Type.Data} cannot be linked to a {elem.Identity.Type.Data}");
						break;
					case ObjectKind.Field:
					case ObjectKind.None:
					case ObjectKind.User:
					case ObjectKind.Object:
					default:
						throw new Exception($"The {elem.Identity} cannot not be linked to any type of object");
				}

				if (!LinkedIDs.Add(elem.Identity.ID))
					throw new Exception($"The {elem.Identity} could not be linked to the {Identity}, since it is already linked to it");
			}
			catch (Exception ex)
			{
				throw new LinkException(ex, sf);
			}
		}

		public bool TryLink(BaseObject<TLinked> elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				Link(elem);
				Out = true;
			}
			catch (LinkException) { }
			catch (Exception ex)
			{
				Log.Exception(new(ex, sf, ExceptKind.Link));
			}

			return Out;
		}

		public void Unlink(BaseObject<TLinked> elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!LinkedIDs.Add(elem.Identity.ID))
					throw new Exception($"The {elem.Identity} could not linked to the {Identity}, since it was not already linked to it");
			}
			catch (Exception ex)
			{
				throw new LinkException(ex, sf);
			}
		}

		public bool TryUnlink(BaseObject<TLinked> elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				Unlink(elem);
				Out = true;
			}
			catch (LinkException) { }
			catch (Exception ex)
			{
				Log.Exception(new(ex, sf, ExceptKind.Link));
			}

			return Out;
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

		/// <inheritdoc cref="IEquatable{BaseObject{TLinked}}.Equals(BaseObject{TLinked}?)"/>
		/// <exception cref="BaseException"/>
		/// <exception cref="ObjectException"/>
		public bool Equals(BaseObject<TLinked>? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) &&
						 EqualityComparer<ObjectIdentity>.Default.Equals(Identity, other.Identity) &&
						 IsActive == other.IsActive && InitMoment == other.InitMoment &&
						 CMoment == other.CMoment && DMoment == other.DMoment &&
						 EqualityComparer<ICollection<BaseID>>.Default.Equals(LinkedIDs, other.LinkedIDs);
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
				Out = HashCode.Combine(base.GetHashCode(), Identity, Identity.GetHashCode(), IsActive, InitMoment, CMoment, DMoment, LinkedIDs);
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

		protected override void Dispose(bool disposing)
		{
			Log.Event(new StackFrame(true));
			base.Dispose(disposing);
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
				Out = $"{Identity}";
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

		public static bool operator ==(BaseObject<TLinked>? left, BaseObject<TLinked>? right) => EqualityComparer<BaseObject<TLinked>>.Default.Equals(left, right);
		public static bool operator !=(BaseObject<TLinked>? left, BaseObject<TLinked>? right) => !(left == right);
	}
}
