using Firebase.SDK.Http;
using Firebase.SDK.Services;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Security.Principal;

namespace Firebase.SDK.Extensions;
public static class FirebaseSDKExtensions
{
    private const string IDENTITY_TOOLKIT_BASE_URL = "https://identitytoolkit.googleapis.com";
    private const string SECURE_TOKEN_BASE_URL = "https://securetoken.googleapis.com";
    private const string TODODB_BASE_URL = "https://blazorcrud-fb8b7.firebaseio.com/todo";
    public static void AddFirebaseAuthenticationServices(this IServiceCollection services, string api_key)
    {
        services.AddTransient<FirebaseSetApiKeyHttpMessageHandler>(sp => new FirebaseSetApiKeyHttpMessageHandler(api_key));

        services.AddRefitClient<IFirebaseRegisterService>()
            .ConfigureHttpClient(cfg => cfg.BaseAddress = new Uri(IDENTITY_TOOLKIT_BASE_URL))
            .AddHttpMessageHandler<FirebaseSetApiKeyHttpMessageHandler>();

        services.AddRefitClient<IFirebaseLoginService>()
            .ConfigureHttpClient(cfg => cfg.BaseAddress = new Uri(IDENTITY_TOOLKIT_BASE_URL))
            .AddHttpMessageHandler<FirebaseSetApiKeyHttpMessageHandler>();

        services.AddRefitClient<IFirebaseRefreshService>()
            .ConfigureHttpClient(cfg => cfg.BaseAddress = new Uri(SECURE_TOKEN_BASE_URL))
            .AddHttpMessageHandler<FirebaseSetApiKeyHttpMessageHandler>();

        services.AddRefitClient<IFirebaseUserInfoService>()
            .ConfigureHttpClient(cfg => cfg.BaseAddress = new Uri(IDENTITY_TOOLKIT_BASE_URL))
            .AddHttpMessageHandler<FirebaseSetApiKeyHttpMessageHandler>();
    }
}
