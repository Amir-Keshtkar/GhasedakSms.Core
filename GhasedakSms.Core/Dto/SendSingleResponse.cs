using GhasedakSms.Core.Enum;

namespace GhasedakSms.Core.Dto
{
    public class SendSingleResponse
    {
        public string Receptor { get; set; }
        public string LineNumber { get; set; }
        public int Cost { get; set; }
        public string MessageId { get; set; }


        //are these outputs considered necessary?
        public string Message { get; set; }
        public DateTime SendDate { get; set; }

    }

}
