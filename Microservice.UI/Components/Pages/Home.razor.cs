using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Microservice.UI.Components.Pages
{
    public partial class Home
    {
        [Inject] private HttpClient HttpClient { get; set; } = default!;

        [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

        [Inject] private IConfiguration Configuration { get; set; } = default!;

        private string ApiBaseUrl { get; set; } = string.Empty;

        private string FormattedApiResponse {  get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            ApiBaseUrl = Configuration[nameof(ApiBaseUrl)] ?? string.Empty;
        }

        private async Task GetAllMethod()
        {
            var apiResponse = await HttpClient.GetFromJsonAsync<JsonDocument>(ApiBaseUrl);

            FormattedApiResponse = JsonSerializer.Serialize(apiResponse, new JsonSerializerOptions { WriteIndented = true });

            StateHasChanged();
        }

        private async Task GetByIdMethod()
        {
            var randomNumber = Random.Shared.Next(1, 7);

            var apiResponse = await HttpClient.GetFromJsonAsync<JsonDocument>($"{ApiBaseUrl}/{randomNumber}");

            FormattedApiResponse = JsonSerializer.Serialize(apiResponse, new JsonSerializerOptions { WriteIndented = true });

            StateHasChanged();
        }

        private async Task GetNotFoundMethod()
        {
            await HttpClient.GetAsync($"{ApiBaseUrl}/7");

            var message = "404 response received successfully.";

            await JSRuntime.InvokeVoidAsync("showBrowserAlert", message);

            StateHasChanged();
        }

        private async Task GetExceptionMethod()
        {
            await HttpClient.GetAsync($"{ApiBaseUrl}/invalid-route");

            var message = "Exception thrown successfully.";

            await JSRuntime.InvokeVoidAsync("showBrowserAlert", message);

            StateHasChanged();
        }
    }
}
