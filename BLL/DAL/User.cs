using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public bool IsActive { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>(); //One to many

        public List<UserBook> UserBooks { get; set; } //Many-to-many

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        [Required]
        [StringLength(12)]
        public string Password { get; set; }

    }
}
