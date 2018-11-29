using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CDorganizer.Models;

namespace CDorganizer.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}
