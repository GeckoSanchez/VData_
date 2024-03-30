namespace VData01.Objects
{
	using System.Diagnostics;
	using System.Net.NetworkInformation;
	using Actions;
	using Bases;
	using Identities;
	using IDs;
	using Kinds;
	using Names;
	using Newtonsoft.Json;
	using Types;

	[JsonObject(MemberSerialization.OptIn)]
	public class Object : BaseObject
	{
		public Object(ObjectIdentity identity, bool isactive, DateTime initmoment, DateTime? dmoment = null) : base(new ObjectIdentity(new ObjectName(identity.Name.Data), ObjectType.Object, new ObjectID(ObjectKind.Object, identity.ID.GetSubID())), isactive, initmoment, dmoment) => Log.Event(new StackFrame(true));

		public Object(ObjectIdentity identity) : base(new ObjectIdentity(identity.Name, ObjectKind.Object, identity.ID.GetSubID())) => Log.Event(new StackFrame(true));

		public Object(ObjectName name) : base(name, ObjectType.Object) => Log.Event(new StackFrame(true));
		public Object(ObjectName name, ObjectID id) : base(name, ObjectType.Object, id) => Log.Event(new StackFrame(true));
	}
}
