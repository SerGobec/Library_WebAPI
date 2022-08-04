using LibraryAPI.Models;
using LibraryAPI.RequestModels;

namespace LibraryAPI.Interfaces
{
    public interface ILibraryDbService
    {
        public List<BookDTO> GetAllBooks(string? order);
        public List<BookDTO> GetRecomended(string? genre);
        public BookDetailsDTO GetBookDetails(long? id);
        public bool CheckPassword(string password);
        public Task<bool> DeleteBookAsync(long id, string password);
        public Task<bool> CreateBook(BookRequestModel model);
        public Task<bool> CreateReview(long id, ReviewRequestModel model);
        public Task<bool> CreateScore(long id, decimal score);
        public bool ContainBookById(long id);
    }
}
