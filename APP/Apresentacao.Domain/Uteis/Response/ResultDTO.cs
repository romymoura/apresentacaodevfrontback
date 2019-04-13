using System.Collections.Generic;
using Apresentacao.Domain.Enuns;

namespace Apresentacao.Domain.Uteis.Response
{
    public class ResultDTO
    {
        public long? IdLogEntry { get; set; }

        public ReturnExecution ReturnExecution { get; set; }

        public List<ErrorResultDTO> Errors { get; set; }

    }
}
