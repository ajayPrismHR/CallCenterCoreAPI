using CallCenterCoreAPI.Models.QueryModel;
using System.Data;
using System.Data.SqlClient;

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
        public int SaveComplaint(COMPLAINT modelComplaint, int sourceId)
        {
            int retStatus = 0;
            string retMsg = String.Empty; ;
            COMPLAINT obj = new COMPLAINT();
            obj = modelComplaint;

            SqlParameter parmretStatus = new SqlParameter();
            parmretStatus.ParameterName = "@retStatus";
            parmretStatus.DbType = DbType.Int32;
            parmretStatus.Size = 8;
            parmretStatus.Direction = ParameterDirection.Output;

            SqlParameter parmretMsg = new SqlParameter();
            parmretMsg.ParameterName = "@retMsg";
            parmretMsg.DbType = DbType.String;
            parmretMsg.Size = 8;
            parmretMsg.Direction = ParameterDirection.Output;


            SqlParameter parmretComplaint_no = new SqlParameter();
            parmretComplaint_no.ParameterName = "@retComplaint_no";
            parmretComplaint_no.DbType = DbType.Int32;
            parmretComplaint_no.Size = 8;
            parmretComplaint_no.Direction = ParameterDirection.Output;
            SqlParameter[] param ={
                    new SqlParameter("@OFFICE_CODE",modelComplaint.OFFICE_CODE_ID),
                    new SqlParameter("@CONSUMER_TYPE",1),
                    new SqlParameter("@COMPLAINT_TYPE",modelComplaint.ComplaintTypeId),
                    new SqlParameter("@COMPLAINT_SOURCE_ID",sourceId),//modelComplaint.com),
                    new SqlParameter("@COMPLAINT_CURRENT_STATUS_ID",10),//modelComplaint.COMPLAINT_status_ID),
                    new SqlParameter("@COMPLAINT_status",1),//modelComplaint.COMPLAINT_status_ID),
                    new SqlParameter("@SDO_CODE",modelComplaint.SDO_CODE),
                    new SqlParameter("@NAME",modelComplaint.NAME),

                    new SqlParameter("@FATHER_NAME",modelComplaint.FATHER_NAME),
                    new SqlParameter("@KNO",modelComplaint.KNO),
                    new SqlParameter("@LANDLINE_NO",modelComplaint.LANDLINE_NO),
                    new SqlParameter("@MOBILE_NO",modelComplaint.MOBILE_NO),
                    new SqlParameter("@ALTERNATE_MOBILE_NO",modelComplaint.ALTERNATE_MOBILE_NO),
                    new SqlParameter("@EMAIL",modelComplaint.EMAIL),
                    new SqlParameter("@ACCOUNT_NO",modelComplaint.ACCOUNT_NO),
                    new SqlParameter("@ADDRESS1",modelComplaint.ADDRESS1),
                    new SqlParameter("@ADDRESS2",modelComplaint.ADDRESS2),
                    new SqlParameter("@ADDRESS3",modelComplaint.ADDRESS3),

                    new SqlParameter("@LANDMARK",modelComplaint.LANDMARK),
                    new SqlParameter("@CONSUMER_STATUS",modelComplaint.CONSUMER_STATUS),
                    new SqlParameter("@FEEDER_NAME",modelComplaint.FEEDER_NAME),
                    new SqlParameter("@AREA_CODE",modelComplaint.AREA_CODE),
                    new SqlParameter("@REMARKS",modelComplaint.REMARKS),
                     new SqlParameter("@USER_ID",modelComplaint.UserId),
                     new SqlParameter("@AssigneeId",1),
                    parmretStatus,parmretMsg,parmretComplaint_no};
            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "COMPLAINTS_REGISTER_API", param);

                if (param[37].Value != DBNull.Value)// status
                    retStatus = Convert.ToInt32(param[37].Value);
                else
                    retStatus = 0;
            }
            catch (Exception ex)
            {
                retStatus = -1;
            }
            return retStatus;

        }
        public DataSet SearchComplaint(string kno)
        {
            DataSet ds= new DataSet();
            try
            {
                SqlParameter[] param ={new SqlParameter("@kno",kno)};
                ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "Search_Complaint", param);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
    }
}
