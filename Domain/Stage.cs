using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Stage
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}