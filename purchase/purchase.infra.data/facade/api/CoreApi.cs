using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace purchase.infra.data.facade.api
{
    public abstract class CoreApi
    {
        protected T CallApiExternal<T>(HttpMethod verb, string urlAction, object parameters, int timeout = 0, string authorizationToken = null)
        {
            HttpMethod verb1 = verb;
            string url = urlAction;
            string jsonParameters = this.GetJsonParameters(parameters);
            string defaultMediaType = "application/json";
            int num = timeout;
            string authorizationToken1 = authorizationToken;
            string authorizationMethod = "Bearer";
            int timeout1 = num;

            return Http.InvokeWebApiExternal<T>(verb1, url, jsonParameters, defaultMediaType, authorizationToken1, authorizationMethod, timeout1);
        }
        protected string GetJsonParameters(object request)
        {
            return JsonConvert.SerializeObject(request);
        }
    }
}
