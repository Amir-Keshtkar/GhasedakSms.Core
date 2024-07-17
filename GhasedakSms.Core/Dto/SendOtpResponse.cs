using GhasedakSms.Core.Enum;

namespace GhasedakSms.Core.Dto
{
    public class SendOtpResponse
    {
        public string LineNumber { get; set; }
        public string MessageBody { get; set; }
        public List<Data> Items { get; set; }
        public int Cost { get; set; }


        public class Data
        {
            public string Receptor { get; set; }
            public int Cost { get; set; }
            public string MessageId { get; set; }
            public DateTime SendDate { get; set; }
        }
    }

}
