using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignmentDesktop.Core.Entities;

namespace TestAssignmentDesktop.WPF.Models
{
    public class CryptoCurrencyModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double USDValue { get; set; }
        public int Rank { get; set; }

        public double? Volume { get; set; }
        public double? PriceChange { get; set; }

        public static CryptoCurrencyModel ConvertFromBase(BaseCryptoCurrencyInfoModel item)
        {
            return new CryptoCurrencyModel 
            { 
                Code =  item.CurrencyCode,
                Name = item.CurrencyName, 
                USDValue = item.USDValue,
                Rank = item.Rank,
                Volume = item.Volume,
                PriceChange = item.PriceChange,
            };
        }
    }
}
