using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music
{
    public class HttpService
    {
        public Player Player { get; set; }

        private HttpListener httpListener;

        private PropertyInfo[] TargetPropertys => typeof(Player).GetProperties();

        public HttpService(string prefix, Player player)
        {
            Player = player;
            httpListener = new HttpListener();

            SetPrefix(prefix);
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
            if (!httpListener.IsListening)
                return;

            HttpListenerContext result = null;
            try
            {
                result = httpListener.EndGetContext(ar);
            }
            catch { };

            httpListener.BeginGetContext(GetRequest, null);

            if (result == null)
                return;

            var request = $"Current{result.Request.RawUrl.Trim('/')}";
            string responseValue = "";

            if (request == "Current")
            {
                using (var reader = new StreamReader(
                    Assembly.GetAssembly(typeof(HttpService)).GetManifestResourceStream("OBS.Music.Web.RequestTemplate.html")))
                {
                    responseValue = reader.ReadToEnd();
                }
            }
            else if (request == "Currentjquery")
            {
                using (var reader = new StreamReader(
                   Assembly.GetAssembly(typeof(HttpService)).GetManifestResourceStream("OBS.Music.Web.jquery-3.2.1.min.js")))
                {
                    responseValue = reader.ReadToEnd();
                }
            }
            else if (request == "Currentmain")
            {
                using (var reader = new StreamReader(
                   Assembly.GetAssembly(typeof(HttpService)).GetManifestResourceStream("OBS.Music.Web.main.js")))
                {
                    responseValue = reader.ReadToEnd();
                }
            }
            else
            {

                var prop = TargetPropertys.FirstOrDefault(p => p.Name == request);

                if (prop == null)
                {
                    result.Response.Close();
                    return;
                }
                var obj = (string)prop.GetValue(Player);
                responseValue = obj ?? "";
            }

            var buffer = Encoding.UTF8.GetBytes(responseValue);
            result.Response.ContentLength64 = buffer.LongLength;
            result.Response.OutputStream.Write(buffer, 0, buffer.
                Length);

            result.Response.Close();

        }

    }
}
