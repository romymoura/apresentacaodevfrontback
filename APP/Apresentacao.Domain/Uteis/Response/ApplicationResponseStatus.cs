using System.ComponentModel;

namespace Apresentacao.Domain.Uteis.Response
{
    public enum ApplicationResponseStatus
    {
        [Description("Não processado")]
        NotSet = 0,
        [Description("Sucesso")]
        Success = 1,
        [Description("Erro")]
        Error = 2,
        [Description("Exceção")]
        Exception = 3,
        [Description("Error business")]
        ErrorBusiness = 4,
        [Description("TimeOut")]
        TimeOut = 5,
        [Description("Warning")]
        Warning = 6,
        [Description("Error internal server error")]
        ErrorInternalServerError = 7,
    }
}