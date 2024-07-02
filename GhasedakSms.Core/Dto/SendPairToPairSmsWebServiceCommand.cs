namespace GhasedakSms.Core.Dto
{
    public class SendPairToPairSmsWebServiceCommand
    {
        public List<SendPairToPairSmsWebServiceDto> Items { get; set; }
        public bool Udh { get; set; }
    }
    public class SendPairToPairSmsWebServiceDto
    {
        public string LineNumber { get; set; }
        public required string Receptor { get; set; }
        public required string Message { get; set; }
        public string ClientReferenceId { get; set; }
        public DateTime SendDate { get; set; } = DateTime.Now;
    }


}
