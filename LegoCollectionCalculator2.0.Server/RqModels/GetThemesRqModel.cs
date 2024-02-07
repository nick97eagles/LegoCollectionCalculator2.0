using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class GetThemesRqModel : IRequest<GetThemesRsModel>
    {
        public int CollectionID { get; set; }
    }
}
