using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentDesktop.Core.Entities
{
    public class BaseCryptoCurrencyInfoModel
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public double USDValue { get; set; }
        public int Rank { get; set; }

        public override string ToString()
        {
            return $"Code = {CurrencyCode}, Name = {CurrencyName}, USD value = {USDValue}, Rank = {Rank}";
        }
    }
}
