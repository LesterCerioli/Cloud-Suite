using NetDevPack.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CloudSuite.Modules.Core.Domain.ValueObjects
{
    public class Telephone : ValueObject
    {
        [Required(ErrorMessage = "O preenchimento do telefone é obrigatório")]
        [MinLength(9)]
        public string? TelephoneNumber { get; private set; }

        [Required(ErrorMessage = "O preenchimento do telefone é obrigatório")]
        [MinLength(2)]
        [MaxLength(2)]
        public string? TelephoneRegion { get; private set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public static bool ValidateTelephone(string telephoneNumber)
        {
            string shortenNum = Regex.Replace(telephoneNumber, @"[^0-9a-zA-Z]+", "");

            if (telephoneNumber.Length == 9)
            {
                Console.WriteLine("O número de telefone é válido");
                return true;
            }

            else
            {
                Console.Write("O número de telefone é inválido");
                return false;
            }
        }
        
    }
}