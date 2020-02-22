using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiz_Film_Search.Services
{
    public class TokenRepoService : ITokenRepoService
    {
        public bool CheckValidUserKey(string apikey)
        {
            var apikeyList = new List<string>();
            apikeyList.Add("28236d8ec201df516d0f6472d516d72d");
            apikeyList.Add("38236d8ec201df516d0f6472d516d72c");
            apikeyList.Add("48236d8ec201df516d0f6472d516d72b");

            if (apikeyList.Contains(apikey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
