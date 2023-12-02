using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProcessRequest
    {
        [Key]
        public int? ProcessRequestId { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        [EnumDataType(typeof(StateActive))]
        public StateProcess? ProcessRequestState { get; set; }
        public ProcessRequest()
        {
            this.ProcessRequestState = StateProcess.UnComplate;
        }

        public string? Note { get; set; }
        public string? RequestDescraption { get; set; }

        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [ForeignKey("ProcessStagesId")]
        public int? ProcessStagesId { get; set; }

        public ProcessStages? ProcessStages { get; set; }
    }
}
