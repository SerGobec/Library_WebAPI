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
                new Book { Id=1, Author = "J. K. Rowling", Cover = "", Title = "Harry Potter and the Philosopher's Stone", Genre = "Fantasy", Content = "Harry Potter and the Philosopher's Stone is a 1997 fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry..."},
                new Book { Id=2, Author = "Stephen King", Cover = "", Title = "It", Genre = "Horror", Content = "The novel is told through narratives alternating between two periods and is largely told in the third-person omniscient mode. It deals with themes that eventually became King staples: the power of memory, childhood trauma and its recurrent echoes in adulthood, the malevolence lurking beneath the idyllic façade of the American small town, and overcoming evil through mutual trust and sacrifice..."},
                new Book { Id=3, Author = "Robert Louis Stevenson", Cover = "", Title = "Treasure Island", Genre = "Adventure fiction", Content = "The plot is set in the mid-18th century, when an old sailor who identifies himself as The Captain starts to lodge at the rural Admiral Benbow Inn on England's Bristol Channel. He tells the innkeeper's son, Jim Hawkins, to keep a lookout for a one-legged seafaring man. A former shipmate named Black Dog confronts The Captain about a chart. They get into a violent fight, causing Black Dog to flee..."},
                new Book { Id=4, Author = "Bram Stoker", Cover = "", Title = "Dracula", Genre = "Horror", Content = "Dracula is a novel by Bram Stoker, published in 1897. As an epistolary novel, the narrative is related through letters, diary entries, and newspaper articles. It has no single protagonist, but opens with solicitor Jonathan Harker taking a business trip to stay at the castle of a Transylvanian noble, Count Dracula. Harker escapes the castle after discovering that Dracula is a vampire."},
                new Book { Id=5, Author = "Stephen King", Cover = "", Title = "The Shining", Genre = "Horror", Content = "The Shining centers on the life of Jack Torrance, a struggling writer and recovering alcoholic who accepts a position as the off-season caretaker of the historic Overlook Hotel in the Colorado Rockies. His family accompanies him on this job, including his young son Danny Torrance, who possesses the shining, an array of psychic abilities that allow Danny to see the hotel's horrific past."},
                new Book { Id=6, Author = "William Peter Blatty", Cover = "", Title = "The Exorcist", Genre = "Horror", Content = "An elderly Jesuit priest named Father Lankester Merrin is leading an archaeological dig in northern Iraq and is studying ancient relics. After discovering a small statue of the demon Pazuzu (an actual ancient Assyrian demon), a series of omens alerts him to a pending confrontation with a powerful evil, which, unknown to the reader at this point, he has battled before in an exorcism in Africa."},
                new Book { Id=12, Author = "Frank Herbert", Cover = "", Title = "Dune", Genre = "Science fiction", Content = "Duke Leto Atreides of House Atreides, ruler of the ocean planet Caladan, is assigned by the Padishah Emperor Shaddam IV to serve as fief ruler of the planet Arrakis. Although Arrakis is a harsh and inhospitable desert planet, it is of enormous importance because it is the only planetary source of melange, or the spice, a unique and incredibly valuable substance that extends human youth, vitality and lifespan. It is also through the consumption of spice that Spacing Guild Navigators are able to effect safe interstellar travel."},
                new Book { Id=7, Author = "Andy Weir", Cover = "", Title = "The Martian", Genre = "Science fiction", Content = "In the year 2035, the crew of NASA's Ares 3 mission have arrived at Acidalia Planitia for a planned month-long stay on Mars. After only six sols, an intense dust and wind storm threatens to topple their Mars Ascent Vehicle (MAV), which would trap them on the planet. During the hurried evacuation, an antenna tears loose and impales astronaut Mark Watney, a botanist and engineer, also disabling his spacesuit radio. He is flung out of sight by the wind and presumed dead. As the MAV teeters dangerously, mission commander Melissa Lewis has no choice but to take off without completing the search for Watney."},
                new Book { Id=8, Author = "George Orwell", Cover = "", Title = "Nineteen Eighty-Four", Genre = "Science fiction", Content = "In London, Winston Smith is a member of the Outer Party, working at the Ministry of Truth, where he rewrites historical records to conform to the state's ever-changing version of history. Winston revises past editions of The Times, while the original documents are destroyed after being dropped into ducts known as memory holes, which lead to an immense furnace. He secretly opposes the Party's rule and dreams of rebellion, despite knowing that he is already a thought-criminal and is likely to be caught one day."},
                new Book { Id=9, Author = "Jung Hyun-jung", Cover = "", Title = "Romance Is a Bonus", Genre = "Romantic comedy", Content = " When Cha Eun-ho was a child, Kang Dan-i saved him from an accident and was injured. Kang Dan-i had Cha Eun-ho help her while she was recuperating in hospital and later on bedrest for one year. By helping her acquire books to read from the library, Cha Eun-ho himself became interested in writing."},
                new Book { Id=10, Author = "Colleen Hoover", Cover = "", Title = "It Ends with Us", Genre = "Romance", Content = "It Ends with Us focuses on Lily Bloom, a young college graduate who moves to Boston and opens her own floral business. She develops feelings for surgeon Ryle Kincaid, who is initially reluctant toward having a serious relationship with her. As their relationship blossoms, Lily has a sudden encounter with her first love Atlas Corrigan."},
                new Book { Id=11, Author = "Dale Carnegie", Cover = "", Title = "How to Win Friends and Influence People", Genre = "Self-help", Content = "How to Win Friends and Influence People was written for a popular audience and Carnegie successfully captured the attention of his target. The book experienced mass consumption and appeared in many popular periodicals, including garnering 10 pages in the January 1937 edition of Reader's Digest."},
            });

            modelBuilder.Entity<Rating>().HasData(
            new Rating[]
            {
                new Rating { Id = 1, BookId = 1, Score = 4.36M},
                new Rating { Id = 2, BookId = 2, Score = 4.72M},
                new Rating { Id = 3, BookId = 3, Score = 3.92M},
                new Rating { Id = 4, BookId = 4, Score = 4.82M},
                new Rating { Id = 5, BookId = 5, Score = 4.21M},
                new Rating { Id = 6, BookId = 6, Score = 3.82M},
                new Rating { Id = 7, BookId = 7, Score = 4.13M},
                new Rating { Id = 8, BookId = 8, Score = 3.92M},
                new Rating { Id = 9, BookId = 9, Score = 3.3M},
                new Rating { Id = 10, BookId = 10, Score = 2.9M},
                new Rating { Id = 11, BookId = 11, Score = 5M},
            });

            modelBuilder.Entity<Review>().HasData(
            new Review[]
            {
                new Review {Id = 1, BookId = 1, Reviewer = "Mr. Awesome", Message = "My favorite book" },
                new Review {Id = 2, BookId = 1, Reviewer = "Harry", Message = "Leviosssaaaa!" },
                new Review {Id = 3, BookId = 2, Reviewer = "Mickhael J.", Message = "Wow..I am scared..." },
                new Review {Id = 4, BookId = 3, Reviewer = "Nick", Message = "Treasure Island is one of the greatest adventure novels." },
                new Review {Id = 5, BookId = 3, Reviewer = "Korben", Message = "Treasure Island was one of my favorites" },
                new Review {Id = 6, BookId = 11, Reviewer = "Serhii Pohrebets", Message = "The best book i have ever read"}
            });
        }
    }
}
