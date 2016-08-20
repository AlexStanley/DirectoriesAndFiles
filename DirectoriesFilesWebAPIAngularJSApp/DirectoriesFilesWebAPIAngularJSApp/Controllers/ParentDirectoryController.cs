using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DirectoriesFilesWebAPIAngularJSApp.Controllers
{
    public class ParentDirectoryController : ApiController
    {
        // GET: api/ParentDirectory/str
        public string Get([FromUri]string str)
        {
            string[] tempT = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string temp = String.Join("\\", tempT);
            string currentStr = temp.Substring(0, 1) + ":\\" + temp.Substring(1);

            string directories = Directory.GetParent(currentStr).ToString();

            return directories;
        }

    }
}
