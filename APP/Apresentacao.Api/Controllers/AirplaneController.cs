using Apresentacao.Api.Managers.Settings;
using Apresentacao.Application.Controllers.Bases;
using Apresentacao.Business.Services.Interfaces;
using Apresentacao.Domain.DTO;
using Apresentacao.Domain.Uteis.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Api.Controllers
{
    [Authorize(Roles = "User, Admin")]
    [Route("api/[controller]")]
    public class AirplaneController : BaseApiController
    {
        private readonly IAirplaneApplication AirplaneBll;
        private readonly JwtSettings Settings;

        public AirplaneController(IAirplaneApplication airplaneBll, JwtSettings settings) 
        {
            AirplaneBll = airplaneBll;
            Settings = settings;
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [Route("insert")]
        public ApplicationResponse<AirplaneResponse> Insert([FromBody] AirplaneRequest input)
        {
            return this.RequestService<ApplicationResponse<AirplaneResponse>>(() =>
            {
                return AirplaneBll.InsertAirplane(input);
            });
        }


        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        [Route("getall")]
        public ApplicationResponse<AirplaneResponse> GetAll()
        {
            return this.RequestService<ApplicationResponse<AirplaneResponse>>(() =>
            {
                return AirplaneBll.ListAirplane();
            });
        }


        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        [Route("get")]
        public ApplicationResponse<AirplaneResponse> Get(AirplaneRequest input)
        {
            return this.RequestService<ApplicationResponse<AirplaneResponse>>(() =>
            {
                return AirplaneBll.GetAirplane(input);
            });
        }


        [Authorize(Roles = "User, Admin")]
        [HttpDelete]
        [Route("delete")]
        public ApplicationResponse<AirplaneResponse> Delete(int id)
        {
            return this.RequestService<ApplicationResponse<AirplaneResponse>>(() =>
            {
                return AirplaneBll.DeleteAirplane(new AirplaneRequest() { Id = id });
            });
        }


        [Authorize(Roles = "User, Admin")]
        [HttpPut]
        [Route("update")]
        public ApplicationResponse<AirplaneResponse> Update(AirplaneRequest input)
        {
            return this.RequestService<ApplicationResponse<AirplaneResponse>>(() =>
            {
                return AirplaneBll.UpdateAirplane(input);
            });
        }
    }
}