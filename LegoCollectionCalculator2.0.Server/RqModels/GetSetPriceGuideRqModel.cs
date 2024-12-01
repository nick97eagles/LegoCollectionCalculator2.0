using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class GetSetPriceGuideRqModel : IRequest<GetSetPriceGuideRsModel>
    {
        // TODO: change this to IdentificationNumber
        public string SetID { get; set; }

        public string N_or_u { get; set; }
    }
}
