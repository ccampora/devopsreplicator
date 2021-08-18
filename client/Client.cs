using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace copydevops.client
{
    public class Client : IClient
    {
        HttpClient _DevopsClient = null;
        
        private string response = ""; 

        public Client()
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
            if (requestUri == null || requestUri.Length == 0)
            {
                this.response = "";
            }
            string responseBody = null;

            using (HttpResponseMessage response = await this._DevopsClient.GetAsync(requestUri))
            {
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            this.response = responseBody;

            return responseBody;
        }

        public string getResponse()
        {
            return this.response;
        }
    }
}