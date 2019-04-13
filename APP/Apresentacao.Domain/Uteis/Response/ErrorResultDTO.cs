using System.Collections.Generic;

namespace Apresentacao.Domain.Uteis.Response
{
    public sealed class ErrorResultDTO
    {
        public string ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public List<ErrorIdentifier> ErrorIdentifiers { get; set; }
    }

    public sealed class ErrorIdentifier
    {
        // public KeyIdentifierType Key { get; set; }
        public string Value { get; set; }
    }
}
