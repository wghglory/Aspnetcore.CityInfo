namespace Aspnetcore.CityInfo.Model.Services
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}
