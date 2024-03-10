using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class BookStoreBasicFunctions
    {
        public static List<Book> GetAllBooks()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books
                    .Include(b => b.Author)
                    .ToList();
            }
        }

        public static List<Book> GetAllBooksFull()
        {
            using (var db = new SE407_BookStoreContext())
            {
                var books = db.Books
                    .Include(books => books.Author)
                    .Include(books => books.Genre)
                    .ToList();
                return books;
            }
        }

        public static Book GetFullBookById(int id)
        {
            using (var db = new SE407_BookStoreContext())
            {
                var books = db.Books
                    .Include(books => books.Author)
                    .Include(books => books.Genre)
                    .Where(books => books.BookId == id)
                    .FirstOrDefault();
                return books;
            }
        }

        public static Author GetAuthorById(int id)
        {
            using (var db = new SE407_BookStoreContext())
            {
                var author = db.Authors
                .Where(author => author.AuthorId == id)
                .FirstOrDefault();
                return author;
            }
        }

        public static List<Genre> GetAllGenres()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Genres.ToList();
            }
        }

        public static Genre GetGenreById(int id)
        {
            using (var db = new SE407_BookStoreContext())
            {
                var genre = db.Genres
                .Where(genre => genre.GenreId == id)
                .FirstOrDefault();
                return genre;
            }
        }

        public static Book GetBookByTitle(string title)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books
                    .Include(b => b.Author)
                .FirstOrDefault(b => b.BookTitle == title);

            }
        }


        public static List<Author> GetAllAuthors()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Authors.ToList();
            }
        }


        public static List<Book> GetAllBooksByAuthorLastName(string lastName)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books
                    .Include(b => b.Author)
                    .Where(b => b.Author.AuthorLast == lastName)
                    .ToList();
            }
        }


        public static List<Book> ExecuteQuery(string outputType, params string[] userOption)
        {
            switch (outputType)
            {
                case "GetAllBooks":
                    return GetAllBooks();

                case "GetAllBooksByAuthorLastName":
                    if (userOption.Length == 1)
                    {
                        return GetAllBooksByAuthorLastName(userOption[0]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option for GetAllBooksByAuthorLastName.");
                        return new List<Book>();
                    }

                case "GetBookByTitle":
                    if (userOption.Length == 1)
                    {
                        return new List<Book> { GetBookByTitle(userOption[0]) };
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option for GetBookByTitle.");
                        return new List<Book>();
                    }

                default:
                    Console.WriteLine("Invalid method.");
                    return new List<Book>();
            }
        }

    }
}
