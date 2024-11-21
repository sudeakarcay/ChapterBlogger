using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace BLL.DAL
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [StringLength(200)]
        public string BookTitle { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool IsPublic { get; set; }

        public User User { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}