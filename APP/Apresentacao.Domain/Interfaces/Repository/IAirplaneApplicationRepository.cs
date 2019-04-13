using Apresentacao.Domain.Entities;

namespace Apresentacao.Domain.Interfaces.Repository
{
    public interface IAirplaneApplicationRepository : IBaseCrudApplicationRepository<Airplane>
    {
        //Método distinto.
        int CountAirplane();
    }
}
