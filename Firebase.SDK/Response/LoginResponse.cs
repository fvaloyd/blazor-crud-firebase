namespace Firebase.SDK.Authentication.Response;
public record LoginResponse(string LocalId, string IdToken, string RefreshToken, string ExpiresIn);
