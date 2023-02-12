using TestAssignmentDesktop.Business.CrytoInfoReceiver.Interfaces;
using TestAssignmentDesktop.Core.Entities;
using Newtonsoft.Json;
using TestAssignmentDesktop.Business.HttpUtils;
using TestAssignmentDesktop.Core.Entities.Specific.CoinCap;

namespace TestAssignmentDesktop.Business.CrytoInfoReceiver
{
    public class CoinCapReceiver : ICryptoInfoReceiver
    {
        private HttpUtil _httpUtil;
        private const string baseUrl = "https://api.coincap.io/v2/assets";

        public CoinCapReceiver()
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
            //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            var specificList = JsonConvert.DeserializeObject<CoinCapResponseModel>(response.Content.ReadAsStringAsync().Result).Data;

            specificList.ForEach(x => result.Add(x.ConvertToBase()));

            return result;
        }
    }
}
