using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentDesktop.Core.Entities.Specific.CoinCap
{
    public class CoinCapCryptoCurrencyInfoModel
    {
        public string? Key { get; set; } //Description
        public string? Id { get; set; } //unique identifier for asset
        public int? Rank { get; set; } //rank is in ascending order - this number is directly associated with the marketcap whereas the highest marketcap receives rank 1
        public string? Symbol { get; set; } //most common symbol used to identify this asset on an exchange
        public string? Name { get; set; } //proper name for asset
        public double? Supply { get; set; } //available supply for trading
        public double? MaxSupply { get; set; } //total quantity of asset issued
        public double? MarketCapUsd { get; set; } //supply x price
        public double? VolumeUsd24Hr { get; set; } //quantity of trading volume represented in USD over the last 24 hours
        public double? PriceUsd { get; set; } //volume-weighted price based on real-time market data, translated to USD
        public double? ChangePercent24Hr { get; set; } //the direction and value change in the last 24 hours
        public double? Vwap24Hr { get; set; } //Volume Weighted Average Price in the last 24 hours

        public BaseCryptoCurrencyInfoModel ConvertToBase()
        {
            return new BaseCryptoCurrencyInfoModel { CurrencyCode = Id, CurrencyName = Name, USDValue = PriceUsd ?? 0, Rank = Rank ?? -1 };
        }
    }
}
