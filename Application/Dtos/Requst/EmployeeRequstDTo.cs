using Domain.Enum;
namespace Application.Dtos.Requst
{
    public class EmployeeRequstDTo
    {
        public int EmployeeId { get; set; }

        public string? Department { get; set; }
        public DateTime? Birthdate { get; set; }
        public Gender? Gender { get; set; }
        public string? EmployeeName { get; set; }
        public string? PhoneNumber { get; set; }
        public StateActive? EmployeeState { get; set; }
        public (int, String) ValidteEmployee()
        {
            if (String.IsNullOrEmpty(EmployeeName))
                return (0, "يجب ان تكتب اسم الموظف");
            if (String.IsNullOrEmpty(PhoneNumber))
                return (0, "يجب ان تكتب رقم الموظف");
            if (String.IsNullOrEmpty(Department))
                return (0, "يجب ان تكتب قسم الموظف");
            return (1, "تم اضافه الموظف بنجاح ");
        }
    }
}
