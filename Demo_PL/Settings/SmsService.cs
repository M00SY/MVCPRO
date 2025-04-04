using Demo_Dal.Entities;
using Demo_PL.Models;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Demo_PL.Settings
{
    public class SmsService : ISmsService
    {
        private TwillioSettings _options;
        public SmsService(IOptions<TwillioSettings> options)
        {
            _options = options.Value;
        }

        public MessageResource SendSms(SMS sms)
        {
            TwilioClient.Init(_options.AccountSID, _options.AuthToken);
            var result = MessageResource.Create(
                body:sms.Body,
                to:sms.PhoneNumber,
                from:new Twilio.Types.PhoneNumber(_options.PhoneNumber)
                );

            return result;
        }
    }
}
