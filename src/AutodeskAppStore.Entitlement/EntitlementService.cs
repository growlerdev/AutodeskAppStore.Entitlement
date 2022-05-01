using RestSharp;
using System.Net;
using Inventor;

namespace AutodeskAppStore.Entitlement
{
    public static class EntitlementService
    {
        /// <summary>
        /// Checks if the current user has a valid Autodesk App Store Entitlement to use the App with the specified App ID
        /// </summary>
        /// <param name="inventor"></param>
        /// <param name="AppID">Can be obtained from the Autodesk App Store Publisher Corner</param>
        /// <returns></returns>
        public static bool ValidAppUser(this Application inventor, string AppID)
        {
            string _userID = "";

            //Force Login to Autodesk SSO - workaround for Inventor 2020+
            inventor.Login();

            try
            {
                _userID = WebServicesUtils_18Plus.GetUserId();              
            }
            catch
            {
                _userID = WebServicesUtils.GetUserId(out var userName);
            }

            //Not logged in with Autodesk Id, hence we can not get user id
            if (_userID.Equals(""))
            {
                return false;
            }

            //Check for online entitlement

            RestClient client = new RestClient("https://apps.autodesk.com");

            RestRequest req = new RestRequest("webservices/checkentitlement");

            req.Method = Method.GET;
            req.AddParameter("userid", _userID);
            req.AddParameter("appid", AppID);

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            IRestResponse<EntitlementResponse> resp = client.Execute<EntitlementResponse>(req);

            if (resp.Data != null && resp.Data.IsValid)
            {
                //User has downloaded the App from the store and hence is a valid user...
                return true;
            }
            else
            {
                //Not a valid user. Entitlement check failed.  
                return false;
            }
        }

    }

}




