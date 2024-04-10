namespace VData02.Pages
{
	using System.Diagnostics;
	using System.Threading.Tasks;
	using Actions;
	using Categories;
	using Exceptions;
	using Kinds;
	using Microsoft.AspNetCore.Components;

	public partial class Index : IPage
	{
		public PageKind PageKind => PageKind.Home;
		public Enum? ElemKind => null;
		[Parameter]
		public long? ID { get; set; }

		public Index()
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			try
			{

			}
			catch (Exception ex)
			{
				Log.Exception(new PageException(ex, sf));
			}
		}

		public override string ToString()
		{
			Log.Event(new StackFrame(true));
			return NavMgr.Uri;
		}

		protected override void OnInitialized()
		{
			Log.Event(new StackFrame(true));
			base.OnInitialized();
		}

		protected override Task OnInitializedAsync()
		{
			Log.Event(new StackFrame(true));
			return base.OnInitializedAsync();
		}

		protected override void OnParametersSet()
		{
			Log.Event(new StackFrame(true));
			base.OnParametersSet();
		}

		protected override Task OnParametersSetAsync()
		{
			Log.Event(new StackFrame(true));
			return base.OnParametersSetAsync();
		}

		protected override bool ShouldRender()
		{
			Log.Event(new StackFrame(true));
			return base.ShouldRender();
		}

		protected override void OnAfterRender(bool firstRender)
		{
			Log.Event(new StackFrame(true));
			base.OnAfterRender(firstRender);
		}

		protected override Task OnAfterRenderAsync(bool firstRender)
		{
			Log.Event(new StackFrame(true));
			return base.OnAfterRenderAsync(firstRender);
		}

		public override Task SetParametersAsync(ParameterView parameters)
		{
			Log.Event(new StackFrame(true));
			return base.SetParametersAsync(parameters);
		}
	}
}