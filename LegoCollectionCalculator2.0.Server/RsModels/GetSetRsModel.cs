namespace LegoCollectionCalculator2._0.Server.RsModels
{
    public class GetSetRsModel
    {
        public string Name { get; set; }

        public string SetId { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public string Weight { get; set; }

        public string Dim_x { get; set; }

        public string Dim_y { get; set; }

        public string Dim_z { get; set; }

        public long YearReleased { get; set; }

        public bool IsObsolete { get; set; }
    }
}
