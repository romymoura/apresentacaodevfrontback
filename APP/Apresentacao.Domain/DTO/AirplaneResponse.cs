using Apresentacao.Domain.Entities;
using System.Collections.Generic;

namespace Apresentacao.Domain.DTO
{
    public class AirplaneResponse
    {
        public Airplane Airplane { get; set; }
        public ICollection<Airplane> Airplanes { get; set; }
    }
}
