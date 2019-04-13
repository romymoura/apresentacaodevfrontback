namespace Apresentacao.Domain.Uteis.Response
{
    public class ErrorMessage
    {
        #region [Properties]

        public string Code { get; set; }
        public string Message { get; set; }
       

        #endregion

        #region [Ctor]

        public ErrorMessage(string errorCode, string errorMessage)
        {
            Code = errorCode;
            Message = errorMessage;
        }

        public ErrorMessage(string errorMessage)
        {
            Message = errorMessage;
        }

        public ErrorMessage()
        {
            
        }

        #endregion
    }
}
