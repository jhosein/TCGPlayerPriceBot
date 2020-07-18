using System;
using System.Collections.Generic;
using System.Text;

namespace TCGPlayerPriceBot
{
    public class TCGPlayerTrendResponseModel
    {
        public List<ProductModel> Data { get; set; }
    }

    public class ProductModel
    {
        public int Product { get; set; }
        public string Old_marketprice { get; set; }
        public string New_marketprice { get; set; }
        public decimal Percent { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string SubType { get; set; }
    }
}
