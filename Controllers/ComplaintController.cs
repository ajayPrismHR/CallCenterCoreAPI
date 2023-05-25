using CallCenterCoreAPI.Database.Repository;
using CallCenterCoreAPI.Models;
using CallCenterCoreAPI.Models.QueryModel;
using CallCenterCoreAPI.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        [Route("UpdateDetail")]
        public async Task<IActionResult> UpdateDetail(ModelUser UserDetail)
        {
            ReturnStatusModel returnStatus = new ReturnStatusModel();
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            int retStatus = await modelComplaintRepository.UpdateDetail(UserDetail);
            if (retStatus > 0)
            {
                returnStatus.response = 1;
                returnStatus.status = "Detail Updated Successfully";
                return Ok(returnStatus);
            }

            else
            {
                returnStatus.response = 0;
                returnStatus.status = "Error in Updating Details";
                return BadRequest(returnStatus);
            }

        }
        

        //[HttpPost]
        //[Route("SignUP")]
        //public async Task<IActionResult> SignUP(SignUPModel UserDetail)
        //{
        //    ReturnStatusModel returnStatus = new ReturnStatusModel();
        //    ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
        //    ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
        //    int retStatus = await modelComplaintRepository.AddUser(UserDetail);
        //    if (retStatus == 1)
        //    {
        //        returnStatus.response = 1;
        //        returnStatus.status = "User has been Successfully";
        //        return Ok(returnStatus);
        //    }
        //    else if (retStatus == 0)
        //    {
        //        returnStatus.response = 0;
        //        returnStatus.status = "User Name already exist";
        //        return Ok(returnStatus);
        //    }

        //    else
        //    {
        //        returnStatus.response = 0;
        //        returnStatus.status = "Error in Registeration Please try again";
        //        return BadRequest(returnStatus);
        //    }

        //}

        [HttpPost]
        [Route("SendSms")]
        public async Task<IActionResult> SendSms(SMSModel smsmodel)
        {
            ReturnStatusModel returnStatus = new ReturnStatusModel();
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            string retStatus = "0";
            string msg = string.Empty;
            retStatus = await modelComplaintRepository.SendSmsRep(smsmodel);
            if (retStatus == "0")
            {
                returnStatus.response = 0;
                returnStatus.status = "Error in Sending SMS";
                return BadRequest(returnStatus);
                
            }

            else
            {
                returnStatus.response = 1;
                returnStatus.status = retStatus;
                return Ok(returnStatus);
            }


        }

        [HttpPost]
        [Route("PunchAttendance")]
        public async Task<IActionResult> PunchAttendance(AttendanceModel AttendanceDetail)
        {
            ReturnStatusModel returnStatus = new ReturnStatusModel();
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            int retStatus = await modelComplaintRepository.Attendance(AttendanceDetail);
            if (retStatus == 1)
            {
                returnStatus.response = 1;
                returnStatus.status = "Attendance Punched Successfully";
                return Ok(returnStatus);
            }
            else
            {
                returnStatus.response = 0;
                returnStatus.status = "Attendance Not Punched";
                return Ok(returnStatus);
            }

        }

        [HttpPost]
        [Route("PunchLeave")]
        public async Task<IActionResult> PunchLeave(AttendanceModel AttendanceDetail)
        {
            ReturnStatusModel returnStatus = new ReturnStatusModel();
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            int retStatus = await modelComplaintRepository.Attendance(AttendanceDetail);
            if (retStatus == 1)
            {
                returnStatus.response = 1;
                returnStatus.status = "Leave Punched Successfully";
                return Ok(returnStatus);
            }
            else
            {
                returnStatus.response = 0;
                returnStatus.status = "Leave Not Punched";
                return Ok(returnStatus);
            }

        }
        [HttpPost]
        [Route("GetLeaveDetail")]
        public IActionResult GetLeaveDetail(ModelLeaveData modelUser)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            List<ModelLeaveView> leaveViewModels ;

            leaveViewModels = modelComplaintRepository.LeaveView(modelUser);
            
            return Ok(leaveViewModels);
        }
        [HttpPost]
        [Route("GetEmployeeCalander")]
        public IActionResult GetEmployeeCalander(ModelCalanderData modelUser)
        {
            ILogger<ComplaintRepository> modelLogger = _loggerFactory.CreateLogger<ComplaintRepository>();
            ComplaintRepository modelComplaintRepository = new ComplaintRepository(modelLogger);
            List<ModelEmpCalander> CalanderViewModels;

            CalanderViewModels = modelComplaintRepository.CalanderView(modelUser);

            return Ok(CalanderViewModels);
        }
    }
    
}
