using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class UserBook
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime? DateRead { get; set; }

        public bool IsFavorite { get; set; }
    }
}