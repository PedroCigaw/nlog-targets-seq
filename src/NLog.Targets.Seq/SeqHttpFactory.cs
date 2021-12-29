using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Targets.Seq
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
        HttpClientHandler CreateMessageHandler();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpClient CreateClient(HttpMessageHandler handler, bool disposeHandler = true);
    }

    internal class DefaultSeqHttpFactory : ISeqHttpFactory
    {
        public HttpClientHandler CreateMessageHandler()
        {
            return new HttpClientHandler();
        }

        public HttpClient CreateClient(HttpMessageHandler handler, bool disposeHandler = true)
        {
            return handler != null ? new HttpClient(handler, disposeHandler) : new HttpClient();
        }
    }
}
