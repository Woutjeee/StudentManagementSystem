using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Services;
using Website.Options;

namespace Website.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IIWSessionStorageService _protectedBrowserStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public ApiClient(
            HttpClient httpClient,
            IIWSessionStorageService protectedBrowserStorage,
            AuthenticationStateProvider authenticationStateProvider,
            IOptions<ApplicationOptions> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"https://{options.Value.Api.Host}:{options.Value.Api.Port}/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _protectedBrowserStorage = protectedBrowserStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> PostItem<T>(string apiCall, T Value)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiCall, Value);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
