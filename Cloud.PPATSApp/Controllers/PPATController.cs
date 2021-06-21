using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Controllers
{
    public class PPATController : Controller
    {
        public IActionResult Index()
        {
            return View("_PPAT");
        }
    }
}
