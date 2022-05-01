using Autodesk.WebServices;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AutodeskAppStore.Entitlement
{
    class WebServicesUtils_18Plus
    {

        [DllImport("AdWebServices", EntryPoint = "GetUserId", CharSet = CharSet.Unicode)]

        private static extern int AdGetUserId(StringBuilder userid, int buffersize);



        [DllImport("AdWebServices", EntryPoint = "IsWebServicesInitialized")]

        private static extern bool AdIsWebServicesInitialized();



        [DllImport("AdWebServices", EntryPoint = "InitializeWebServices")]

        private static extern void AdInitializeWebServices();



        [DllImport("AdWebServices", EntryPoint = "IsLoggedIn")]

        private static extern bool AdIsLoggedIn();



        [DllImport("AdWebServices", EntryPoint = "GetLoginUserName", CharSet = CharSet.Unicode)]

        private static extern int AdGetLoginUserName(StringBuilder username, int buffersize);

        public static string GetUserId()
        {
            //string username = "";



            CWebServicesManager mgr = new CWebServicesManager();

            bool isInitialize = mgr.Initialize();

            if (isInitialize == true)
            {

                string userId = "";

                mgr.GetUserId(ref userId);

                string username = "";

                mgr.GetLoginUserName(ref username);

                return userId;

            }
            else
                return "";
        }

    }
}
