using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VimeoVSV.Web.Helper
{
    public class Helper
    {

        public int GetRandomNumber(int maxLength)
        {
            Random rnd = new Random();
            int random = rnd.Next(maxLength - 1);
            return random;
        }

        public string GetVimeoVideoId(string url)
        {
            string vimeoVideoRegex = "(.*)(.com/)(.*)";
            string resp = Regex.Replace(url, vimeoVideoRegex, "$3");                   
            return resp.Replace("/", "?h="); ;
        }

    }
}
