using DirectoriesFilesWebAPIAngularJSApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DirectoriesFilesWebAPIAngularJSApp.Controllers
{
    public class CurrentDirectoryController : ApiController
    {
        // GET: api/CurrentDirectory/str
        public CurrentDirectory[] Get([FromUri]string str)
        {
            string[] tempT = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string temp = String.Join("\\", tempT);
            string currentStr = temp.Substring(0, 1) + ":\\" + temp.Substring(1);

            CurrentDirectory[] fulldirectories;

            try
            {
                string[] directories = Directory.GetDirectories(currentStr);
                string[] shortdirs = new string[directories.Length];

                for (int i = 0; i < directories.Length; i++)
                {
                    string[] words = directories[i].Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                    shortdirs[i] = words[words.Length - 1];
                }

                fulldirectories = new CurrentDirectory[directories.Length];

                for (int i = 0; i < directories.Length; i++)
                {
                    CurrentDirectory currentdirectory = new CurrentDirectory(directories[i], shortdirs[i]);
                    fulldirectories[i] = currentdirectory;
                }

                return fulldirectories;
            }
            catch (Exception ex)
            {
                fulldirectories = new CurrentDirectory[1];

                CurrentDirectory currentdirectory = new CurrentDirectory(ex.Message.ToString(), ex.Message.ToString());
                fulldirectories[0] = currentdirectory;

                return fulldirectories;
            }

        }
    }
}
