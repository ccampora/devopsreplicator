
namespace copydevops.client
{
    public enum QueryParams
    {
        organization,
        project,
        area,
        resource,
        apiversion
    }


    public class QueryBuilder
    {
        private string organization;
        private string project;
        private string area;
        private string resource;

        private string apiversion;

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

        public QueryBuilder() {}

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

    }
}

