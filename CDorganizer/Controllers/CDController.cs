using Microsoft.AspNetCore.Mvc;
using CDorganizer.Models;
using System.Collections.Generic;

namespace CDorganizer.Controllers
{
  public class CDController : Controller
  {

    [HttpGet("/categories/{categoryId}/cd/new")]
    public ActionResult New(int categoryId)
    {
       Category category = Category.Find(categoryId);
       return View(category);
    }

    [HttpGet("/categories/{categoryId}/cd/{cdId}")]
    public ActionResult Show(int categoryId, int cdId)
    {
      CD cd = CD.Find(cdId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      model.Add("cd", cd);
      model.Add("category", category);
      return View(model);
    }

    [HttpPost("/cd/delete")]
    public ActionResult DeleteAll()
    {
      CD.ClearAll();
      return View();
    }

  }
}