using System.Threading.Tasks;

namespace FleetManager.ExternalServices.Services.Mail
{
    public class ForceRecipientMailServiceDecorator : IMailService
    {
        private readonly string recipient;
        private readonly IMailService decoratee;

        public ForceRecipientMailServiceDecorator(string recipient, IMailService decoratee)
        {
            this.recipient = recipient;
            this.decoratee = decoratee;
        }

        public Task<bool> SendMailAsync(string subject, string body, string[] toRecipients, string[] ccRecipients = null, Attachement[] attachements = null)
        {
            return decoratee.SendMailAsync(subject, body, new[] { recipient }, null, attachements);

        }
    }
}
