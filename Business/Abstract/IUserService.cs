using Core.Utilities.Results.Abstract;
using Entities.DTOs.UserDTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Login(UserLoginDTO userLoginDTO);
        IResult Register(UserRegisterDTO userRegisterDTO);
        IResult VerifyEmail(string email, string verifyToken);
        IDataResult<UserOrderDTO> GetUserOrders(int userId);
    }
}
