using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISeqHttpFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpMessageHandler CreateMessageHandler();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpClient CreateClient(HttpMessageHandler handler, bool disposeHandler = true);
    }

    /// <summary>
    /// 
    /// </summary>
    public class DefaultSeqHttpFactory : ISeqHttpFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public static void RegisterDefaultService()
        {
            LogManager.LogFactory.ServiceRepository.RegisterService(typeof(ISeqHttpFactory), new DefaultSeqHttpFactory());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="disposeHandler"></param>
        /// <returns></returns>
        public HttpClient CreateClient(HttpMessageHandler handler, bool disposeHandler = true)
        {
            return handler != null ? new HttpClient(handler, disposeHandler) : new HttpClient();
        }
    }
}
