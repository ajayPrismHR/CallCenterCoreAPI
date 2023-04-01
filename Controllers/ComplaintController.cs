using CallCenterCoreAPI.Database.Repository;
using CallCenterCoreAPI.Models.QueryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CallCenterCoreAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ComplaintController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;

        public ComplaintController(ILogger<ComplaintController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
        }

        [HttpPost]
        [Route("SaveComplaint")]
        public async Task<IActionResult> SaveComplaint(COMPLAINT modelComplaint)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            Int64 retStatus = 0;
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
                retStatus = await modelComplaintRepository.SaveComplaint(modelComplaint);
            }
            if (retStatus > 0)
                return Ok("Complaint Successfully Registered With Complaint No. "+retStatus.ToString());
            else
                return BadRequest("Error in Saving Complaint");
           
        }

        [HttpPost]
        [Route("SearchComplaintByKNO")]
        public IActionResult SearchComplaintByKNO(ComplaintSearchQueryModel complaintSearchQueryModel)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            List<COMPLAINT_SEARCH> lstComplaints = modelComplaintRepository.GetPreviousComplaintByKno(complaintSearchQueryModel.KNO);
            return Ok(lstComplaints);
        }

        [HttpPost]
        [Route("SearchComplaintByComplaintNo")]
        public IActionResult SearchComplaintByComplaintNo(ComplaintSearchQueryModel complaintSearchQueryModel)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            List<COMPLAINT_SEARCH> lstComplaints = modelComplaintRepository.GetPreviousComplaintNo(complaintSearchQueryModel.ComplaintNo);
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
