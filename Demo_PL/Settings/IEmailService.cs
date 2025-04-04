using Demo_Dal.Entities;

namespace Demo_PL.Settings
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
