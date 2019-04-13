using Apresentacao.Domain.Enuns;

namespace Apresentacao.Domain.Uteis.Response
{
    public static class CodeError
    {
        public static string GetCodeError(CodeErrorType codeErrorType)
        {
            switch (codeErrorType)
            {
                case CodeErrorType.UnexpectedError:
                    return "001";
                case CodeErrorType.RequiredField:
                    return "002";
                case CodeErrorType.ParameterWithInvalidType:
                    return "003";
                case CodeErrorType.InvalidValue:
                    return "004";
                case CodeErrorType.ETC:
                    return "005";
                default:
                    return "Opção Inválida";
            }
        }
    }
}
