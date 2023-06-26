using Firebase.SDK.Request;

namespace Firebase.SDK.Authentication.Request;
public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool ReturnSecureToken => true;
}