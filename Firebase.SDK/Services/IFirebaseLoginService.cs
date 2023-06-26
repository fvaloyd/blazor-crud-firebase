using Firebase.SDK.Authentication.Request;
using Firebase.SDK.Authentication.Response;
using Refit;

namespace Firebase.SDK.Services;
public interface IFirebaseLoginService
{
    [Post("/v1/accounts:signInWithPassword")]
    Task<LoginResponse> Login([Body] LoginRequest request);
}
