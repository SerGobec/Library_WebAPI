using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().HasData(
            new Book[]
            {
                new Book { Id=1, Author = "J. K. Rowling", Cover = "Red", Title = "Harry Potter and the Philosopher's Stone", Genre = "Fantasy", Content = "Harry Potter and the Philosopher's Stone is a 1997 fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry..."},
                new Book { Id=2, Author = "Stephen King", Cover = "Dark", Title = "It", Genre = "Horror", Content = "The novel is told through narratives alternating between two periods and is largely told in the third-person omniscient mode. It deals with themes that eventually became King staples: the power of memory, childhood trauma and its recurrent echoes in adulthood, the malevolence lurking beneath the idyllic façade of the American small town, and overcoming evil through mutual trust and sacrifice..."},
                new Book { Id=3, Author = "Robert Louis Stevenson", Cover = "Red", Title = "Treasure Island", Genre = "Adventure fiction", Content = "The plot is set in the mid-18th century, when an old sailor who identifies himself as The Captain starts to lodge at the rural Admiral Benbow Inn on England's Bristol Channel. He tells the innkeeper's son, Jim Hawkins, to keep a lookout for a one-legged seafaring man. A former shipmate named Black Dog confronts The Captain about a chart. They get into a violent fight, causing Black Dog to flee..."}
            });

            modelBuilder.Entity<Rating>().HasData(
            new Rating[]
            {
                new Rating { Id = 1, BookId = 1, Score = 4.36M},
                new Rating { Id = 2, BookId = 2, Score = 4.72M},
                new Rating { Id = 3, BookId = 3, Score = 3.92M},
            });

            modelBuilder.Entity<Review>().HasData(
            new Review[]
            {
                new Review {Id = 1, BookId = 1, Reviewer = "Mr. Awesome", Message = "My favorite book" },
                new Review {Id = 2, BookId = 1, Reviewer = "Harry", Message = "Leviosssaaaa!" },
                new Review {Id = 3, BookId = 2, Reviewer = "Mickhael J.", Message = "Wow..I am scared..." },
                new Review {Id = 4, BookId = 3, Reviewer = "Nick", Message = "Treasure Island is one of the greatest adventure novels." },
                new Review {Id = 5, BookId = 3, Reviewer = "Korben", Message = "Treasure Island was one of my favorites" },
            });
        }
    }
}
