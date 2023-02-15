using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentDesktop.Core.Entities.Specific.CryptingUp
{
    public class CryptingUpCryptoCurrencyInfoModel : ICryptoInfoModel
    {
        public string? Asset_id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public double? Volume_24h { get; set; }
        public double? Change_1h { get; set; }
        public double? Change_24h { get; set; }
        public double? Change_7d { get; set; }
        public string? Status { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

        public BaseCryptoCurrencyInfoModel ConvertToBase()
        {
            return new BaseCryptoCurrencyInfoModel { CurrencyCode = Asset_id, CurrencyName = Name, USDValue = Price ?? 0};
        }
    }
}
