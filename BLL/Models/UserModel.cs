using BLL.DAL;

namespace BLL.Models
{
    public class UserModel
    {
        public User Record { get; set; }
        public string Name => Record.Name;
        public string Surname => Record.Surname;
        public string IsActive => Record.IsActive ? "Active" : "Inactive";
        public string Role => Record.Role?.Name;
    }
}
