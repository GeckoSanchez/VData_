namespace VData01
{
	using System.Diagnostics;
	using Actions;
	using Exceptions;
	using Objects;

	public static class Context
	{
		public static HashSet<Object> Objects { get; internal set; } = [];

		public static void Add(Object elem)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{
				if (!Objects.Add(elem))
					throw new Exception($"{elem.Identity} ");
			}
			catch (Exception ex)
			{
				throw new ContextException(ex, sf);
			}
		}
	}
}
