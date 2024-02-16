namespace LegoCollectionCalculator2._0.Server.Entities.Bricklink
{
    public class BricklinkSetDbo
    {
        public Meta Meta { get; set; }

        public Data Data { get; set; }
    }

    public class Meta
    {
        public string Description { get; set; }

        public string Message { get; set; }

        public int Code { get; set; }
    }

    public class Data
    {
        public string No { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Category_id { get; set; }

        public string Image_url { get; set; }

        public string Thumbnail_url { get; set; }

        public string Weight { get; set; }

        public string Dim_x { get; set; }

        public string Dim_y { get; set; }
        
        public string Dim_z { get; set; }

        public int Year_released { get; set; }

        public bool Is_obsolete { get; set; }
    }
}
