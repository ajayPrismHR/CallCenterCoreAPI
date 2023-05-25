using CallCenterCoreAPI.Database.Repository;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CallCenterCoreAPI.Models.QueryModel;
using CallCenterCoreAPI.Models.ViewModel;
using CallCenterCoreAPI.Controllers;
using Serilog;
using Microsoft.Extensions.Logging;
using CallCenterCoreAPI.Filters;
namespace CallCenterCoreAPI.Database.Repository
{
    public class LoginRepository 
    {
   
        private readonly ILogger<LoginRepository> _logger;

        public LoginRepository(ILogger<LoginRepository> logger)
        {
            _logger = logger;
        }

        private string conn=AppSettingsHelper.Setting(Key: "ConnectionStrings:DevConn");


        public UserViewModel ValidateUser(UserRequestQueryModel user)
        {
            List<UserViewModel> userViewModel = new List<UserViewModel>();
            UserViewModel userViewModelReturn = new UserViewModel();  
            try
            {
                SqlParameter[] param ={new SqlParameter("@Username",user.LoginId.Trim()),new SqlParameter("@Password",Utility.EncryptText(user.Password.Trim()) )};
                DataSet dataSet = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "Validate_User_API_LOGIN", param);
                userViewModel = AppSettingsHelper.ToListof<UserViewModel>(dataSet.Tables[0]);
                userViewModelReturn = userViewModel[0];
                _logger.LogInformation(conn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return userViewModelReturn;
        }

        public UserViewAPIModel ValidateUserAPI(UserRequestQueryModel user)
        {
            List<UserViewAPIModel> userViewModel = new List<UserViewAPIModel>();
            UserViewAPIModel userViewModelReturn = new UserViewAPIModel();
            try
            {
                SqlParameter[] param = { new SqlParameter("@Username", user.LoginId.Trim()), new SqlParameter("@Password", Utility.EncryptText(user.Password.Trim())) };
                DataSet dataSet = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "Validate_User_API_LOGIN", param);
                userViewModel = AppSettingsHelper.ToListof<UserViewAPIModel>(dataSet.Tables[0]);
                userViewModelReturn = userViewModel[0];
                _logger.LogInformation(conn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return userViewModelReturn;
        }

        public async Task<int> ChangePassword(UserRequestQueryModel User)
        {
            string msg = Utility.EncryptText(User.Password);
            int retStatus = 0;
            SqlParameter parmretStatus = new SqlParameter();
            parmretStatus.ParameterName = "@retStatus";
            parmretStatus.DbType = DbType.Int32;
            parmretStatus.Size = 8;
            parmretStatus.Direction = ParameterDirection.Output;
            SqlParameter[] param ={
                    new SqlParameter("@Emp_Name",User.LoginId),
                    new SqlParameter("@PASSWORD",msg),
                    parmretStatus
                    };
            SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "ChangePassword", param);
            if (param[2].Value != DBNull.Value)// status
                retStatus = Convert.ToInt32(param[2].Value);
            else
                retStatus = 2;
            return retStatus;
        }

        public async Task<string> SignUP(EmpSignUP User)
        {
            string msg = Utility.EncryptText(User.PASSWORD);
            string retStatus = "";
            SqlParameter parmretStatus = new SqlParameter();
            parmretStatus.ParameterName = "@RETSTATUS";
            parmretStatus.DbType = DbType.Int32;
            parmretStatus.Size = 8;
            parmretStatus.Direction = ParameterDirection.Output;
            SqlParameter parmretmsg = new SqlParameter();
            parmretStatus.ParameterName = "@RETMSG";
            parmretStatus.DbType = DbType.String;
            parmretStatus.Size = 8;
            parmretStatus.Direction = ParameterDirection.Output;
            SqlParameter[] param ={
                    new SqlParameter("@EMP_NAME",User.EMP_NAME),
                    new SqlParameter("@PASSWORD",msg),
                    new SqlParameter("@NAME",User.NAME),
                    new SqlParameter("@ADDRESS",User.ADDRESS),
                    new SqlParameter("@MOBILE_NO",User.MOBILE_NO),
                    new SqlParameter("@PHOTO",User.PHOTO),
                    new SqlParameter("@EMAIL",User.EMAIL),
                    new SqlParameter("@ROLE_ID",User.ROLE_ID),
                    new SqlParameter("@MANGERID",User.MANGERID),
                    new SqlParameter("@OFFICE_ID",User.OFFICE_ID),
                    new SqlParameter("@LATITUDE",User.LATITUDE),
                    new SqlParameter("@LOGNITUDE",User.LOGNITUDE),
                    new SqlParameter("@LOGIN_WITHIN_RANGE",User.LOGIN_WITHIN_RANGE),
                    parmretStatus,parmretmsg
                    };
            SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "SIGN_UP", param);
            if (param[13].Value != DBNull.Value)// status
                retStatus = Convert.ToString(param[14].Value);
            else
                retStatus = "Error";
            return retStatus;
        }

    }



}
