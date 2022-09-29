using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace purchase.infra.data.facade.api
{
    public class Http
    {
        public static string Error500 = "Sucedió un inconveniente al procesar su solicitud, por favor vuelva a intentar en unos minutos";
        public static T InvokeWebApiExternal<T>(HttpMethod verb, string url, string jsonData = null, string defaultMediaType = "application/json", string authorizationToken = null, string authorizationMethod = "Bearer", int timeout = 0, Dictionary<string, string> paramHeader = null)
        {
            T response;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(defaultMediaType));
                httpClient.MaxResponseContentBufferSize = (long)int.MaxValue;
                timeout = timeout <= 0 ? 100 : timeout;
                httpClient.Timeout = TimeSpan.FromSeconds((double)timeout);
                HttpRequestMessage request = new HttpRequestMessage(verb, new Uri(url));
                if (authorizationToken != null)
                    request.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);

                if (paramHeader != null)
                {
                    if (paramHeader.Count > 0)
                    {
                        foreach (var valor in paramHeader)
                        {
                            request.Headers.Add(valor.Key, valor.Value);
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(jsonData) && verb != HttpMethod.Get)
                    request.Content = (HttpContent)new StringContent(jsonData, Encoding.UTF8, defaultMediaType);
                try
                {
                    using (HttpResponseMessage result = httpClient.SendAsync(request).Result)
                    {
                        if (result.StatusCode != HttpStatusCode.OK)
                            throw new HttpRequestException(result.StatusCode == HttpStatusCode.InternalServerError ? Http.Error500 : result.ReasonPhrase);
                        using (HttpContent content = result.Content)
                        {
                            JObject jsonResult = JsonConvert.DeserializeObject<JObject>(content.ReadAsStringAsync().Result);
                            response = JsonConvert.DeserializeObject<T>(jsonResult.ToString());


                        }
                    }
                    return response;
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

        }
    }
}
