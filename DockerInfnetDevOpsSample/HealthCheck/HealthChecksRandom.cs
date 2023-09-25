using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DockerInfnetDevOpsSample.HealthCheck
{
    public class HealthCheckRandom : IHealthCheck
    {
        private readonly HttpClient _httpClient;

        public HealthCheckRandom(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("appkey", "appkey_key");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("appsecret", "appkey_secret");

            HttpResponseMessage response;
            if (Random.Shared.Next() % 2 == 0)
            {
                response = await _httpClient.GetAsync("http://httpbin.org/status/200");
            }
            else
            {
                response = await _httpClient.GetAsync("http://httpbin.org/status/500");
            }

            return response.IsSuccessStatusCode ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy(description: "Erro.");
        }
    }
}