using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music
{
    class HttpService
    {
        public Player Player { get; set; }

        private HttpListener httpListener;
        
        public HttpService()
        {
            httpListener = new HttpListener();
            
        }

        public void SetPrefix(string prefix)
        {
            httpListener.Prefixes.Add(prefix);
        }

        public void Start()
        {
            httpListener.Start();
            httpListener.BeginGetContext(GetRequest, null);
        }

        public void Stop() => httpListener.Stop();

        private void GetRequest(IAsyncResult ar)
        {
            var result = httpListener.EndGetContext(ar);
            httpListener.BeginGetContext(GetRequest, null);
            
        }
    }
}
