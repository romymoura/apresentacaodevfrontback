using log4net;
using Apresentacao.Domain.Enuns;
using Apresentacao.Domain.Uteis.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentacao.Application.Controllers.Bases
{
    public class BaseApiController : ControllerBase
    {
        #region Private Props
        #endregion
        protected readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public T RequestService<T>(Func<T> action)
        {
            try
            {
                var result = action();
                logger.Info(ControllerContext.ActionDescriptor.ActionName +
                    "API Result: " + JsonConvert.SerializeObject(result, Formatting.None));
                return result;
            }
            catch (Exception ex)
            {
                var objectReturn = Activator.CreateInstance<T>();
                var objectType = objectReturn.GetType();
                if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(ApplicationResponse<>))
                {
                    objectReturn.GetType().GetProperties().First(x => x.Name == "Message").SetValue(objectReturn, VersatileFunctionsEnum.GetDescription(CodeErrorType.UnexpectedError));
                    objectReturn.GetType().GetProperties().First(x => x.Name == "Status").SetValue(objectReturn, Enum.ToObject(objectReturn.GetType().GetProperties().First(x => x.Name == "Status").PropertyType, 3));
                }
                else if (objectType.BaseType == typeof(ResultDTO))
                {
                    objectReturn.GetType().GetProperties().First(x => x.Name == "ReturnExecution")
                        .SetValue(objectReturn, (int)ReturnExecution.WITH_ERROR);

                    var errors = new List<ErrorResultDTO>() { new ErrorResultDTO() {
                        ErrorCode = CodeError.GetCodeError(CodeErrorType.UnexpectedError),
                        ErrorText = VersatileFunctionsEnum.GetDescription(CodeErrorType.UnexpectedError) } };

                    objectReturn.GetType().GetProperties().First(x => x.Name == "Errors").SetValue(objectReturn, errors);
                }
                else
                {
                    throw new Exception("BaseController.RequestService exception not handled for type " + objectType.Name);
                }

                logger.Info(ControllerContext.ActionDescriptor.ActionName +
                    "API Result: Exception " + ex.GetType().ToString() + " Message: " + ex.Message + (ex.InnerException != null ? " inner ex: " + ex.InnerException.Message : ""));

                logger.Error("API Result Excepion Detail.", ex);
                return objectReturn;
            }
        }
        public async Task<T> RequestServiceAsync<T>(Func<Task<T>> action)
        {
            try
            {
                var result = await action();
                //logger.Info(ControllerContext.ActionDescriptor.ActionName + "API Result: " + JsonConvert.SerializeObject(result, Formatting.Indented));
                return result;
            }
            catch (Exception ex)
            {
                var objectReturn = Activator.CreateInstance<T>();
                var objectType = objectReturn.GetType();
                if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(ApplicationResponse<>))
                {
                    objectReturn.GetType().GetProperties().First(x => x.Name == "Message").SetValue(objectReturn, VersatileFunctionsEnum.GetDescription(CodeErrorType.UnexpectedError));
                    objectReturn.GetType().GetProperties().First(x => x.Name == "Status").SetValue(objectReturn, Enum.ToObject(objectReturn.GetType().GetProperties().First(x => x.Name == "Status").PropertyType, 3));
                }
                else if (objectType.BaseType == typeof(ResultDTO))
                {
                    objectReturn.GetType().GetProperties().First(x => x.Name == "ReturnExecution")
                        .SetValue(objectReturn, (int)ReturnExecution.WITH_ERROR);

                    var errors = new List<ErrorResultDTO>() { new ErrorResultDTO() {
                        ErrorCode = CodeError.GetCodeError(CodeErrorType.UnexpectedError),
                        ErrorText = VersatileFunctionsEnum.GetDescription(CodeErrorType.UnexpectedError) } };

                    objectReturn.GetType().GetProperties().First(x => x.Name == "Errors").SetValue(objectReturn, errors);
                }
                else
                {
                    throw new Exception("BaseController.RequestService exception not handled for type " + objectType.Name);
                }
                //logger.Info(ControllerContext.ActionDescriptor.ActionName + "API Result: Exception " + ex.GetType().ToString() + " Message: " + ex.Message + (ex.InnerException != null ? " inner ex: " + ex.InnerException.Message : ""));
                //logger.Error("API Result Excepion Detail.", ex);
                return objectReturn;
            }
        }
    }
}