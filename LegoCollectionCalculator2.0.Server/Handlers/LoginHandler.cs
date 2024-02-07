using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.Helpers;
using LegoCollectionCalculator2._0.Server.RqModel;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class LoginHandler : IRequestHandler<LoginRqModel, LoginRsModel>
    {
        public readonly UserContext _userContext;

        public LoginHandler(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<LoginRsModel> Handle(LoginRqModel request, CancellationToken cancellationToken)
        {
            var user = await _userContext.Users.Where(x => x.UserName == request.Login).FirstOrDefaultAsync();

            if (user == null)
            {
                return new LoginRsModel
                {
                    UserName = request.Login,
                    ResultMessage = "No User Found"
                };
            }

            if (!isValidPassword(request.Password, user.Password))
            {
                return new LoginRsModel
                {
                    UserName = request.Login,
                    ResultMessage = "Incorrect Password"
                };
            }

            return new LoginRsModel
            {
                UserId = user.UserID,
                UserName = user.UserName,
                UserEmail = user.Email,
                UserRole = user.UserRole,
                CollectionId = user.CollectionID,
                ResultMessage = "User Access Granted"
            };
        }

        private bool isValidPassword(string userInput, string hashValue)
        {
            return PasswordHelper.VerifyHash(userInput, "SHA512", hashValue);
        }
    }
}
