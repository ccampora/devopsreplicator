using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace copydevops.client
{
    public class Client : IClient
    {
        HttpClient _DevopsClient = null;
        
        public void Connect()
        {
            this._DevopsClient = new HttpClient();

            this._DevopsClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            this._DevopsClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                    string.Format("{0}:{1}", "", GetPersonalAccessToken()))));
        }

        private string _PersonalAccessToken = "";

        /// <summary>
        /// Set the PAT obtained from the devops project. 
        /// </summary>
        /// <param name="personalaccesstoken">A token obtained from Azure DevOps portal</param>
        public void SetPersonalAccessToken(string personalaccesstoken)
        {
            this._PersonalAccessToken = personalaccesstoken;
        }

        /// <summary>
        /// returns the Personal Access Token
        /// </summary>
        /// <returns></returns>
        private string GetPersonalAccessToken()
        {
            return _PersonalAccessToken;
        }

        /// <summary>
        /// Calls the specified URI
        /// </summary>
        /// <param name="requestUri">The full URI to call</param>
        /// <returns></returns>
        public async Task<string> GetResponseFromUri(string requestUri)
        {
            string responseBody = null;

            using (HttpResponseMessage response = await this._DevopsClient.GetAsync(requestUri))
            {
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }

            return responseBody;
        }
        /// <summary>
        /// Gets the specified query
        /// </summary>
        /// <param name="requestUri">The full URI to call</param>
        /// <returns></returns>
        public async Task<string> GetResponseFromQuery(QueryBuilder query)
        {
            string responseBody = null;

            var data = new StringContent(query.GetQueryRequestBody(), Encoding.UTF8, "application/json");

            // using (HttpResponseMessage response = 
            //     await this._DevopsClient.PostAsync(query.getQueryAsURI(), data))
            using (HttpResponseMessage response = 
                await this._DevopsClient.PostAsync(query.getQueryAsURI(), data))
            {
                //response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }

            return responseBody;
        }
    }
}