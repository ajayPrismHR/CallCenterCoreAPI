using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterCoreAPI.Models.QueryModel
{
    public class ModelComplaintType
    {
     
            public int ComplaintTypeId { get; set; }
            public string ComplaintType { get; set; }

        public int SubComplaintTypeId { get; set; }
        public string SubComplaintType { get; set; }
        public string ComplaintTileColor { get; set; }
        public bool Status { get; set; }

        public bool IS_ACTIVE { get; set; }
        public bool IS_DELETED { get; set; }
        public string COMPLAINT_COUNT { get; set; }
        public DateTime TIME_STAMP { get; set; }


        public List<ModelOfficeCode> lstComplaint { get; set; }

    }

    
}