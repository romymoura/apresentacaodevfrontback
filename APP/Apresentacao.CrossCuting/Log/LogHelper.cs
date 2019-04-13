using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace Apresentacao.CrossCuting.Log
{
    public class LogHelper
    {
        private static readonly ILoggerRepository _logRepository;
        private static readonly ILog _log;
        private const string HideWith = "***";

        static LogHelper()
        {
            _logRepository = LogManager.GetRepository(GetAssembly());
            XmlConfigurator.Configure(_logRepository);
            _log = GetLogger("logInfo"); //DEFAULT
        }

        private static ILog GetLogger(string logName)
        {
            ILog log = LogManager.GetLogger(GetAssembly(), logName);
            return log;
        }

        private static Assembly GetAssembly()
        {
            return Assembly.GetEntryAssembly();
        }


        /// <summary>
        /// This method will format the Action Log messages
        /// </summary>
        /// <param name="context"></param>
        public static string FormatActionMessage(ActionExecutingContext context)
        {
            string formatLog4Net = "{" +
                                    String.Format("\"Controller\":{0}, \"Action\":{1}",
                                    "\"" + context.ActionDescriptor.AttributeRouteInfo.GetType().FullName + "\"",
                                    "\"" + context.ActionDescriptor.AttributeRouteInfo.Name+ "\"") +
                                   "}";

            return formatLog4Net;
        }

        public static void WriteDebugLog(string message, Exception ex)
        {
            if (ex == null)
                _log.DebugFormat(message);
            else
                _log.DebugFormat(message, ex);
        }

        public static void WriteInfoLog(string message)
        {
            _log.Info(message);
        }
      
        public static void WriteErrorLog(string message, Exception ex)
        {
            ILog log = GetLogger("logError");
            log.Error(message, ex);
        }

        public static string HideSensitiveData(string jsonSerialized)
        {
            var ret = "";

            try
            {
                if (!string.IsNullOrEmpty(jsonSerialized))
                {
                    var jsonParsed = JObject.Parse(jsonSerialized);
                    ret = JsonConvert.SerializeObject(jsonParsed);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return ret;
        }

        private static void FindTokens(JToken containerToken, string name)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {
                    if (child.Name == name)
                    {
                        child.Value = HideWith;
                    }
                    else
                    {
                        if (child.Value.ToString() == name)
                        {
                            ((JProperty)child.Next).Value = HideWith;
                        }
                    }
                    FindTokens(child.Value, name);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindTokens(child, name);
                }
            }
        }
    }
}
