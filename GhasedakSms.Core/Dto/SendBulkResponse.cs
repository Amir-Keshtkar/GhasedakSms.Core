using GhasedakSms.Core.Enum;

namespace GhasedakSms.Core.Dto
{
    public class SendBulkResponse
    {
        public int Cost { get; set; }
        public string LineNumber { get; set; }
        public List<string> Receptors { get; set; }
        public List<string> MessageIds { get; set; }


        //are these outputs considered necessary?
        public string Message { get; set; }
        public SendStatus Status { get; set; }
        public DateTime SendDate { get; set; }
        public string StatusDescription { get; set; }
    }

}
