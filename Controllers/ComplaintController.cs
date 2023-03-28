using CallCenterCoreAPI.Database.Repository;
using CallCenterCoreAPI.Models;
using CallCenterCoreAPI.Models.QueryModel;
using CallCenterCoreAPI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
namespace CallCenterCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComplaintController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;
        IConfiguration _configuration;

        private string conn = AppSettingsHelper.Setting(Key: "ConnectionStrings:DevConn");
        public ComplaintController(ILogger<ComplaintController> logger, ILoggerFactory loggerFactory,IConfiguration configuration)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("SaveComplaint")]
        public IActionResult SaveComplaint(COMPLAINT modelComplaint)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            int retStatus = 0;
            string msg = string.Empty;
            DataSet dsResponse = modelComplaintRepository.SearchComplaint(modelComplaint.KNO);
            if (dsResponse.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt16(dsResponse.Tables[0].Rows[0]["COMPLAINT_status"].ToString()) != 2)
                {
                    _logger.LogInformation("You Already Have Complaint No." + dsResponse.Tables[0].Rows[0]["COMPLAINT_NO"].ToString() + " with Status " + dsResponse.Tables[0].Rows[0]["cst"]);
                     return BadRequest("You Already Have Complaint No. " + dsResponse.Tables[0].Rows[0]["COMPLAINT_NO"].ToString() + " with Status " + dsResponse.Tables[0].Rows[0]["cst"]);
                }
            }
            else
            {
                retStatus = modelComplaintRepository.SaveComplaint(modelComplaint);
            }
            if (retStatus == 0)
                return Ok("Complaint Save Successfully");
            else
                return BadRequest("Error in Saving Complaint");
           
        }
        
    }
}
