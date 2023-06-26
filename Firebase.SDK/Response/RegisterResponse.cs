namespace Firebase.SDK.Authentication.Response;
public record RegisterResponse(
    string LocalId,
    string IdToken,
    string RefreshToken,
    string ExpiresIn);
