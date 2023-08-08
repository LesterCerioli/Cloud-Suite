using NetDevPack.Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.ValueObjects
{
    public class ZipCode : ValueObject
    {
        private const string ZipCodeRegexPattern = @"^\d{5}-\d{3}$";

        public string? ZipCodeNumber { get; set; }

        public ZipCode(string zipCodeNumber)
        {
            if (string.IsNullOrWhiteSpace(zipCodeNumber))
                throw new ArgumentException("O valor do CEP não pode ser nulo ou vazio.", nameof(zipCodeNumber));

            if (!Regex.IsMatch(zipCodeNumber, ZipCodeRegexPattern))
                throw new ArgumentException("Formato inválido de CEP. Use o formato 12345-678.", nameof(value));

            // Remover os hífens para verificar se é um número válido
            string numericValue = new string(zipCodeNumber.Where(char.IsDigit).ToArray());

            if (numericValue.Length != 8)
                throw new ArgumentException("CEP inválido. Deve conter exatamente 8 dígitos numéricos.", nameof(zipCodeNumber));

            ZipCodeNumber = zipCodeNumber;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
