namespace GhasedakSms.Core.Dto
{
    public class SendOtpInput
    {
        public DateTime? SendDate { get; set; }
        public List<SendOtpReceptorDto> Receptors { get; set; }
        public string TemplateName { get; set; }
        public List<OtpInput> Inputs { get; set; }
        public bool Udh { get; set; }
    }

    public class OtpInput
    {
        public string Param { get; set; }
        public string Value { get; set; }
    }


}
