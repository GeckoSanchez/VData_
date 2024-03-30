namespace VData01.Attributes
{
	using System.Diagnostics;
	using Actions;
	using Categories;

	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	public sealed class MainConstructorAttribute : Attribute, IAttribute
	{
		public MainConstructorAttribute() => Log.Event(new StackFrame(true));
	}
}
