namespace GhasedakSms.Core.Dto
{
    public class GetReceivedSmsQuery
    {
        public string LineNumber { get; set; }
        public bool IsRead { get; set; } = false;
    }

}
