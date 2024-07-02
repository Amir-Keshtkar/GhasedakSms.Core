namespace GhasedakSms.Core.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = false;
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
    public class ResponseDto<T> : ResponseDto
    {
        public T Data { get; set; }
    }

}
