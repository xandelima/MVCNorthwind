using System;
using System.Web;
using MvcNorthwind.Models;
using Repositorio.Base;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace WebApplication4
{
    public class IISHandler : IHttpAsyncHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        HttpContext context;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
        }

        #endregion

        NhRepo<Customer> repositorio =  new NhRepo<Customer>();

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
           IEnumerable<Customer> customers = repositorio.PesquisarLista();
           IAsyncResult result = new AsyncResult();
           result.AsyncState = customers.Take(Convert.ToInt32(context.Request["total"]));

           return result;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}
