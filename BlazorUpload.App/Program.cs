using BlazorUpload.App;
using BlazorUpload.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient(nameof(FileService), client => client.BaseAddress = new Uri("http://localhost:5106"));
builder.Services.AddScoped<FileService>();

await builder.Build().RunAsync();
