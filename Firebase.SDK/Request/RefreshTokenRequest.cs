using Refit;

namespace Firebase.SDK.Request;
public class RefreshTokenRequest
{
    [AliasAs("grant_type")]
    public string GrantType { get; set; } = "refresh_token";
    [AliasAs("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;
}