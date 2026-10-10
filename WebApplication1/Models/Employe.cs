
namespace WebApplication1.Models
{
    public class Employe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Designation { get; set; } = string.Empty;
    }
}
