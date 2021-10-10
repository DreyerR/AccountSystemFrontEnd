using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using AccountSystemFrontEnd.Models;
using AccountSystemFrontEnd.Constants;

namespace AccountSystemFrontEnd.WebService
{
    class Api
    {
        private static HttpClient httpClient;
        private static readonly string memberId = "1";

        private static HttpClient GetHttpClient()
        {
            return httpClient != null ? httpClient : httpClient = new HttpClient();
        }

        public async static Task<GeneralResponse<Currency>> FetchMemberCurrency()
        {
            string URL = AppConstants.VIEW_CURRENCY_URL + "?memberId=" + memberId;
            httpClient = GetHttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                GeneralResponse<Currency> generalResponse = JsonConvert.DeserializeObject<GeneralResponse<Currency>>(content);
                return generalResponse;
            }

            return null;
        }

        public async static Task<GeneralResponse<string>> AddCurrency(double amount)
        {
            string URL = string.Format("{0}/{1}?amount={2}", AppConstants.ADD_CURRENCY_URL, memberId, amount);
            httpClient = GetHttpClient();

            using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PUT"), URL))
            {
                request.Headers.TryAddWithoutValidation("accept", "*/*");
                HttpResponseMessage response = await httpClient.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();
                GeneralResponse<string> generalResponse = JsonConvert.DeserializeObject<GeneralResponse<string>>(content);
                return generalResponse;
            }
        }

        public async static Task<GeneralResponse<string>> SubtractCurrency(double amount)
        {
            string URL = string.Format("{0}/{1}?amount={2}", AppConstants.SUBTRACT_CURRENCY_URL, memberId, amount);
            httpClient = GetHttpClient();

            using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PUT"), URL))
            {
                request.Headers.TryAddWithoutValidation("accept", "*/*");
                HttpResponseMessage response = await httpClient.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();
                GeneralResponse<string> generalResponse = JsonConvert.DeserializeObject<GeneralResponse<string>>(content);
                return generalResponse;
            }
        }
    }
}
