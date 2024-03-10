using BookStore;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Helpers
{
    public class DropDownFormatter
    {
        public static SelectList FormatAuthors()
        {
            return new SelectList(BookStoreBasicFunctions.GetAllAuthors()
                .OrderBy(a => a.AuthorLast)
                .ToDictionary(a => a.AuthorId, a => a.AuthorLast + ", " + a.AuthorFirst), "Key", "Value");
        }

        public static SelectList FormatGenres()
        {
            return new SelectList(BookStoreBasicFunctions.GetAllGenres()
                .OrderBy(g => g.GenreType)
                .ToDictionary(g => g.GenreId, g => g.GenreType), "Key", "Value");
        }
    }
}
