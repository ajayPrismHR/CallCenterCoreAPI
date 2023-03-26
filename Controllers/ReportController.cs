using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;
        public ReportController(ILogger<ReportController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
        }

        [HttpGet]
        [Route("PendingReport")]
        public IActionResult PendingReport()
        {

            return Ok("Report");
        }
    }
}
