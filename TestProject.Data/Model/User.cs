using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Data.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlySalary { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyExpenses { get; set; }

        Account Account { get; set; }
    }
}
