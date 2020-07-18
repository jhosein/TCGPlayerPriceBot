using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TCGPlayerPriceBot
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 0 12 * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            //Variables
            int numberOfProducts = 10;
            string discordWebhook = "https://discordapp.com/api/webhooks/734054469708415088/AGRuuCBezkz3ZU0mM2nPLU55lWlXbYOPCDcAr452Va7iZMGe7QNiBWB4UUriqn72CpRJ";
            string footerAd = "Snipe YuGiOh singles on tcgSniper.com";
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            List<ProductModel> products = TCGPlayerService.GetTopX(numberOfProducts);
            DiscordService.PostWebhook(discordWebhook, products, footerAd);

            log.LogInformation($"Finished {products.Count} products at: {DateTime.Now}");
        }
    }
}
