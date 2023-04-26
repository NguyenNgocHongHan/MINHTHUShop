using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MINHTHUShop.Web.Infrastructure.Core
{
    public class APIControllerBase : ApiController
    {
        private ITb_ErrorService _tb_ErrorService;

        public APIControllerBase(ITb_ErrorService tb_ErrorService)
        {
            this._tb_ErrorService = tb_ErrorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Tb_Error error = new Tb_Error();
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                error.CreateDate = DateTime.Now;
                _tb_ErrorService.Create(error);
                _tb_ErrorService.SaveChanges();
            }
            catch
            {
            }
        }
    }
}