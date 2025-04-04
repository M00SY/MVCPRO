using Demo_Dal.Entities;
using Twilio.Rest.Api.V2010.Account;

namespace Demo_PL.Settings
{
    public interface ISmsService
    {
        MessageResource SendSms(SMS sms);
    }
}
