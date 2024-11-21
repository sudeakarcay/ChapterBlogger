using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        [StringLength(200)]
        public string Genre { get; set; }

        public decimal Price { get; set; }

        public Author Author { get; set; }

        public List<Book> Books { get; set; } = new List<Book>(); //navigation

        public List<UserBook> UserBooks { get; set; } //Many-to-many
    }
}
