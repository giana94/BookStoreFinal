using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public int GenreId { get; set; }
        public string GenreType { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
