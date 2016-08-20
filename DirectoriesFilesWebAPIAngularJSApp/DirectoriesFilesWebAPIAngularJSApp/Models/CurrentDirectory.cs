using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoriesFilesWebAPIAngularJSApp.Models
{
    public class CurrentDirectory
    {
        public string LongName { get; set; }

        public string ShortName { get; set; }

        public CurrentDirectory(string ln, string sn)
        {
            this.LongName = ln;
            this.ShortName = sn;
        }
    }
}