using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentDesktop.Core.Entities.Specific.CryptingUp
{
    public class CryptingUpResponse
    {
        public List<CryptingUpCryptoCurrencyInfoModel> Assets { get; set; }
        public int Next { get; set; }
    }
}
