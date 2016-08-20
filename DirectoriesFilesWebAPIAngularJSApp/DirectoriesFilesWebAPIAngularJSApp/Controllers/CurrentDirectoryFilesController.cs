using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DirectoriesFilesWebAPIAngularJSApp.Controllers
{
    public class CurrentDirectoryFilesController : ApiController
    {
        // GET: api/CurrentDirectoryFiles/str
        public string[] Get([FromUri]string str)
        {
            string[] tempT = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string temp = String.Join("\\", tempT);
            string currentStr = temp.Substring(0, 1) + ":\\" + temp.Substring(1);

            string[] directories = Directory.GetFiles(currentStr);
            string[] shortdirectories = new string[directories.Length];

            for (int i = 0; i < directories.Length; i++)
            {
                string[] words = directories[i].Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                shortdirectories[i] = words[words.Length - 1];
            }

            return shortdirectories;
        }

    }
}
