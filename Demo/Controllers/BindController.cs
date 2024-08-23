using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BindController : Controller
    {
        // Bind Premitive Type
        public IActionResult TestPremitive(int id, string name)
        {
            return Content($"Name: {name}, Id: {id}");
        }


        // Binding Collection
        // Bind/testdict?name=ali&phones[ahmed]=123&phones[mohamed]=456
        public IActionResult TestDict(Dictionary<string, int> phones, string name)
        {
            return Content($"{phones.Keys}::{phones.Values}::{name}");
        }


        // Bind on complex type
        public IActionResult TestComplex([Bind(include: "Id,Name")] Department department, string name)
        {
            return Content($"");
        }
    }
}
