using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        ILibraryDbService _db;

        public BooksController(ILibraryDbService context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("")]
        public JsonResult Index(string? order)
        {
            return Json(_db.GetAllBooks(order));
        }

        [HttpGet]
        [Route("num/{id?}")]
        public IActionResult Num(int id)
        {
            return Content(id + "");
        }
    }
}
