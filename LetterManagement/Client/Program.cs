using Blazored.LocalStorage;
using LetterManagement.Client;
using LetterManagement.Client.StateContainer;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });



builder.Services.AddMudServices();

builder.Services.AddSingleton<UserState>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();