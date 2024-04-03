namespace LegoCollectionCalculator2._0.Server.Entities.Bricklink
{
    public class BricklinkRespDbo<T>
    {
        public  Meta Meta { get; set; }

        public T Data { get; set; }
    }

    public class Meta
    {
        public string Description { get; set; }

        public string Message { get; set; }

        public int Code { get; set; }
    }
}
