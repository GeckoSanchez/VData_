namespace VData02.Attributes
{
	using System.Diagnostics;
	using System.Runtime.CompilerServices;
	using Actions;
	using Categories;
	using Newtonsoft.Json;

	/// <summary>
	/// A constructor that accepts the current object type as its sole parameter
	/// </summary>
	/// <remarks>
	/// Example:
	/// <code>
	/// public Abc(Abc data) { ... }
	/// </code>
	/// </remarks>
	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	public sealed class SelfConstructorAttribute : Attribute, IAttribute
	{
		[JsonConstructor]
		public SelfConstructorAttribute([CallerFilePath] string path = "") => Log.Event(new StackFrame(true), path);
	}
}
