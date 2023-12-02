using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Department { get; set; }
        public DateTime? Birthdate { get; set; }
        public Gender? Gender { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public StateActive? EmployeeState { get; set; }
        public Employee()
        {
            EmployeeState = StateActive.Enable;

        }
    }
   
        }
    
