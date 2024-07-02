using GhasedakSms.Core.Enum;

namespace GhasedakSms.Core.Dto
{
    public class SmsStatusResponseItems
    {
        public string MessageId { get; set; }
        public string ClientReferenceId { get; set; }
        public string Message { get; set; }
        public string LineNumber { get; set; }
        public string Receptor { get; set; }
        public SendStatus Status { get; set; }
        public int Price { get; set; }
        public DateTime SendDate { get; set; }
    }

}
