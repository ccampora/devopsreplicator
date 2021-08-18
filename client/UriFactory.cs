namespace copydevops.client
{
    public class URIFactory
    {
        private const string devopsurl = "https://dev.azure.com";
        /// <summary>
        /// Buil
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public string buildRequestURI(
            string organization,
            string project,
            string area,
            string resource,
            string apiversion)
        {
            string returnURI = "" +
                devopsurl +
                "/" +
                organization +
                "/" +
                project +
                "/_apis/" +
                area +
                "/" +
                resource +
                "?" + apiversion;

            return returnURI;
        }

        public string buildRequestURI(
            string organization,
            string area,
            string resource,
            string apiversion)
        {
            string returnURI = "" +
                devopsurl +
                "/" +
                organization +
                "/_apis/" +
                area +
                "/" +
                resource +
                "?" + apiversion;

            return returnURI;
        }

    }
}