namespace Firebase.SDK.Models;
public record ErrorResponse(Error Error);
public record Error(int Code, string Message, object[] Errors);