using FleetManager.ExternalServices.GroupwareMailService;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;

namespace FleetManager.ExternalServices.Services.Mail
{
    public interface IMailService
    {
        Task<bool> SendMailAsync(string subject, string body, string[] toRecipients, string[] ccRecipients = null, Attachement[] attachements = null);
    }

    public class MailServiceOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TestMailReceiver { get; set; }
        public string ClientViaUrl { get; set; }
        public string ClientUrl { get; set; }
        public string HeaderKey { get; set; }
        public string HeaderValue { get; set; }
        public string DnsEndpointIdentity { get; set; }
    }

    public class Attachement
    {
        public byte[] Contents { get; set; }
        public string Filename { get; set; }
    }

    public class MailService : IMailService
    {
        private readonly MailServiceOptions _options;

        public MailService(MailServiceOptions options)
        {
            _options = options;
        }

        private ConnectionInfo BuildConnectionInfo()
        {
            var credentials = new Credentials
            {
                UserName = _options.Username,
                Password = _options.Password
            };

            return new ConnectionInfo { Credentials = credentials };
        }

        private Task SendMailAsync(ConnectionInfo connectionInfo, SendMailInfo sendMailInfo)
        {
            var binding = MailServiceClient.EndpointConfiguration.CustomBinding_IMailService;
            var endpoint = GetEndpointAddress();
            var mailService = new MailServiceClient(binding, endpoint);
            mailService.ChannelFactory.Endpoint.EndpointBehaviors.Add(new ClientViaBehavior(new Uri(_options.ClientViaUrl)));
            return mailService.SendMailAsync(connectionInfo, sendMailInfo);
        }

        public async Task<bool> SendMailAsync(string subject, string body, string[] toRecipients, string[] ccRecipients = null, Attachement[] attachements = null)
        {
            var connectionInfo = BuildConnectionInfo();

            var sendMailInfo = new SendMailInfo
            {
                Subject = subject,
                Body = $"<html>{body}</html>",
                ToRecipients = toRecipients,
                CCRecipients = ccRecipients
            };

            if(attachements?.Any() ?? false)
            {
                sendMailInfo.Attachments = new AttachmentInfo[attachements.Count()];
                for (int i = 0; i < attachements.Count(); i++)
                    sendMailInfo.Attachments[i] = new AttachmentInfo { Name = attachements[i].Filename, Bytes = attachements[i].Contents };
            }

            try
            {
                await SendMailAsync(connectionInfo, sendMailInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private EndpointAddress GetEndpointAddress()
        {

            return new EndpointAddress(
                new Uri(_options.ClientUrl),
                new DnsEndpointIdentity(_options.DnsEndpointIdentity)
                , AddressHeader.CreateAddressHeader(_options.HeaderKey, "", _options.HeaderValue)
                );
        }
    }

    public class ClientViaBehavior : IEndpointBehavior
    {
        private readonly Uri _uri;

        public ClientViaBehavior(Uri uri)
        {
            _uri = uri;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            if (clientRuntime == null)
                throw new ArgumentNullException(nameof(clientRuntime));
            clientRuntime.Via = _uri;
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            throw new NotImplementedException();
        }

        void IEndpointBehavior.Validate(ServiceEndpoint serviceEndpoint)
        {
        }
    }
}
