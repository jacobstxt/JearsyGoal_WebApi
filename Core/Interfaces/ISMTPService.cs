

using Core.SMTP;

namespace Core.Interfaces
{
    public interface ISMTPService
    {
        Task<bool> SendEmailAsync(MessageModel message);
    }
}
