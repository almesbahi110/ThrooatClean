using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.Requst
{
    public class StageRequstDTo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }


        public Employee? Employee { get; set; }
        public (bool, String) ValidateStage()
        {

            if (string.IsNullOrEmpty(Name))
                return (false, "يجب ان تكتب اسم المرحله");

            if (string.IsNullOrEmpty(title))
                return (false, "يجب كتابه عنوان المرحله");
            if (EmployeeId == 0)
                return (false, "يجب كتابه رقم الموظف المرتبط بهذه المرحله");
            if (string.IsNullOrEmpty(description))
                return (false, "يجب كتابه وصف هذه المرحله");

            return (true, "تم اضافه المرحله بنجاح");
        }
    }
}
