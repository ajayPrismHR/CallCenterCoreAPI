using CallCenterCoreAPI.Models;
using RestSharp;
namespace CallCenterCoreAPI.ExternalAPI.TextSmsAPI
{
    public class TextSmsAPI
    {
        
        ModelSmsAPI modelsmsClone = null;
        public async Task<string> RegisterComplaintSMS(ModelSmsAPI modelsms)
        {
            //log.Information("IN RegisterComplaintSMS");
            modelsmsClone = modelsms;
            var client = new RestClient(modelsmsClone.SmsApiURL);
            var restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(new
            {
                appid = modelsmsClone.Appid,
                userId = modelsmsClone.UserId,
                pass = modelsmsClone.Pass,
                contenttype = modelsmsClone.Contenttype,
                from = modelsmsClone.From,
                alert = modelsmsClone.Alert,
                selfid = modelsmsClone.Selfid,
                to = modelsmsClone.To,
                text = modelsmsClone.Smstext,

            });
            
            //log.Information("SmsApiURL" + modelsmsClone.SmsApiURL);
            //log.Information("smstext" + modelsmsClone.Smstext);

            var response = await client.ExecuteAsync(restRequest);

            //log.Information(response.Content);
            //log.Information(response.ResponseStatus.ToString());

            //response.Content
            if (response.StatusCode ==  System.Net.HttpStatusCode.OK)
            {
                
                return response.Content;
            }
            else
                return string.Empty;
        }
      

    }
}