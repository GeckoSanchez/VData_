namespace VData02.Attributes
{
	using System.Diagnostics;
	using Actions;
	using Categories;

	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	public class EmptyConstructorAttribute : Attribute, IAttribute
	{
		public EmptyConstructorAttribute() => Log.Event(new StackFrame(true));
	}
}
