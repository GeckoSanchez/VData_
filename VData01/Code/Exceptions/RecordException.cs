namespace VData01.Exceptions
{
	using System.Diagnostics;
	using System.Runtime.CompilerServices;
	using Actions;
	using Attributes;
	using Bases;
	using Kinds;
	using Newtonsoft.Json;

	public class RecordException : BaseException
	{
		[JsonConstructor, Unlogged, MainConstructor]
		public RecordException(Exception? ex, BlockKind? btype, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : base(ex, btype, ExceptKind.Record, name, path, line) => Log.Event(new StackFrame(true));
		public RecordException(Exception? ex, StackFrame sf, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : this(ex, Get.BlockKindOrDefault(sf), name, path, line) => Log.Event(new StackFrame(true));
		public RecordException(string? message, StackFrame sf, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : this(message != null ? new(message) : null, Get.BlockKindOrDefault(sf), name, path, line) => Log.Event(new StackFrame(true));
	}
}
