using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using LibraryAPI.RequestModels;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
        public IActionResult GetBookDetail(int id)
        {
            if (id < 0)
            {
                return StatusCode(400, "id can not be less then 0");
            }
            BookDetailsDTO bookDetailsDTO = _db.GetBookDetails(id);
            if (bookDetailsDTO == null)
            {
                return StatusCode(404, "Book with this id not found.");
            } else
            {
                return Json(bookDetailsDTO);
            }
        }

        [HttpDelete]
        [Route("{id?}/{secret?}")]
        public async Task<IActionResult> DeleteBook(long id, string secret)
        {
            if (!_db.CheckPassword(secret)) return StatusCode(405, "Wrong password");
            bool result = await _db.DeleteBookAsync(id, secret);
            if (!result) return StatusCode(404, "Book not found.");
            return StatusCode(202, "Successfuly deleted");
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveBook([FromBody]BookRequestModel model)
        {
            if (!TryValidateModel(model)) return StatusCode(400, "Invalid model");
            bool result = await _db.CreateBook(model);
            if(result) return StatusCode(202, "Succesfully saved!");
            return StatusCode(400, "Save failed.");
        }

        [HttpPut]
        [Route("{id}/review")]
        public async Task<IActionResult> SaveReview(long id, [FromBody] ReviewRequestModel model)
        {
            if (!TryValidateModel(model)) return StatusCode(400, "Invalid model");
            bool result = await _db.CreateReview(id, model);
            if (result) return StatusCode(202, "Succesfully saved!");
            return StatusCode(400, "Save failed.");
        }

        [HttpPut]
        [Route("{id}/rate")]
        public async Task<IActionResult> SaveScore(long id, [FromBody] ScoreRequestModel score)
        {
            try
            {
                if(!_db.ContainBookById(id)) return StatusCode(404, "Can`t find book with this id");
                CultureInfo culture = new CultureInfo("en-US");
                decimal scoreDec = Convert.ToDecimal(score.Score, culture);
                if(scoreDec < 1 || scoreDec > 5) return StatusCode(400, "Score must be between 1 and 5");
                bool result = await _db.CreateScore(id, scoreDec);
                if (result)
                {
                    return StatusCode(202, "Score seccessfully created or updated.");
                }
                else return StatusCode(400);
            }
            catch
            {
                return StatusCode(400, "Can`t convert score to decimal. Wrong value");
            }
        }
    }
}
