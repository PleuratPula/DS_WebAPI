using System.Threading.Tasks;
using DS_WebAPI.ControllerModels.UserModels;

namespace DS_WebAPI.Interfaces
{
    public interface IUsersRepository<User> : IDataRepository<User>
    {
        Task<User> Authorize(AuthenticationModel model);
    }
}
