

namespace TestProject.WebAPI.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public UserModel User { get; set; }

    }
}
