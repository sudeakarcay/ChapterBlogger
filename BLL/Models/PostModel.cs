using BLL.DAL;

namespace BLL.Models
{
    public class PostModel
    {
        public Post Record { get; set; }
        public string BookTitle => Record.BookTitle;
        public string Content => Record.Content;
        public DateTime? CreatedAt => Record.CreatedAt;

        public bool IsPublic => Record.IsPublic;

    }
}
