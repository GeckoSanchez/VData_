﻿namespace VData01.Exceptions
{
	using System.Diagnostics;
	using System.Runtime.CompilerServices;
	using Actions;
	using Attributes;
	using Bases;
	using Kinds;
	using Newtonsoft.Json;

	public class PropertyException : BaseException
	{
				[JsonConstructor, Unlogged, MainConstructor]
		public PropertyException(Exception? ex, BlockKind? btype, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : base(ex, btype, ExceptKind.Property, name, path, line) => Log.Event(new StackFrame(true));
		public PropertyException(Exception? ex, StackFrame sf, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : this(ex, Get.BlockKindOrDefault(sf), name, path, line) => Log.Event(new StackFrame(true));
		public PropertyException(string? message, StackFrame sf, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : this(message != null ? new(message) : null, Get.BlockKindOrDefault(sf), name, path, line) => Log.Event(new StackFrame(true));
	}
}
