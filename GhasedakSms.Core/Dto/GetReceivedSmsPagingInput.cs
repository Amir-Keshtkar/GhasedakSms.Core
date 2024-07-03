namespace GhasedakSms.Core.Dto
{
    public class GetReceivedSmsPagingInput
    {
        public string LineNumber { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-90);
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }

}
