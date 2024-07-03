namespace GhasedakSms.Core.Dto
{
    public class GetReceivedSmsInput
    {
        public string LineNumber { get; set; }
        public bool IsRead { get; set; } = false;
    }

}
