using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCGPlayerPriceBot
{
    public static class TCGPlayerService
    {
        public static List<ProductModel> GetTopX(int x = 10)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://db.ygoprodeck.com");
            var request = new RestRequest(Method.GET);

            request.Resource = "queries/trend_prices/tcgplayer_trend.php";
            request.RequestFormat = DataFormat.Json;
            //request.AddQueryParameter("categoryName", categoryName);
            //request.AddHeader("Content-Type", "application/json; charset=utf-8");

            var response = client.Execute(request);
            var allProducts = JsonConvert.DeserializeObject<TCGPlayerTrendResponseModel>(response.Content).Data;

            var top10 = allProducts.Take(10).ToList();

            foreach (var product in top10)
            {
                product.Url = product.Url.Replace("YGOPRODeck", "TCGSniper");
            }

            return top10;
        }
    }
}
