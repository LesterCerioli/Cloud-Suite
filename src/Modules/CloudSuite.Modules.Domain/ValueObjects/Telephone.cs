using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace CloudSuite.Modules.Domain.ValueObjects
{
    public class Telephone : ValueObject
    {
        public string? TelephoneRegion { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MinLength(10)]
        public string TelephoneNumber { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public static bool ValidateTelephone(string telephone)
        {
            string shortenNum = Regex.Replace(telephone, @"[^0-9a-zA-Z]+", "");

            if (telephone.Length == 11)
            {
                Console.WriteLine("The phone number is valid");
                return true;
            }
            else
            {
                Console.WriteLine("The phone number is invalid");
                return false;
            }
        }

    }
}