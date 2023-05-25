namespace CallCenterCoreAPI.Models.ViewModel
{
    public class UserViewModel
    {
        public Int64 EmpID { get; set; }
        public string Emp_Name { get; set; }
        public string NAME { get; set; }
        public Int64 ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string Latitude { get; set; }
        public string Lognitude { get; set; }
        public string Login_Within_Range { get; set; }
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public bool Is_On_Leave { get; set; }
        public bool Remember_Me { get; set; }
        public Int64 ID { get; set; }
        //public string Menu_Name { get; set; }
        //public int Sub_MenuID { get; set; }
        //public string Sub_Menu_Name { get; set; }
        //public string ViewURL { get; set; }
        public long OFFICE_ID { get; set; }
        //public string PHONE_LOGIN { get; set; }
        //public string PHONE_PASS { get; set; }
        public string AccessToken { get; set; }
    }
    
}
