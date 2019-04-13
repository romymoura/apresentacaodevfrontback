using Apresentacao.Domain.Entities;
using Apresentacao.Domain.Interfaces;
using Apresentacao.Domain.Interfaces.Repository;

namespace Apresentacao.Domain.Services
{
    public class AirplaneApplicationService : BaseApplicationService<Airplane>, IAirplaneApplicationService
    {
        protected readonly IAirplaneApplicationRepository AirplaneRepository;
        public AirplaneApplicationService(IAirplaneApplicationRepository airplaneRepository) :base (airplaneRepository)
        {
            AirplaneRepository = airplaneRepository;
        }

        //Método distinto.
        public int CountAirplane()
        {
            return AirplaneRepository.CountAirplane();
        }
    }
}
