namespace Application.Dtos.Requst
{
    public class ProcessStagesRequstDTo
    {
        public int? ProcessStagesId { get; set; }

        public int? ProcessId { get; set; }
        public int? StageId { get; set; }

        public int? Order { get; set; }
        public int? Next { get; set; }
        public (bool, String) ValidteProcessStages()
        {
            if (StageId == null || StageId == 0)
                return (false, "يجب ان تكتب رقم المرحله ");
            if (ProcessId == null || ProcessId == 0)
                return (false, "يجب ان تكتب رقم العملية ");
            if (Next == null || Next == 0)
                return (false, "يجب ان تكتب رقم التالي ");
            if (Order == null || Order == 0)
                return (false, "يجب ان تكتب الترتيب ");
            return (true, "تم اضافه طلب العملية بنجاح ");
        }
    }
}
