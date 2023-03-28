
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
        public long OFFICE_CODE_ID { get; set; }
        [NotMapped]
        public List<ModelOfficeCode> OfficeCodeCollection { get; set; }

        [NotMapped]
        public List<ModelOfficeCode> OfficeCodeByParentCollection { get; set; }
        public string CONSUMER_TYPE { get; set; }

        public string ComplaintTypeName { get; set; } //ref MST_COMPLAINT_TYPE
        public int ComplaintTypeId { get; set; } //ref MST_COMPLAINT_TYPE
        public int ASSIGNEEId { get; set; }
        [NotMapped]
        public List<ModelComplaintType> ComplaintTypeCollection { get; set; }
        public List<ModelComplaintAssign> ComplaintAssignCollection { get; set; }
        public int COMPLAINT_status_ID { get; set; } // ref MST_COMPLAINT_STEPS
        public string JE_AREA { get; set; }
        public string SDO_CODE { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NAME { get; set; }
        public string FATHER_NAME { get; set; }
        public string KNO { get; set; }
        public string LANDLINE_NO { get; set; }

        [Required(ErrorMessage = "Mobile No. Required")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MOBILE_NO { get; set; }
        public string REJECTED_CAUSE { get; set; }
        public string ALTERNATE_MOBILE_NO { get; set; }
        public string EMAIL { get; set; }
        public string ACCOUNT_NO { get; set; }
        [Required(ErrorMessage = "ADDRESS 1 Required")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string LANDMARK { get; set; }
        public string CONSUMER_STATUS { get; set; }
        public string FEEDER_NAME { get; set; }
        public string AREA_CODE { get; set; }
        public int SUB_COMPLAINT_TYPE_ID { get; set; } //ref MST_SUB_COMPLAINT_TYPE
        public string REMARKS { get; set; }
        public string COMPLAINT_status { get; set; }
        public bool IS_UPDATED { get; set; }
        public DateTime UPDATED_TIME_STAMP { get; set; }
        public string Complaintdate { get; set; }
        public string COMPLAINT_NO { get; set; }

        public string COMPLAINT_TYPE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public int UserId { get; set; }

        public int ComplaintSource { get; set; }
        public int currentStatus { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public string SMS { get; set; }
        public string EMAIL_SEND { get; set; }
        public bool IS_SMS { get; set; }
        public bool IS_EMAIL { get; set; }
        public List<COMPLAINT_REMARK> ComplaintRemarkCollection { get; set; }

        public List<COMPLAINT_LOG> ComplaintLogCollection { get; set; }

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