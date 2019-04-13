using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace Apresentacao.CrossCuting.Helpers.States
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }

    public class RequestHandler
    {
        IHttpContextAccessor _httpContextAccessor;
        public RequestHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        internal void HandleAboutRequest()
        {
            var message = "The HttpContextAccessor seems to be working!!";
            _httpContextAccessor.HttpContext.Session.SetString("message", message);
        }


        public void Set<T>(string key, T value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public void FlashSet<T>(string key, T value)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }


        public T Get<T>(string key)
        {
            var value = _httpContextAccessor.HttpContext.Session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
