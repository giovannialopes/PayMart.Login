using PayMart.Domain.Login.ModelView;
using System.Net.Http.Json;

namespace PayMart.Domain.Login.Http.Client;

public class HttpClients
{
    private static HttpClient _http;

    static HttpClients() => _http = new HttpClient();

    public async static Task AddClient(ModelLogin.RegisterLoginResponse request)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var host = environment == "Development" ? "localhost" : "paymart-clients";

        var httpResponse = await _http.PostAsJsonAsync($"http://{host}:5001/api/Client/post/{request.UserId}", request);
    }
}
