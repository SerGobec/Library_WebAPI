using LibraryAPI.Models;

namespace LibraryAPI.Interfaces
{
    public interface ILibraryDbService
    {
        public List<BookDTO> GetAllBooks(string? order);
    }
}
