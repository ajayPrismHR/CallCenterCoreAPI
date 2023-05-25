using Azure;
using CallCenterCoreAPI.ExternalAPI.TextSmsAPI;
using CallCenterCoreAPI.Models;
using CallCenterCoreAPI.Models.QueryModel;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Device.Location;
using CallCenterCoreAPI.Models.ViewModel;

namespace CallCenterCoreAPI.Database.Repository
{
    public class ComplaintRepository
    {
        private readonly ILogger<ComplaintRepository> _logger;
        private string conn = AppSettingsHelper.Setting(Key: "ConnectionStrings:DevConn");
        public ComplaintRepository(ILogger<ComplaintRepository> logger)
        {
            _logger = logger;
        }

        #region SendSmsRep
        /// <summary>
        /// Save Complaint
        /// </summary>
        /// <param name="modelComplaint"></param>
        /// <returns></returns>
        public async Task<string> SendSmsRep(SMSModel smsmodel)
        {
            string retStatus = "0";
            _logger.LogInformation(smsmodel.to.ToString());
            ModelSmsAPI modelSmsAPI = new ModelSmsAPI();
            modelSmsAPI.To = "91" + smsmodel.to.ToString();
            modelSmsAPI.Smstext = smsmodel.smsText;
            try
            {
                TextSmsAPI textSmsAPI = new TextSmsAPI();
                string response = await textSmsAPI.RegisterComplaintSMS(modelSmsAPI);
                //modelComplaint.SMS = modelSmsAPI.Smstext;
                _logger.LogInformation(response.ToString());

                UPDATE_SMS_DETAIL_Consumer(response, smsmodel.id);
                retStatus = response;
            }
            catch
            {
                retStatus = "0";
            }

            return retStatus;

        }
        #endregion
        //#region GetLocationProperty
        //static void GetLocationProperty()
        //{
        //    GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

        //    // Do not suppress prompt, and wait 1000 milliseconds to start.
        //    watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

        //    GeoCoordinate coord = watcher.Position.Location;

        //    if (coord.IsUnknown != true)
        //    {
        //        Console.WriteLine("Lat: {0}, Long: {1}",
        //            coord.Latitude,
        //            coord.Longitude);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Unknown latitude and longitude.");
        //    }
        //}
        //#endregion
        public int UPDATE_SMS_DETAIL_Consumer(string response, string id)
        {
            int retStatus = 0;
            string retMsg = String.Empty; ;
            SqlParameter[] param =
                {
                new SqlParameter("@id",id),
                new SqlParameter("@DELIVERY_RESPONSE",response)};
            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "UPDATE_SMS_DETAIL", param);
            }
            catch (Exception ex)
            {
                retStatus = -1;
            }

