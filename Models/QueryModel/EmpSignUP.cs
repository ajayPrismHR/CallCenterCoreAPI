namespace CallCenterCoreAPI.Models.QueryModel
{
    public class EmpSignUP
    {
        public string EMP_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL { get; set; }
        public string PHOTO { get; set; }
        public Int64 ROLE_ID { get; set; }
        public Int64 MANGERID { get; set; }
        public Int64 OFFICE_ID { get; set; }
        public string LATITUDE { get; set; }
        public string LOGNITUDE { get; set; }
        public string LOGIN_WITHIN_RANGE { get; set; }
    }
}
