using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using LibraryAPI.RequestModels;
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
        [Route("{id?}")]
        public JsonResult GetBookDetail(int id)
        {
            if (id < 0)
            {
                HttpContext.Response.StatusCode = 400;
                return Json("id can not be less then 0");
            }
            BookDetailsDTO bookDetailsDTO = _db.GetBookDetails(id);
            if (bookDetailsDTO == null)
            {
                HttpContext.Response.StatusCode = 404;
                return Json(null);
            } else
            {
                return Json(bookDetailsDTO);
            }
        }

        [HttpDelete]
        [Route("{id?}/{secret?}")]
        public async Task<IActionResult> DeleteBook(long id, string secret)
        {
            if (!_db.CheckPassword(secret)) return StatusCode(405);
            bool result = await _db.DeleteBookAsync(id, secret);
            if (!result) return StatusCode(404);
            return StatusCode(202);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveBook([FromBody]BookRequestModel model)
        {
            if (!TryValidateModel(model)) return StatusCode(400);
            bool result = await _db.CreateBook(model);
            if(result) return StatusCode(202);
            return StatusCode(400);
        }

        [HttpPut]
        [Route("{id}/review")]
        public async Task<IActionResult> SaveReview(long id, [FromBody] ReviewRequestModel model)
        {
            if (!TryValidateModel(model)) return StatusCode(400);
            bool result = await _db.CreateReview(id, model);
            if (result) return StatusCode(202);
            return StatusCode(400);
        }

        [HttpPut]
        [Route("{id}/rate")]
        public async Task<IActionResult> SaveScore(long id, [FromBody] ScoreRequestModel score)
        {
            /*if (!TryValidateModel(model)) return StatusCode(400);
            bool result = await _db.CreateReview(id, model);
            if (result) return StatusCode(202);
            return StatusCode(400);*/
            decimal scoreDec =  decimal.Parse(score.Score);
            return Content(scoreDec + "");
        }
    }
}
