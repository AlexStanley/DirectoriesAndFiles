using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DirectoriesFilesWebAPIAngularJSApp.Controllers
{
    public class FilesDirectoryController : ApiController
    {
        // GET: api/FilesDirectory/str
        public Dictionary<string, int> Get([FromUri]string str)
        {
            string[] tempT = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string temp = String.Join("\\", tempT);
            string currentStr = temp.Substring(0, 1) + ":\\" + temp.Substring(1);

            DirectoryInfo directories = new DirectoryInfo(currentStr);

            //int[] arr = { 0, 0, 0 };

            Dictionary<string, int> arr = new Dictionary<string, int>();
            arr.Add("zero", 0);
            arr.Add("one", 0);
            arr.Add("two", 0);

            Directories(directories.ToString(), arr);

            return arr;
        }

        private static void Directories(string directory, Dictionary<string, int> ar)
        {
            DirectoryInfo dirrctories2 = new DirectoryInfo(directory);

            Dictionary<string, int> arr = ar;

            if (Directory.GetDirectories(dirrctories2.ToString()).ToArray() != null)
            {
                var items = Directory.GetDirectories(dirrctories2.ToString());

                for (int t = 0; t < items.Length; t++)
                {
                    try
                    {
                        Directories(items[t] + "\\", arr);
                    }
                    catch (Exception ex)
                    {
                        t++;
                        continue;
                    }
                }
            }

            foreach (var s in dirrctories2.GetFiles())
            {
                if (s.Length <= 10240000)
                    arr["zero"]++;
                else if (s.Length > 10240000 && s.Length <= 51200000)
                    arr["one"]++;
                else if (s.Length >= 102400000)
                    arr["two"]++;
            }
        }

    }
}
