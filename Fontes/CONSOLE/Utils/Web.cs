using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ConsoleApp.Utils
{
    public class Web
    {
        public static string Get(string url)
        {
            string retorno;
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add("accept", "application/json");
                    retorno = wc.DownloadString(url);
                }
            }
            catch (WebException ex)
            {
                if (ex.Status.Equals(WebExceptionStatus.UnknownError))
                    retorno = ex.Message;
                else
                    using (var stream = ex.Response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            retorno = sr.ReadToEnd();
                        }
                    }
            }
            catch (System.Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }
    }
}