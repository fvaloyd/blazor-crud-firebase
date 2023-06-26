using Firebase.SDK.Request;
using Firebase.SDK.Response;
using Refit;

namespace Firebase.SDK.Services;
public interface IFirebaseRefreshService
{
    [Post("/v1/token")]
    Task<RefreshTokenResponse> RefreshToken([Body(BodySerializationMethod.UrlEncoded)] RefreshTokenRequest request);
}
