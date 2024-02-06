using MediatR;
using LegoCollectionCalculator2._0.Server.RsModels;

namespace LegoCollectionCalculator2._0.Server.RqModel
{
    public class LoginRqModel : IRequest<LoginRsModel>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
