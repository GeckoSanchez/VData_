﻿namespace VData02.Exceptions
{
	using System.Diagnostics;
	using System.Runtime.CompilerServices;
	using Actions;
	using Attributes;
	using Bases;
	using Kinds;
	using Newtonsoft.Json;

	public class ContextException : BaseException
	{
				[JsonConstructor, Unlogged, MainConstructor]
		public ContextException(Exception? ex, BlockKind? btype, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : base(ex, btype, ExceptKind.Context, name, path, line) => Log.Event(new StackFrame(true));
		public ContextException(Exception? ex, StackFrame sf, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : this(ex, Get.BlockKindOrDefault(sf), name, path, line) => Log.Event(new StackFrame(true));
		public ContextException(string? message, StackFrame sf, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : this(message != null ? new(message) : null, Get.BlockKindOrDefault(sf), name, path, line) => Log.Event(new StackFrame(true));
	}
}
