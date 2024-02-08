namespace LegoCollectionCalculator2._0.Server.RsModels
{
    public class GetSetsRsModel
    {
        public List<GetSetModel> Sets { get; set; }
    }

    public class GetSetModel
    {
        public int SetID { get; set; }

        public int ThemeID { get; set; }

        public string IdentificationNumber { get; set; }

        public string Name { get; set; }

        public string Condition { get; set; }
    }
}
