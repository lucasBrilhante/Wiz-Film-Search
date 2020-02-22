using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Wiz_Film_Search.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Get()
        {
            return Ok();
        }
    }
}