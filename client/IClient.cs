using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace copydevops.client
{
    interface IClient
    {
        public void SetPersonalAccessToken(string personalaccesstoken);
        public Task<string> GetResponseFromUri(string _requestUri);
        public string getResponse();
    }
}