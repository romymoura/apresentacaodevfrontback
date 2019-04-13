using Apresentacao.Domain.Entities;

namespace Apresentacao.Domain.Interfaces
{
    public interface IAirplaneApplicationService : IBaseApplicationService<Airplane>
    {
        //Método distinto.
        int CountAirplane();
    }
}
