
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace CallCenterCoreAPI.Models.QueryModel
{

    public class ComplaintSearchQueryModel
    {
        public string KNO { get; set; }
        public string ComplaintNo { get; set; }
    }
}