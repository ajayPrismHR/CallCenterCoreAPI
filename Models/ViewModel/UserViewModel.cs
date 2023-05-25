namespace CallCenterCoreAPI.Models.ViewModel
{
    public class UserViewModel
    {
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string NAME { get; set; }
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public bool Remember_Me { get; set; }
        public int ID { get; set; }
        public string Menu_Name { get; set; }
        public int Sub_MenuID { get; set; }
        public string Sub_Menu_Name { get; set; }
        public string ViewURL { get; set; }
        public long OFFICE_ID { get; set; }
        public string PHONE_LOGIN { get; set; }
        public string PHONE_PASS { get; set; }
        public string AccessToken { get; set; }
    }
    
}
