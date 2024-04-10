namespace VData02.Bases
{
	using System.Diagnostics;
	using System.Runtime.CompilerServices;
	using Actions;
	using Attributes;
	using Categories;
	using Exceptions;
	using Kinds;
	using Newtonsoft.Json;

	[JsonObject(MemberSerialization.OptIn)]
	public class BaseException : Exception, IBase
	{
		[JsonProperty]
		public override string Message => base.Message;
		[JsonProperty("Block type")]
		public BlockKind BlockKind { get; set; }
		[JsonProperty("Exception type")]
		public ExceptKind ExceptionKind { get; set; }
		[JsonProperty]
		public string Name { get; set; }
		[JsonProperty]
		public string Path { get; set; }
		[JsonProperty]
		public int Line { get; set; }

		/// <summary>
		/// Primary constructor for the <see cref="BaseException"/> class
		/// </summary>
		/// <param name="ex">The given <see cref="Exception"/></param>
		/// <param name="blockkind">The given block type</param>
		/// <param name="exceptionkind">The given exception type</param>
		/// <param name="name">The given name of the code-block</param>
		/// <param name="path">The file path of the code-block</param>
		/// <param name="line">The line number of the code-block</param>
		[JsonConstructor, MainConstructor]
		public BaseException(Exception? ex, BlockKind? blockkind, ExceptKind exceptionkind = ExceptKind.Base, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : base((ex ?? new()).Message, ex)
		{
			Log.Event(new StackFrame(true));
			BlockKind = blockkind ?? Def.BlockKind;
			ExceptionKind = exceptionkind;
			Name = name;
			Path = path;
			Line = line;
		}

		/// <summary>
		/// Constructor for the <see cref="BaseException"/> class
		/// </summary>
		/// <param name="sf">The given <see cref="StackFrame"/> object</param>
		/// <inheritdoc cref="BaseException(Exception?, BlockKind?, ExceptKind, string, string, int)"/>
		public BaseException(Exception? ex, StackFrame sf, ExceptKind exceptionkind = ExceptKind.Base, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : this(ex, Get.BlockKindOrDefault(sf, Def.BlockKind), exceptionkind, sf.GetMethod()!.Name ?? name, sf.GetFileName() ?? path, line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(Exception?, StackFrame, ExceptKind, string, string, int)"/>
		/// <param name="message">The given message, or <see langword="null"/> if empty</param>
		public BaseException(string? message, StackFrame sf, ExceptKind exceptionkind = ExceptKind.Base, [CallerMemberName] string name = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : this(new Exception(message), Get.BlockKindOrDefault(sf, Def.BlockKind), exceptionkind, sf.GetMethod()!.Name ?? name, sf.GetFileName() ?? path, sf.GetFileLineNumber() != 0 ? sf.GetFileLineNumber() : line) => Log.Event(new StackFrame(true));

		/// <param name="ex">An exception</param>
		/// <inheritdoc cref="BaseException(Exception?, StackFrame, ExceptKind, string, string, int)"/>
		public BaseException(ActionException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(ActivationException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(AttributeException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(ClassException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(ComponentException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(ContextException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(CreationException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(CurrentException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(DataException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(DateException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(DeletionException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(DeviceException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(HistoryException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(IdentityException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(IDException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(KindException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(LinkException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(ModelException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(MomentException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(NameException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(NumberException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(ObjectException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(PageException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(PropertyException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(RecordException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(TimeException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(TypeException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		/// <inheritdoc cref="BaseException(ActionException)"/>
		public BaseException(ValueException ex) : this(ex, ex.BlockKind, ex.ExceptionKind, ex.Name, ex.Path, ex.Line) => Log.Event(new StackFrame(true));

		public override Exception GetBaseException()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			Exception? Out = null;

			try
			{
				Out = base.GetBaseException();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(JsonConvert.SerializeObject(ex, Formatting.None));
			}
			finally
			{
				Out ??= new();
			}

			return Out;
		}

		public override string ToString()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);
			return Message;
		}
	}
}
