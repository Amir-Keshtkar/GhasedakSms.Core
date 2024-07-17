namespace GhasedakSms.Core.Dto
{
    public class ReceivedSmsesPagingResponse
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
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
