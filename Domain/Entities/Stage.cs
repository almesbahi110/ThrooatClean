using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Stage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }


        public Employee? Employee { get; set; }
    }
}