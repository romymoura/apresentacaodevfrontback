using Apresentacao.Domain.Entities;
using System.Collections.Generic;

namespace Apresentacao.Domain.Models
{
    public class AirplaneModel
    {
        public Airplane Plane { get; set; }
        public ICollection<Airplane> Planes { get; set; }
    }
}
