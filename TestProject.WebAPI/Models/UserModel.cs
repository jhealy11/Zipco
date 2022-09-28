namespace TestProject.WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public decimal MonthlySalary { get; set; }  
        public decimal MonthlyExpenses { get; set; }
    }
}
