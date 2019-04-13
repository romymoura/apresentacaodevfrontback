using Apresentacao.Domain.Entities;
using Apresentacao.Domain.Interfaces.Repository;
using System.Linq;

namespace Apresentacao.Data.EntityObjectsRepositorys
{
    public class AirplaneApplicationRepository : BaseCrudApplicationRepository<Airplane>, IAirplaneApplicationRepository
    {
        public AirplaneApplicationRepository(ApplicationDbContext context) : base(context)
        {
        }

        //Métodos distintos
        public int CountAirplane()
        {
            return Context.Airplanes.ToList().Count();
        }
    }
}