            return retStatus;

        }

        public async Task<int> AddUser(SignUPModel UserDetail)
        {
            int retStatus = 0;
            SqlParameter parmretStatus = new SqlParameter();
            parmretStatus.ParameterName = "@retStatus";
            parmretStatus.DbType = DbType.Int32;
            parmretStatus.Size = 8;
            parmretStatus.Direction = ParameterDirection.Output;
            SqlParameter[] param ={
                    new SqlParameter("@USER_NAME",UserDetail.USER_NAME),
                    new SqlParameter("@PASSWORD",Utility.EncryptText(UserDetail.PASSWORD.Trim())),
                    new SqlParameter("@NAME",UserDetail.NAME),
                    new SqlParameter("@ADDRESS",UserDetail.ADDRESS),
                    new SqlParameter("@MOBILE_NO",UserDetail.MOBILE_NO),
                    new SqlParameter("@EMAIL_ID",UserDetail.EMAIL_ID),
                    parmretStatus
                    };
            SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "SignUpConsumer", param);
            if (param[6].Value != DBNull.Value)// status
                retStatus = Convert.ToInt32(param[6].Value);
            else
                retStatus = 2;
            return retStatus;
        }

        public async Task<int> Attendance(AttendanceModel AttendanceDetail)
        {
            int retStatus = 0;
            SqlParameter parmretStatus = new SqlParameter();
            parmretStatus.ParameterName = "@retStatus";
            parmretStatus.DbType = DbType.Int32;
            parmretStatus.Size = 8;
            parmretStatus.Direction = ParameterDirection.Output;
            SqlParameter[] param ={
                    new SqlParameter("@EMP_ID",AttendanceDetail.Emp_Id),
                    new SqlParameter("@IP_ADDRESS",AttendanceDetail.IP_Address),
                    new SqlParameter("@Device_ID",AttendanceDetail.Device_ID),
                    new SqlParameter("@Latitude",AttendanceDetail.Latitude),
                    new SqlParameter("@Lognitude",AttendanceDetail.Lognitude),
                    new SqlParameter("@Leave_Type",AttendanceDetail.Leave_Type),
                    new SqlParameter("@Remark",AttendanceDetail.Remark),
                    new SqlParameter("@att_Type",AttendanceDetail.att_Type),
                    parmretStatus
                    };
            SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "EMPLOYEE_ATTENDANCE", param);
            if (param[8].Value != DBNull.Value)// status
                retStatus = Convert.ToInt32(param[8].Value);
            else
                retStatus = 2;
            return retStatus;
        }


        public async Task<int> UpdateDetail(ModelUser UserDetail)
        {
            int retStatus = 0;
            try
            {
                SqlParameter parmretStatus = new SqlParameter();
                parmretStatus.ParameterName = "@retStatus";
                parmretStatus.DbType = DbType.Int32;
                parmretStatus.Size = 8;
                parmretStatus.Direction = ParameterDirection.Output;
                long uid = Convert.ToInt64(UserDetail.User_id);
                SqlParameter[] param ={
                    new SqlParameter("@User_ID",uid),
                    new SqlParameter("@Name",UserDetail.Name),
                    new SqlParameter("@Address",UserDetail.Address),
                    new SqlParameter("@Email",UserDetail.Email),
                    new SqlParameter("@Phone",Convert.ToInt64(UserDetail.Mobile_NO)),
                    parmretStatus
                    };

                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "UpdateUsers", param);
                if (param[5].Value != DBNull.Value)// status
                    retStatus = Convert.ToInt32(param[5].Value);
                else
                    retStatus = 0;
            }
            catch (Exception ex)
            {
                retStatus = -1;
            }
            return retStatus;
        }

        public List<ModelUser> GetDetail(long userid)
        {
            List<ModelUser> obj = new List<ModelUser>();
            SqlParameter[] param ={
                    new SqlParameter("@USER_ID",userid)};
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetUsers", param);
            //Bind Complaint generic list using dataRow     
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                obj.Add(

                    new ModelUser
                    {
                        User_id = Convert.ToInt32(dr["USER_ID"]),
                        User_Name = Convert.ToString(dr["USER_NAME"]),
                        Name = Convert.ToString(dr["NAME"]),
                        Role = Convert.ToString(dr["ROLE_NAME"]),
                        Mobile_NO = Convert.ToInt64(dr["MOBILE_NO"]),
                        Email = Convert.ToString(dr["EMAIL_ID"]),
                        Address = Convert.ToString(dr["ADDRESS"]),
                    }
                    );
            }
            return (obj);
        }
        public List<ModelLeaveView> LeaveView(ModelLeaveData user)
        {
            List<ModelLeaveView> userViewModel = new List<ModelLeaveView>();
            ModelLeaveView leaveViewModelReturn = new ModelLeaveView();
            try
            {
                SqlParameter[] param = { new SqlParameter("@EMP_NAME", user.Emp_name.Trim())};
                DataSet dataSet = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "DAILYWISE_LEAVE", param);
                userViewModel = AppSettingsHelper.ToListof<ModelLeaveView>(dataSet.Tables[0]);
                leaveViewModelReturn = userViewModel[0];
                _logger.LogInformation(conn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return userViewModel;
        }
        public List<ModelEmpCalander> CalanderView(ModelCalanderData user)
        {
            List<ModelEmpCalander> userViewModel = new List<ModelEmpCalander>();
            try
            {
                SqlParameter[] param = { new SqlParameter("@EMP_NAME", user.Emp_name.Trim()),
                    new SqlParameter("@MONTH",user.month),
                    new SqlParameter("@YEAR",user.year)     };
                DataSet dataSet = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "EMPLOYEE_CALANDER", param);
                userViewModel = AppSettingsHelper.ToListof<ModelEmpCalander>(dataSet.Tables[0]);
                _logger.LogInformation(conn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return userViewModel;
        }
    }
}
