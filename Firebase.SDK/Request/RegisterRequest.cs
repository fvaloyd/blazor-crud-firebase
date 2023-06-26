using Firebase.SDK.Request;

namespace Firebase.SDK.Authentication.Request;
public class RegisterRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
    public bool ReturnSecureToken => true;
}