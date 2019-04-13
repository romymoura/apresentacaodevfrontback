using System.ComponentModel;
namespace Apresentacao.Domain.Enuns
{

    public enum TypeMethod
    {
        POST,
        GET,
        INPUT
    }

    public enum ApiVersion
    {
        V1,
        V2,
        V3,
        V4,
        V3_Oauth,
        V4_Oauth,
        Nothing

    }
    
    public enum ReturnExecution
    {
        [Description("Execution with successful")]
        SUCCESS = 0,

        [Description("Execution with errors")]
        WITH_ERROR = 1,

        [Description("Execution with Warnings")]
        WITH_WARNING = 2
    }


    public enum CodeErrorType
    {
        [Description("Ocorreu um erro na comunicação com o servidor. Tente novamente mais tarde.")]
        UnexpectedError = 1,
        [Description("Required Field")]
        RequiredField = 2,
        [Description("Parameter With Invalid Type")]
        ParameterWithInvalidType = 3,
        [Description("Invalid Value")]
        InvalidValue = 4,
        [Description("ETC")]
        ETC = 5
    }
}
