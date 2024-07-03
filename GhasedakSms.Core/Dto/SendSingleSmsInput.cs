namespace GhasedakSms.Core.Dto
{
    public class SendSingleSmsInput
    {
        public DateTime? SendDate { get; set; }
        public string LineNumber { get; set; }
        public string Receptor { get; set; }
        public string Message { get; set; }
        public string ClientReferenceId { get; set; }
        public bool Udh { get; set; }
    }

}
