using Blazored.LocalStorage;
using Firebase.SDK.Models;
using Firebase.SDK.Request;
using Firebase.SDK.Response;
using Firebase.SDK.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Refit;
using System.Security.Claims;

namespace Client.Services;

public class FirebaseAuthenticationState : AuthenticationStateProvider
{
    public readonly ILocalStorageService _localStorageService;
    public readonly IFirebaseUserInfoService _firebaseUserInfoService;
    public readonly IFirebaseRefreshService _firebaseRefreshTokenService;

    public FirebaseAuthenticationState(
        IFirebaseUserInfoService firebaseUserInfoService,
        IFirebaseRefreshService firebaseRefreshTokenService,
        ILocalStorageService localStorageService)
    {
        _firebaseUserInfoService = firebaseUserInfoService;
        _firebaseRefreshTokenService = firebaseRefreshTokenService;
        _localStorageService = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        try
        {
            bool isAuthenticate = await _localStorageService.GetItemAsync<bool>("isAuthenticate");
            if (isAuthenticate)
            {
                var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");
                var refreshToken = await _localStorageService.GetItemAsync<string>("refreshToken");
                if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
                {
                    return new AuthenticationState(new ClaimsPrincipal(identity));
                }
                UserInfoResponse userInfoResponse = null!;
                try
                {
                    userInfoResponse = await _firebaseUserInfoService.UserInfo(new UserInfoRequest(accessToken));
                }
                catch (ApiException ex)
                {
                    var responseError = await ex.GetContentAsAsync<ErrorResponse>();
                    if (responseError!.Error.Message == "INVALID_ID_TOKEN")
                    {
                        try
                        {
                            var refreshTokenRequest = new RefreshTokenRequest { RefreshToken = refreshToken };
                            var refreshTokenResponse = await _firebaseRefreshTokenService.RefreshToken(refreshTokenRequest);
                            userInfoResponse = await _firebaseUserInfoService.UserInfo(new UserInfoRequest(refreshTokenResponse.IdToken));
                        }
                        catch (ApiException)
                        {
                            return new AuthenticationState(new ClaimsPrincipal(identity));
                        }
                    }
                }
                UserInfo user = userInfoResponse.CurrentUser;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.DisplayName),
                    new Claim(ClaimTypes.NameIdentifier, user.LocalId),
                };
                identity = new ClaimsIdentity(claims, "authentication");
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
            }
        }
        catch (ApiException ex)
        {
            var errorResponse = await ex.GetContentAsAsync<ErrorResponse>();
            Console.WriteLine(errorResponse);
        }
        AuthenticationState state = new AuthenticationState(new ClaimsPrincipal(identity));
        return state;
    }

    public void ManagerUser()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
