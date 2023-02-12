using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignmentDesktop.Core.Entities;

namespace TestAssignmentDesktop.Business.CrytoInfoReceiver.Interfaces
{
    public interface ICryptoInfoReceiver
    {
        public Task<List<BaseCryptoCurrencyInfoModel>> ReceiveAllAssets();
    }
}
