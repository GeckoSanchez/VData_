namespace VData02.Objects
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using Attributes;
	using Bases;
	using Categories;
	using Identities;
	using IDs;
	using Names;
	using Newtonsoft.Json;
	using Types;
	using Values;
	using VData02.Actions;
	using VData02.Exceptions;

	[JsonObject(MemberSerialization.OptIn)]
	[method: JsonConstructor, MainConstructor]
	public class Object([NotNull] ObjectIdentity identity, [NotNull] bool isactive, [NotNull] Moment imoment, [AllowNull] Moment? cmoment, HashSet<IMoment> emoments, [AllowNull] Moment? dmoment) : BaseObject(new ObjectIdentity(identity.Name, new ObjectType(Kinds.ObjectKind.Object), identity.ID.GetSubID()), isactive, imoment, cmoment, emoments, dmoment), IEquatable<Object?>
	{
		public Object([NotNull] ObjectIdentity identity) : this(new ObjectIdentity(identity.Name, new ObjectType(Kinds.ObjectKind.Object), identity.ID.GetSubID()), true, DateTime.Now, null, [], null)
		{
		}

		public Object([NotNull] ObjectName name, [NotNull] ObjectID id) : this(new ObjectIdentity(name, Kinds.ObjectKind.Object, id.GetSubID()), true, DateTime.Now, null, [], null)
		{
		}

		public Object([NotNull] ObjectName name) : this(new ObjectIdentity(name, Kinds.ObjectKind.Object, Random.Shared.NextInt64()), true, DateTime.Now, null, [], null)
		{
		}
		public Object() : this(new ObjectIdentity(Def.Name, Kinds.ObjectKind.Object, Random.Shared.NextInt64()), true, DateTime.Now, null, [], null)
		{
		}

		public override bool Equals(object? obj)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = Equals(obj as Object);
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

		public bool Equals(Object? other)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out;

			try
			{
				Out = other is not null && base.Equals(other) && IsActive == other.IsActive &&
					EqualityComparer<ObjectIdentity>.Default.Equals(Identity, other.Identity) &&
					EqualityComparer<Moment>.Default.Equals(IMoment, other.IMoment) &&
					EqualityComparer<Moment?>.Default.Equals(CMoment, other.CMoment) &&
					EqualityComparer<HashSet<IMoment>>.Default.Equals(EMoments, other.EMoments) &&
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

		public override bool TryDelete()
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

		public static bool operator ==(Object? left, Object? right) => EqualityComparer<Object>.Default.Equals(left, right);
		public static bool operator !=(Object? left, Object? right) => !(left == right);
	}
}
