namespace Firebase.SDK.Request;
public class UserInfoRequest
{
    public string IdToken { get; set; }

    public UserInfoRequest(string idToken)
    {
        IdToken = idToken;
    }
}
