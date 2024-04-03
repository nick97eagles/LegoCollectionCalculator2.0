using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class GetSetRqModel : IRequest<GetSetRsModel>
    {
        public string SetID { get; set; }
    }
}
