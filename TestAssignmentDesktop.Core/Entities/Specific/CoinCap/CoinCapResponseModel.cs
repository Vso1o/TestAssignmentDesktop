using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentDesktop.Core.Entities.Specific.CoinCap
{
    public class CoinCapResponseModel
    {
        public List<CoinCapCryptoCurrencyInfoModel> Data { get; set; }
        public object timestamp { get; set; }
    }
}
