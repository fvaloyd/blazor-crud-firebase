namespace Firebase.SDK.Response;
public class UserInfoResponse
{
    public UserInfo[] Users { get; set; }
    public UserInfo CurrentUser => Users[0];
}

public record UserInfo(
    string LocalId,
    string Email,
    string DisplayName,
    string CreatedAt);