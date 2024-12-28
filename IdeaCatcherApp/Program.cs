using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using IdeaCatcherApp;
using IdeaCatcherApp.Services;
using Blazorise;
using Blazorise.Bootstrap;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IIdeaStorageService, LocalStorageIdeaService>();

builder.Services.AddBlazorise()
    .AddBootstrapProviders();

await builder.Build().RunAsync();
