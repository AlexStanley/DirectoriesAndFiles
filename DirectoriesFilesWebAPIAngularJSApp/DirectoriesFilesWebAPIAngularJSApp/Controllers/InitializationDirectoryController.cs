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
    public class InitializationDirectoryController : ApiController
    {
        // GET: api/InitializationDirectory
        public CurrentDirectory[] Get()
        {
            // получение всех дисков на компьютере
            DriveInfo[] drives = DriveInfo.GetDrives();

            CurrentDirectory[] discs = new CurrentDirectory[drives.Length];

            for (int q = 0; q < drives.Length; q++)
            {
                CurrentDirectory temp = new CurrentDirectory(drives[q].Name, drives[q].Name);
                discs[q] = temp;
            }

            return discs;
        }     
    }
}
