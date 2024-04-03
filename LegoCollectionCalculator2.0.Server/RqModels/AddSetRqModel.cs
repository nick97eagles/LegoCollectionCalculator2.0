using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class AddSetRqModel : IRequest<AddSetRsModel>
    {
        public int ThemeID { get; set; }

        public List<AddSetModel> Sets { get; set; }
    }

    public class AddSetModel
    {
        public string IdentificationNum { get; set; }

        public string Name { get; set; }

        public string Condition { get; set; }
    }
}
