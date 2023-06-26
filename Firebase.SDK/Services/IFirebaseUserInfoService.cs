using Firebase.SDK.Request;
using Firebase.SDK.Response;
using Refit;

namespace Firebase.SDK.Services;
public interface IFirebaseUserInfoService
{
    [Post("/v1/accounts:lookup")]
    Task<UserInfoResponse> UserInfo([Body]UserInfoRequest request);
}
