using System.Threading.Tasks;

namespace Store.BusinessLogic.Providers.Interfaces
{
    public interface IEmailProvider
    {
        Task SendMailAsync(string recipientMail, string mailSubject, string mailBody);
    }
}
