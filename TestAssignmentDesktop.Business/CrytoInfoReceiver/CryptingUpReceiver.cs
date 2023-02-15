using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignmentDesktop.Business.CrytoInfoReceiver.Interfaces;
using TestAssignmentDesktop.Business.HttpUtils;
using TestAssignmentDesktop.Core.Entities;
using TestAssignmentDesktop.Core.Entities.Specific.CryptingUp;

namespace TestAssignmentDesktop.Business.CrytoInfoReceiver
{
    public class CryptingUpReceiver : ICryptoInfoReceiver
    {
        private HttpUtil _httpUtil;
        private const string baseUrl = "https://cryptingup.com/api/assets";

        public CryptingUpReceiver()
        {
            _httpUtil = HttpUtil.GetInstance();
        }

        public async Task<List<BaseCryptoCurrencyInfoModel>> ReceiveAllAssets()
        {
            var response = await _httpUtil.GetAsync(baseUrl);
            var result = new List<BaseCryptoCurrencyInfoModel>();

            if (!_httpUtil.IsSuccessfulStatusCode(response))
            {
                //show error message

                return null;
            }
            var specificList = JsonConvert.DeserializeObject<CryptingUpResponse>(response.Content.ReadAsStringAsync().Result).Assets;

            specificList.ForEach(x => result.Add(x.ConvertToBase()));

            return result;
        }
    }
}
