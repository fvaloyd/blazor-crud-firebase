using Firebase.SDK.Authentication.Request;
using Firebase.SDK.Authentication.Response;
using Refit;

namespace Firebase.SDK.Services;
public interface IFirebaseRegisterService
{
    [Post("/v1/accounts:signUp")]
    Task<RegisterResponse> Register(RegisterRequest request);
}
