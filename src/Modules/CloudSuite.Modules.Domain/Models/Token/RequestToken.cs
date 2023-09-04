using System.ComponentModel.DataAnnotations;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Token
{
  public class RequestToken : Entity, IAggregateRoot
  {
    public int Id { get; set; }

    public Guid RequestId { get; set; }

    [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
    [MaxLength(40)]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
    [MaxLength(2)]
    public string PhoneRegion { get; set; }

    [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
    [MaxLength(13)]
    public string PhoneNumber { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Validated { get; set; }

    [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
    [MaxLength(4)]
    public string Token { get; set; }

    public RequestToken()
    {

    }

    public RequestToken(Guid requestId, string fullName, string phoneRegion, string phoneNumber, DateTime created)
    {
      RequestId = requestId;
      FullName = fullName;
      PhoneRegion = phoneRegion;
      PhoneNumber = phoneNumber;
      Created = created;
      Token = GetToken();
    }
    private string GetToken()
    {
      Random rand = new Random();
      int on = rand.Next(0, 9);
      int tw = rand.Next(0, 9);
      int tr = rand.Next(0, 9);
      int fo = rand.Next(0, 9);

      return on.ToString() + tw.ToString() + tr.ToString() + fo.ToString();
    }
  }
}