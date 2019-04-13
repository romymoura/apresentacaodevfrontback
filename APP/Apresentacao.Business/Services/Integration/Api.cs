using Apresentacao.Business.Services.Integration.Bases;
using Apresentacao.Domain.Uteis.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Apresentacao.Business.Services.Integration
{
    public class Api : BasesAPI
    {
        public Api(IConfiguration configuration) : base(configuration)
        {
        }
        public virtual async Task<TReturn> InvokeAsyncObject<TReturn>(string urlMethod, HttpMethod httpMethod)
        {
            var result = await InvokeAsyncJson<object>(urlMethod, httpMethod, null);
            return JsonConvert.DeserializeObject<TReturn>(result);
        }
        public virtual async Task<TReturn> InvokeAsyncObject<TReturn, TInput>(string urlMethod, HttpMethod httpMethod, TInput input)
        {
            var result = await InvokeAsyncJson(urlMethod, httpMethod, input);
            return JsonConvert.DeserializeObject<TReturn>(result);
        }
        public virtual async Task<string> InvokeAsyncJson<T>(string urlMethod, HttpMethod httpMethod, T input)
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.Timeout = TimeSpan.FromMilliseconds(150000);
            }

            var req = new HttpRequestMessage(httpMethod, string.Concat(UrlApi, "/", urlMethod));
            if ((input != null && input is string == false) || (input is string && string.IsNullOrEmpty(input.ToString()) == false))
                req.Content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
            var result = string.Empty;
            try
            {
                var responseMessage = await _client.SendAsync(req);
                result = responseMessage.Content.ReadAsStringAsync().Result;

                if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {

                    var sessionExpiredJson = new ApplicationResponse<object>
                    {
                        Value = null,
                        Message = "Sessão expirada. Efetue o logon no sistema.",
                        Status = 0,
                        ResponsesError = null
                    };

                    result = JsonConvert.SerializeObject(sessionExpiredJson);
                }

                req.Dispose();
                responseMessage.Dispose();
            }
            catch (TaskCanceledException)
            {
                var sessionExpiredJson = new ApplicationResponse<object>
                {
                    Value = null,
                    Message = "Erro de comunicação. Tente novamente mais tarde.",
                    Status = ApplicationResponseStatus.TimeOut,
                    ResponsesError = null
                };
                result = JsonConvert.SerializeObject(sessionExpiredJson);
            }
            catch (System.Exception ex)
            {
                var sessionExpiredJson = new ApplicationResponse<object>
                {
                    Value = null,
                    Message = "Erro de comunicação. Tente novamente mais tarde.",
                    Status = 0,
                    ResponsesError = null
                };
                result = JsonConvert.SerializeObject(sessionExpiredJson);

            }
            return result;
        }

        public virtual TReturn InvokeObject<TReturn>(string urlMethod, HttpMethod httpMethod)
        {
            var result = InvokeJson<object>(urlMethod, httpMethod, null);
            return JsonConvert.DeserializeObject<TReturn>(result);
        }
        public virtual TReturn InvokeObject<TReturn, TInput>(string urlMethod, HttpMethod httpMethod, TInput input)
        {
            var result = InvokeJson(urlMethod, httpMethod, input);
            return JsonConvert.DeserializeObject<TReturn>(result);
        }
        public virtual string InvokeJson<T>(string urlMethod, HttpMethod httpMethod, T input)
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.Timeout = TimeSpan.FromMilliseconds(150000);
            }

            var req = new HttpRequestMessage(httpMethod, string.Concat(UrlApi, "/", urlMethod));
            if ((input != null && input is string == false) || (input is string && string.IsNullOrEmpty(input.ToString()) == false))
                req.Content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
            var result = string.Empty;
            try
            {
                var responseMessage = _client.SendAsync(req).Result;
                result = responseMessage.Content.ReadAsStringAsync().Result;

                if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {

                    var sessionExpiredJson = new ApplicationResponse<object>
                    {
                        Value = null,
                        Message = "Sessão expirada. Efetue o logon no sistema.",
                        Status = 0,
                        ResponsesError = null
                    };

                    result = JsonConvert.SerializeObject(sessionExpiredJson);
                }

                req.Dispose();
                responseMessage.Dispose();
            }
            catch (TaskCanceledException)
            {
                var sessionExpiredJson = new ApplicationResponse<object>
                {
                    Value = null,
                    Message = "Erro de comunicação. Tente novamente mais tarde.",
                    Status = ApplicationResponseStatus.TimeOut,
                    ResponsesError = null
                };
                result = JsonConvert.SerializeObject(sessionExpiredJson);
            }
            catch (System.Exception ex)
            {
                var sessionExpiredJson = new ApplicationResponse<object>
                {
                    Value = null,
                    Message = "Erro de comunicação. Tente novamente mais tarde.",
                    Status = 0,
                    ResponsesError = null
                };
                result = JsonConvert.SerializeObject(sessionExpiredJson);

            }
            return result;
        }
    }
}
