namespace GhasedakSms.Core.Dto
{
    public class ReceivedSmsesResponse
    {
        public IEnumerable<ReceivedSms> Items { get; set; }

        public class ReceivedSms
        {
            public int Id { get; set; }
            public string Message { get; set; }
            public string Sender { get; set; }
            public string LineNumber { get; set; }
            public DateTime? ReceiveDate { get; set; }
        }
    }

}
