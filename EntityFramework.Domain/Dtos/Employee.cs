using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Domain.Dtos
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }
        public DateTime DOJ { get; set; }
        public int Age { get; set; }
        public string? Desc { get; set; }
        
        [ForeignKey("Id")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
