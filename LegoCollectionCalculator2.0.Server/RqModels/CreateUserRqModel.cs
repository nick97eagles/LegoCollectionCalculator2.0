using MediatR;
using LegoCollectionCalculator2._0.Server.RsModels;

namespace LegoCollectionCalculator2._0.Server.RqModel
{
    public class CreateUserRqModel : IRequest<CreateUserRsModel>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
