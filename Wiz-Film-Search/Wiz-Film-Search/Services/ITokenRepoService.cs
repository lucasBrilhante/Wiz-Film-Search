using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiz_Film_Search.Services
{
    public interface ITokenRepoService
    {
        bool CheckValidUserKey(string apikey);
    }
}
