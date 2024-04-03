using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class DeleteSetRqModel : IRequest<DeleteSetRsModel>
    {
        public int SetID { get; set; }
    }
}
