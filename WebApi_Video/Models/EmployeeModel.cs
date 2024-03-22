using System.ComponentModel.DataAnnotations;
using WebApi_Video.Enums;

namespace WebApi_Video.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; }
        public ShiftEnum Shift { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime UpdateDate { get; set; } = DateTime.Now.ToLocalTime();
    }
}
