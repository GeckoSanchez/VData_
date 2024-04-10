namespace VData02
{
	using Actions;
	using Blazorise;
	using Blazorise.Bootstrap;
	using Blazorise.Icons.FontAwesome;

	internal class Program
	{
		private static void Main(string[] args)
		{
			Log.Event($">>>>>> {Def.AppName} HAS BOOTED <<<<<<", Kinds.BlockKind.None);

			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();

			builder.Services
				.AddBlazorise(o =>
				{
					o.AutoCloseParent = true;
					o.EnableNumericStep = true;
					o.ShowNumericStepButtons = true;
					o.IconStyle = IconStyle.Solid;
					o.Immediate = true;
				})
				.AddBootstrapProviders(o =>
				{
					o.ToBarCollapsedMode(BarCollapseMode.Small);
					o.ToBackground(Background.Body);
					o.UseCustomInputStyles = true;
				})
				.AddFontAwesomeIcons();

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
				app.UseHsts();

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.MapBlazorHub();
			app.MapFallbackToPage("/_Host");

			app.Run();
		}
	}
}