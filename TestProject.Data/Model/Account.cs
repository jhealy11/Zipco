
using System.ComponentModel.DataAnnotations;

namespace TestProject.Data.Model
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
