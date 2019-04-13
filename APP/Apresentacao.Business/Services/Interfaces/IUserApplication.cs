using Apresentacao.Domain.DTO;
using Apresentacao.Domain.Uteis.Response;

namespace Apresentacao.Business.Services.Interfaces
{
    public interface IUserApplication
    {
        ApplicationResponse<UserResponse> Login(UserRequest input);
    }
}
