namespace CloudSuite.Modules.Application.Services.Contracts.Token
{
  public interface ITwilioSmsServices
  {
    Task SendSMS(string telefone, string msg);
  }
}