using System.ComponentModel;

namespace GhasedakSms.Core.Enum
{
    public enum SendStatus
    {
        [Description("در انتظار تایید")] ToBeConfirmed = 0,
        [Description("رد شده")] Rejected = 1,
        [Description("در حال ارسال")] ToBeSent = 2,
        [Description("در صف ارسال")] Sending = 3,
        [Description("ارسال شده")] Sent = 4,//
        [Description("حالت خطایابی")] DebugMode = 5,
        [Description("ناموفق")] InternalFailed = 6,
        [Description("لغو شده")] Canceled = 7,
        [Description("بلک لیست")] InternalBlackListed = 8,
        [Description("متوفق شده")] Paused = 9,
        //if SmsStatus==Sent:
        [Description("ارسال به سرویس دهنده")] SentToProvider = 10,
        [Description("به سرویس دهنده رسیده است")] DeliveredToProvider = 11,
        [Description("بلک لیست")] BlackListed = 12,
        [Description("به مقصد نرسیده")] NotDelivered = 13,
        [Description("تحویل داده شده")] Delivered = 14,
        [Description("فیلتر شده")] Blocked = 15,
        [Description("ناموفق")] Failed = 16,
        [Description("درحال پردازش ")] Processing = 17,

    }

}
