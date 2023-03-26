using CallCenterCoreAPI.Database.Repository;
using System.Diagnostics;

namespace CallCenterCoreAPI.Filters
{
    public class APILogging : DelegatingHandler
    {
        private readonly ILogger<APILogging> _logger;

        public APILogging(ILogger<APILogging> logger)
        {
            _logger = logger;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Content != null)
            {
                // log request body
                string requestBody = await request.Content.ReadAsStringAsync();
                _logger.LogInformation(requestBody);
                Trace.WriteLine(requestBody);
            }
            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content != null)
            {
                // once response body is ready, log it
                var responseBody = await result.Content.ReadAsStringAsync();
                _logger.LogInformation(responseBody);
                Trace.WriteLine(responseBody);
            }

            return result;
        }

    }
}
