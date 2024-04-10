namespace VData02.Actions
{
	using Categories;

	public class Format(string value) : IAction
	{
		public static string ExcValue(string value) => $"('{value}')";
		public override string ToString() => $"'{value}'";
	}

	public class Format<T>(T value)
	{
		public static string ExcValue(T value) => $"('{value}')";
		public override string ToString() => $"'{value}'";
	}
}
