namespace LegoCollectionCalculator2._0.Server.RsModels
{
    public class CreateUserRsModel
    {
        public int? UserId { get; set; }

        public int? CollectionId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string ResultMessage { get; set; }
    }
}
