using LibraryAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RecommendedController : Controller
    {
        ILibraryDbService _db;

        public RecommendedController(ILibraryDbService context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
