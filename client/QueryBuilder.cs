using Newtonsoft.Json;

namespace copydevops.client
{
    public enum QueryParams
    {
        organization,
        project,
        area,
        resource,
        apiversion,
        requestbody
    }


    public class QueryBuilder
    {
        private string organization;
        private string project;
        private string area;
        private string resource;

        private string apiversion;
        private QueryRequestBody requestbody;

        public QueryBuilder(
            string organization,
            string project,
            string area,
            string resource,
            string apiversion)
        {
            this.organization = organization;
            this.project = project;
            this.area = area;
            this.resource = resource;
            this.apiversion = apiversion;
        }

        public QueryBuilder() { }

        /// <summary>
        /// Set Query params
        /// </summary>
        /// <param name="queryParams"></param>
        /// <param name="value"></param>
        public void SetQueryParams(QueryParams queryParams, string value)
        {
            switch (queryParams)
            {
                case QueryParams.organization:
                    this.organization = value;
                    break;
                case QueryParams.area:
                    this.area = value;
                    break;
                case QueryParams.project:
                    this.project = value;
                    break;
                case QueryParams.resource:
                    this.resource = value;
                    break;
                case QueryParams.apiversion:
                    this.apiversion = value;
                    break;
                default: break;
            }
        }

        /// <summary>
        /// Set Query params
        /// </summary>
        /// <param name="queryParams"></param>
        /// <param name="value"></param>
        public void SetQueryParams(QueryParams queryParams, QueryRequestBody value)
        {
            switch (queryParams)
            {
                case QueryParams.requestbody:
                    this.requestbody = value;
                    break;
            }
        }

        /// <summary>
        /// Return the URI of the query
        /// </summary>
        /// <returns>Query URI</returns>
        public string getQueryAsURI()
        {
            URIFactory urf = new URIFactory();
            if (!isParamSet(QueryParams.project))
            {
                return urf.buildRequestURI(this.organization, this.area, this.resource, this.apiversion);
            }
            else
            {
                return urf.buildRequestURI(this.organization, this.project, this.area, this.resource, this.apiversion);
            }
        }

        /// <summary>
        /// True if the parameter is Set
        /// </summary>
        /// <param name="param"></param>
        /// <returns>True if the parameter is Set</returns>
        private bool isParamSet(QueryParams param)
        {
            switch (param)
            {
                case QueryParams.organization:
                    return this.organization.Length == 0 ? false : true;
                case QueryParams.project:
                    return this.project.Length == 0 ? false : true;
                case QueryParams.area:
                    return this.area.Length == 0 ? false : true;
                case QueryParams.apiversion:
                    return this.apiversion.Length == 0 ? false : true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Get a Json representation 
        /// </summary>
        /// <returns>Body as JSON</returns>
        public string GetQueryRequestBody()
        {
            return JsonConvert.SerializeObject(requestbody);
        }
    }
}