using Azure.Core;
using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.Entities;
using LegoCollectionCalculator2._0.Server.Helpers;
using LegoCollectionCalculator2._0.Server.RqModel;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRqModel, CreateUserRsModel>
    {
        public readonly UserContext _userContext;

        public CreateUserHandler(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<CreateUserRsModel> Handle(CreateUserRqModel request, CancellationToken cancellationToken)
        {
            if (await DoesUserNameExist(request.UserName))
            {
                return new CreateUserRsModel()
                {
                    UserName = request.UserName,
                    UserEmail = request.Email,
                    ResultMessage = "UserName already exists"
                };
            }

            if (await DoesEmailExist(request.Email))
            {
                return new CreateUserRsModel()
                {
                    UserName = request.UserName,
                    UserEmail = request.Email,
                    ResultMessage = "Email already exists"
                };
            }

            var newUser = await CreateNewUser(request);

            return new CreateUserRsModel()
            {
                UserId = newUser.UserID,
                UserName = newUser.UserName,
                UserEmail = newUser.Email,
                CollectionId = newUser.CollectionID,
                UserRole = "User",
                ResultMessage = "New User Created"
            };
        }

        private async Task<bool> DoesUserNameExist(string userName)
        {
            return await _userContext.Users.AnyAsync(x => x.UserName == userName);
        }

        private async Task<bool> DoesEmailExist(string email)
        {
            return await _userContext.Users.AnyAsync(x => x.Email == email);
        }

        private async Task<UserDbo> CreateNewUser(CreateUserRqModel userModel)
        {
            // TODO: Add password contraints 
            var hashedPw = PasswordHelper.ComputeHash(userModel.Password, "SHA512", null);
            var newCollectionId = await _userContext.Users.OrderByDescending(x => x.CollectionID).Select(x => x.CollectionID).FirstOrDefaultAsync();
            var newUserId = await _userContext.Users.OrderByDescending(x => x.UserID).Select(x => x.UserID).FirstOrDefaultAsync();

            var newUser = new UserDbo()
            {
                UserID = newUserId + 1,
                UserName = userModel.UserName,
                Email = userModel.Email,
                Password = hashedPw,
                CollectionID = newCollectionId + 1,
                UserRole = "User"
            };

            var user = await _userContext.Users.AddAsync(newUser);
            await _userContext.SaveChangesAsync();

            return user.Entity;
        }
    }
}
