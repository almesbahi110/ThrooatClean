using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Process
    {
        [Key]
        public int? ProcessId { get; set; }
        public string? ProcessName { get; set; }
        [EnumDataType(typeof(StateActive))]
        public StateActive? ProcessState { get; set; }
        public Process()
        {
            this.ProcessState = StateActive.Enable;
        }
        public string? Instructions { get; set; }
    }
}
