global using Microsoft.AspNetCore.Components.Authorization;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Extensions;
using MudBlazor.Services;
using Website;
using Website.Services;
using Website.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.Configure<ApplicationOptions>(builder.Configuration.GetSection("StudentManagement"));
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddLocalization(x => x.ResourcesPath = "Resources");
builder.Services.AddAuthorizationCore();

builder.Services.AddIWProtectedBrowserStorageAsSingleton();
builder.Services.AddHttpClient<ApiClient>();
builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
