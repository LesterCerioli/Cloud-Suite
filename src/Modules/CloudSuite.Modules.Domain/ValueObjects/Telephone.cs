using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.ValueObjects
{
    public class Telephone : ValueObject
    {

        public string? RegionTelephone { get; private set; }

        public string? TelephoneNumber { get; private set; }


        public static bool ValidateTelephone(string telephoneNumber)
        {
            string shortenNum = Regex.Replace(telephoneNumber, @"[^0-9a-zA-Z]+", "");

            if (telephoneNumber.Length == 13)
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
