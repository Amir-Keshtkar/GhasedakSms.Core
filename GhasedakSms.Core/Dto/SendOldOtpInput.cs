namespace GhasedakSms.Core.Dto
{
    public class SendOldOtpInput
    {
        public DateTime? SendDate { get; set; }
        public List<SendOtpReceptorDto> Receptors { get; set; }
        public string TemplateName { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Param3 { get; set; }
        public string Param4 { get; set; }
        public string Param5 { get; set; }
        public string Param6 { get; set; }
        public string Param7 { get; set; }
        public string Param8 { get; set; }
        public string Param9 { get; set; }
        public string Param10 { get; set; }
        public bool IsVoice { get; set; } = false;
        public bool Udh { get; set; }
    }
    public class SendOtpReceptorDto
    {
        public string Mobile { get; set; }
        public string ClientReferenceId { get; set; }
    }

}
