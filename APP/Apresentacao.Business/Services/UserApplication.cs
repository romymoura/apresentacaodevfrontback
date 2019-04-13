using Apresentacao.Business.Services.Interfaces;
using Apresentacao.Domain.DTO;
using Apresentacao.Domain.Interfaces;
using Apresentacao.Domain.Uteis.Response;
using System;

namespace Apresentacao.Business.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserApplicationService UserService;

        public UserApplication(IUserApplicationService userService)
        {
            UserService = userService;
        }

        public ApplicationResponse<UserResponse> Login(UserRequest input)
        {
            try
            {
                var user = UserService.Login(input.Username, input.Password);

                if (user == null)
                    throw new Exception("Error");

                return new ApplicationResponse<UserResponse>(
                    new UserResponse()
                    {
                        Fullname = user.Fullname
                    },
                    ApplicationResponseStatus.Success,
                    "Successfully login user!"
                );
            }
            //Aqui podemos adicionar alguns recursos de regras de negócio bem como, para o desenvolvedor ou validações do lado do servidor antes de bater na base de dados ou seja uma segurança.
            //Além da autenticação.
            //Precisa implementar alguns erros customizados para interpretar o enum ApplicationResponseStatus,
            catch (Exception ex)
            {
                return new ApplicationResponse<UserResponse>(
                      null,
                      ApplicationResponseStatus.Error,
                      "Error login user!"
                  );
            }
        }
    }
}
