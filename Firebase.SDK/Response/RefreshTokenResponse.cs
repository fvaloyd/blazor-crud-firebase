using System.Text.Json.Serialization;

namespace Firebase.SDK.Response;
public class RefreshTokenResponse
{
    [JsonPropertyName("id_token")]
    public string IdToken { get; set; }
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
    [JsonPropertyName("expires_in")]
    public string ExpiresIn { get; set; }
}
