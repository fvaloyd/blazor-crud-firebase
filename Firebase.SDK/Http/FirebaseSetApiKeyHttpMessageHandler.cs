namespace Firebase.SDK.Http;
public class FirebaseSetApiKeyHttpMessageHandler : DelegatingHandler
{
    private readonly string _apiKey;

    public FirebaseSetApiKeyHttpMessageHandler(string apiKey) => _apiKey = apiKey;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.RequestUri = new Uri($"{request.RequestUri}?key={_apiKey}");
        return base.SendAsync(request, cancellationToken);
    }
}
