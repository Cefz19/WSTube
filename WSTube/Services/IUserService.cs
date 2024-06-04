using WSTube.Models.Request;
using WSTube.Models.Respons;

namespace WSTube.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
