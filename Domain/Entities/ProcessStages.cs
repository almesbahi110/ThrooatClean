using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProcessStages
    {
        [Key]
        public int? ProcessStagesId { get; set; }
        public int? ProcessId { get; set; }
        [ForeignKey("ProcessId")]
        public Process? Process { get; set; }
        public int? StageId { get; set; }
        [ForeignKey("StageId")]
        public Stage? Stage { get; set; }
        public int? Order { get; set; }
        public int? Next { get; set; }
    }
}
