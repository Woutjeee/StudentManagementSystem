using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using Website.Options;

namespace Website.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public ApiClient(
            HttpClient httpClient,
            NavigationManager navigationManager,
            AuthenticationStateProvider authenticationStateProvider,
            IOptions<ApplicationOptions> options)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _authenticationStateProvider = authenticationStateProvider;

            _httpClient.BaseAddress = new Uri($"https://{options.Value.Api.Host}:{options.Value.Api.Port}/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
