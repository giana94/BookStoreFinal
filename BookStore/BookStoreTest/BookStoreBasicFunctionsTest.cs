using BookStore;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace BookStoreTest
{
    public class BookStoreBasicFunctionsTest
    {
        [Fact]
        public void GetAllBooksTest()
        {
            var result = BookStoreBasicFunctions.GetAllBooks();
            Assert.NotNull(result);
            Assert.True(result.Count == 4);

        }

        [Fact]
        public void GetAllMoviesByDirectorLastNameTest()
        {
            var result = BookStoreBasicFunctions.GetAllBooksByAuthorLastName("Polo");

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
            Assert.True(result.TrueForAll(b => b.Author.AuthorLast == "Polo"));
        }

        [Fact]
        public void GetBooksByTitleTest()
        {
            var result = BookStoreBasicFunctions.GetBookByTitle("The Travels of Marco Polo");
            Assert.NotNull(result);
            Assert.True(result.BookTitle == "The Travels of Marco Polo ");
        }

    }
}

      