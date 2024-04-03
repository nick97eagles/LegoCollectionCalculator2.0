namespace LegoCollectionCalculator2._0.Server.Entities.Bricklink
{
    public class BricklinkPriceGuideDbo
    {
        public Item Item { get; set; }

        public string New_or_used { get; set; }

        public string Currency_code { get; set; }

        public string Min_price { get; set; }

        public string Max_price { get; set; }

        public string Avg_price { get; set; }

        public string Qty_avg_price { get; set; }

        public string Unit_quantity { get; set; }

        public string Total_quantity { get; set; }
    }

    public class Item
    {
        public string No { get; set; }

        public string Type { get; set; }
    }
}
