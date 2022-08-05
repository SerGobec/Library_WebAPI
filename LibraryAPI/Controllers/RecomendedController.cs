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

        [HttpGet]
        [Route("")]
        public JsonResult Recomended(string? genre)
        {
            return Json(_db.GetRecomended(genre));
        }
    }
}
