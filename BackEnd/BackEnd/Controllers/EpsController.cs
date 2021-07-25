using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    public class EpsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
