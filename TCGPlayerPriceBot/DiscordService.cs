using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGPlayerPriceBot
{
    public static class DiscordService
    {
        public static void PostWebhook(string webhookURL, List<ProductModel> products, string footerAd)
        {
            var client = new RestClient();

            foreach (var product in products)
            {
                client.BaseUrl = new Uri("https://discordapp.com");
                Uri URI = new Uri(webhookURL);

                var request = new RestRequest(Method.POST)
                {
                    Resource = URI.AbsolutePath,
                    RequestFormat = DataFormat.Json
                };
                var alert = new
                {
                    content = "",
                    username = "tcgSniper",
                    //avatar_url = "https://imgur.com/C1xllx3",
                    embeds = new[] {
                    new {
                    title = $"{product.Set} - {product.Name} has a {product.Percent}% shift. | Rarity/Edition {product.Rarity}",
                    description = $"{product.Url}",
                    color = 16119099,
                    //image = new
                    //{
                    //    url = "https://6d4be195623157e28848-7697ece4918e0a73861de0eb37d08968.ssl.cf1.rackcdn.com/187229_200w.jpg"
                    //},
                    fields = new object[] {
                        new {
                            name = "Current Price",
                            value = $"{product.New_marketprice}",
                            inline = true
                        },
                        new {
                            name = "Previous Price",
                            value = $"{product.Old_marketprice}",
                            inline = true
                        }
                    },
                    footer = new
                    {
                        icon_url = "https://images-ext-2.discordapp.net/external/2dZVVL6feMSM7lxfFkKVW__LToSOzmToSEmocJV5vcA/https/cdn.discordapp.com/embed/avatars/0.png",
                        text = footerAd
                    }
                } },
                };
                JsonConvert.SerializeObject(alert);
                request.AddJsonBody(alert);
                client.Execute(request);
            }
        }
    }
}
