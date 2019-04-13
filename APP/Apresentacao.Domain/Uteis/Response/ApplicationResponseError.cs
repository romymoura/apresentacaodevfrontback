using System.Collections.Generic;
using System.Linq;
    
namespace Apresentacao.Domain.Uteis.Response
{
    public class ApplicationResponseError
    {
        public ApplicationResponseError()
        {
            ErrorsMessage = new List<ErrorMessage>();
        }

        public ApplicationResponseError(string errorCode = "0", string errorText = "")
        {
            ErrorsMessage = new List<ErrorMessage> {new ErrorMessage(errorCode, errorText)};

        }

        public ApplicationResponseError(ResultDTO resultDto)
        {
            if (resultDto == null || resultDto.Errors == null || resultDto.Errors.Any() == false)
                return;

            ErrorsMessage = new List<ErrorMessage>();
            
            
            foreach (var error in resultDto.Errors)
                ErrorsMessage.Add(new ErrorMessage(error.ErrorCode, error.ErrorText));
        }

        //public string ErrorCode { get; set; }
        //public string ErrorText { get; set; }
        public List<ErrorMessage> ErrorsMessage { get; set; }
    }
}