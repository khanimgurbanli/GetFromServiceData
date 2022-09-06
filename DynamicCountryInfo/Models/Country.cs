using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCountryInfo.Models
{
    public class Country
    {
        public Country() { }
        public Country(string code, string name, string phone, string iSO, string capital, string currency, string continentId) :this()
        {
            Code = code;
            Name = name;
            Phone = phone;
            ISO = iSO;
            Capital = capital;
            Currency = currency;
            ContinentId = continentId;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ISO { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public string ContinentId { get; set; }
    }
}
