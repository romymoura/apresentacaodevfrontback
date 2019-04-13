using System;
namespace Apresentacao.Domain.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string CodeAirplane { get; set; }
        public int CountPassengers { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
