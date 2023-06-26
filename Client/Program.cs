using Blazored.LocalStorage;
using Client;
using Client.Services;
using Firebase.SDK.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

const string API_KEY = "AIzaSyBh4h6UD0url7tUVCdgG9fS3Si4cKcv7Tk";

builder.Services.AddFirebaseAuthenticationServices(API_KEY);

builder.Services.AddScoped<TodoService>();
builder.Services.AddMudServices();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<FirebaseAuthenticationState>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<FirebaseAuthenticationState>());

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
