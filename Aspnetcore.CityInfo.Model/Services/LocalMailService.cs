using System.Diagnostics;

namespace Aspnetcore.CityInfo.Model.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo;
        private readonly string _mailFrom;

        public LocalMailService(string mailFrom, string mailTo)
        {
            _mailFrom = mailFrom;
            _mailTo = mailTo;
        }

        public void Send(string subject, string message)
        {
            // send mail - output to debug window
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}