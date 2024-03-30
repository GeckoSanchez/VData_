namespace VData01.Pages
{
	using Bases;
	using Microsoft.AspNetCore.Components;

	public partial class Index
	{
		[Parameter]
		public string? ID { get; set; }

		public BaseDevice Device { get; set; }

		public Index()
		{
			Device = new(new("allo"), new());
		}
	}
}