using Apresentacao.Api.Managers;
using Apresentacao.Api.Managers.Settings;
using Apresentacao.Application.Controllers.Bases;
using Apresentacao.Business.Services.Interfaces;
using Apresentacao.Domain.DTO;
using Apresentacao.Domain.Uteis.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Apresentacao.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        private IUserApplication UserBll;
        private readonly JwtSettings Settings;

        public UserController(IUserApplication userBll, JwtSettings settings)
        {
            UserBll = userBll;
            Settings = settings;
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public Task<ApplicationResponse<UserResponse>> Login([FromBody]  UserRequest input)
        {
            return this.RequestServiceAsync<ApplicationResponse<UserResponse>>(() =>
            {
                var result = UserBll.Login(input);
                if (result.Status == ApplicationResponseStatus.Success)
                {
                    result.Value.Token = JwtManager.GenerateToken(result.Value.Fullname, Settings);
                }
                else
                {
                    //Bad request
                    result.Status = ApplicationResponseStatus.Warning;
                    result.Message = "Usuário ou senha invalidos";
                }
                return Task.FromResult(result);
            });
        }
    }
}