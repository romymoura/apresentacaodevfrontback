using Apresentacao.Domain.DTO;
using Apresentacao.Domain.Uteis.Response;

namespace Apresentacao.Business.Services.Interfaces
{
    public interface IAirplaneApplication
    {
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ApplicationResponse<AirplaneResponse> InsertAirplane(AirplaneRequest input);

        /// <summary>
        /// Get id / por termos
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ApplicationResponse<AirplaneResponse> GetAirplane(AirplaneRequest input);

        /// <summary>
        /// Get list
        /// </summary>
        /// <returns></returns>
        ApplicationResponse<AirplaneResponse> ListAirplane();


        /// <summary>
        /// PUT
        /// </summary>
        /// <returns></returns>
        ApplicationResponse<AirplaneResponse> UpdateAirplane(AirplaneRequest input);


        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ApplicationResponse<AirplaneResponse> DeleteAirplane(AirplaneRequest input);
    }
}
