using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CDorganizer.Models;

namespace CDorganizer.Controllers
{
  public class CategoriesController : Controller
  {

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      List<Category> allCategories = Category.GetAll();
      return View("Index", allCategories);
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<CD> categoryCD = selectedCategory.GetItems();
      model.Add("category", selectedCategory);
      model.Add("cd", categoryCD);
      return View(model);
    }

    // This one creates new CD within a given Category, not new Categories:
    [HttpPost("/categories/{categoryId}/cd")]
    public ActionResult Create(int categoryId, string cdName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      CD newCD = new CD(cdName);
      foundCategory.AddItem(newCD);
      List<CD> categoryCD = foundCategory.GetItems();
      model.Add("cd", categoryCD);
      model.Add("category", foundCategory);
      return View("Show", model);
    }

  }
}