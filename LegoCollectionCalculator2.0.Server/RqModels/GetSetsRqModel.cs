using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class GetSetsRqModel : IRequest<GetSetsRsModel>
    {
        public int ThemeID { get; set; }
    }
}
