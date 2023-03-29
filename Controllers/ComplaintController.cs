using CallCenterCoreAPI.Database.Repository;
using CallCenterCoreAPI.Models;
using CallCenterCoreAPI.Models.QueryModel;
using CallCenterCoreAPI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Linq;
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

        [HttpPost]
        [Route("SearchComplaintByKNO")]
        public IActionResult SearchComplaintByKNO(string kNO)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            List<COMPLAINT_SEARCH> lstComplaints = modelComplaintRepository.GetPreviousComplaintByKno(kNO);
            return Ok(lstComplaints);
        }

        [HttpPost]
        [Route("SearchComplaintByComplaintNo")]
        public IActionResult SearchComplaintByComplaintNo(string complaintNo)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            List<COMPLAINT_SEARCH> lstComplaints = modelComplaintRepository.GetPreviousComplaintNo(complaintNo);
            return Ok(lstComplaints);
        }



        [HttpGet]
        [Route("GetOfficeList")]
        public IActionResult GetOfficeList()
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            List<ModelOfficeCode> lst;
            lst = modelComplaintRepository.GetOfficeList();
            return Ok(lst);
        }

        [HttpGet]
        [Route("GetComplaintTypeList")]
        public IActionResult GetComplaintTypeList(string officeid)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);

            List<ModelComplaintType> obj;
            obj = modelComplaintRepository.GetComplaintTypeList(officeid);
            return Ok(obj);
        }

        [HttpGet]
        [Route("GetSubComplaintTypeList")]
        public IActionResult GetSubComplaintTypeList(int ComplaintTypeId)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);

            List<ModelComplaintType> obj;
            obj = modelComplaintRepository.GetSubComplaintTypeList(ComplaintTypeId);
            return Ok(obj);
        }

    }
}
