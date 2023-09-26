namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface ITwilioSmsServices
    {
        Task SendSMS(string telefone, string msg);
    }
}