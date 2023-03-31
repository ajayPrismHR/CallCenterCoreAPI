

using CallCenterCoreAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterCoreAPI.Models
{
    public class ModelSmsAPI 
    {
        private string _smsApiURL = AppSettingsHelper.Setting(Key: "SMSAPI:smsApiURL");
        private string _appid = AppSettingsHelper.Setting(Key: "SMSAPI:appid");
        private string _userid = AppSettingsHelper.Setting(Key: "SMSAPI:userid");
        private string _pass = AppSettingsHelper.Setting(Key: "SMSAPI:pass");
        private string _contenttype = AppSettingsHelper.Setting(Key: "SMSAPI:contenttype");
        private string _from = AppSettingsHelper.Setting(Key: "SMSAPI:from");
        private string _alert = AppSettingsHelper.Setting(Key: "SMSAPI:alert");
        private string _selfid = AppSettingsHelper.Setting(Key: "SMSAPI:selfid");

        private string _to;
        private string _smstext;
        public string SmsApiURL { get { return _smsApiURL; } }

        public string Appid {get {return _appid;}}
        public string UserId { get { return _userid; } }
        public string Pass { get { return _pass; } }
        public string Contenttype { get { return _contenttype; } }
        public string From { get { return _from; } }
        public string Alert { get { return _alert; } }
        public string Selfid { get { return _selfid; } }
        public string To { get { return _to;  }  set { _to = value;   }  }
        public string Smstext { get { return _smstext; } set { _smstext = value; } }

    }
}
