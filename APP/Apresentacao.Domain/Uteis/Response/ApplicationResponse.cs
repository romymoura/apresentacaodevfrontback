namespace Apresentacao.Domain.Uteis.Response
{
    public class ApplicationResponse<T>
    {
        public ApplicationResponse()
        {

        }
        public ApplicationResponse(T value)
        {
            this.Value = value;
        }

        public ApplicationResponse(T value, ApplicationResponseStatus status)
        {
            this.Value = value;
            this.Status = status;
        }

        public ApplicationResponse(T value, ApplicationResponseStatus status, string message)
        {
            this.Value = value;
            this.Status = status;
            this.Message = message;
        }

        public T Value { get; set; }
        public string Message { get; set; }
        public ApplicationResponseStatus Status { get; set; }
        public ApplicationResponseError ResponsesError { get; set; }
    }
}