
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace CallCenterCoreAPI.Models.QueryModel
{

    public class MST_COMPLAINT_STEPS
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public int COMPLAINT_status { get; set; }
        public bool IS_ACTIVE { get; set; }
        public bool IS_DELETED { get; set; }
        public DateTime TIME_STAMP { get; set; }
    }

    

    public class COMPLAINT
    {
        public long OFFICE_CODE { get; set; }
        public int ComplaintTypeId { get; set; } //ref MST_COMPLAINT_TYPE
        public string NAME { get; set; }
        public string FATHER_NAME { get; set; }
        public string KNO { get; set; }
        public string LANDLINE_NO { get; set; }
        public int sourceId { get; set; }
        public string MOBILE_NO { get; set; }
        public string ALTERNATE_MOBILE_NO { get; set; }
        public string EMAIL { get; set; }
        public string ACCOUNT_NO { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string LANDMARK { get; set; }
        public string CONSUMER_STATUS { get; set; }
        public string FEEDER_NAME { get; set; }
        public string AREA_CODE { get; set; }
        public string REMARKS { get; set; }
        public int UserId { get; set; }
    }

    public class COMPLAINT_SEARCH
    {
        public long OFFICE_CODE { get; set; }
        public string ComplaintType { get; set; } //ref MST_COMPLAINT_TYPE
        public string ComplaintNo { get; set; }
        public string NAME { get; set; }
        public string FATHER_NAME { get; set; }
        public string KNO { get; set; }
        public string LANDLINE_NO { get; set; }
        public string source { get; set; }
        public string MOBILE_NO { get; set; }
        public string ALTERNATE_MOBILE_NO { get; set; }
        public string ADDRESS { get; set; }

    }

    public class MST_SUB_COMPLAINT_TYPE
    {
        public int ID { get; set; }
        public string SUB_COMPLAINT_TYPE { get; set; }
        public int COMPLAINT_TYPE_ID { get; set; } //ref MST_COMPLAINT_TYPE
        public bool IS_ACTIVE { get; set; }
        public bool IS_DELETED { get; set; }

        public DateTime TIME_STAMP { get; set; }


    }
    public class COMPLAINT_REMARK
    {
        public DateTime REMARK_DATE_TIME { get; set; }
        public string REMARK { get; set; }
        public string REMARKBY { get; set; }
        public string ComplaintNumber { get; set; }
        public bool IS_ACTIVE { get; set; }
        public bool IS_DELETED { get; set; }
        public DateTime TIME_STAMP { get; set; }

    }

    public class COMPLAINT_LOG
    {
        public string ActionType { get; set; }
        public DateTime DateTime { get; set; }

        public string State { get; set; }
        public string Remarks { get; set; }

        public string Source { get; set; }
        public string UserID { get; set; }
        public string ComplaintNumber { get; set; }
    }

}