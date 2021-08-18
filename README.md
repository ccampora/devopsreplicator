# copydevops
A tool to copy workitems from a devops project

Usage example: 

    using copydevops.client; 
    using copydevops.repository;
    using copydevops.storage;

    namespace copydevops
    {
        class Program
        {
            static void Main(string[] args)
            {
                Client client = new Client(); 
                client.SetPersonalAccessToken("your devops access token");

                QueryBuilder q = new QueryBuilder();
                q.SetQueryParams(QueryParams.organization, "organization name");
                q.SetQueryParams(QueryParams.project, "project name");
                q.SetQueryParams(QueryParams.area, "wit/workitems");
                q.SetQueryParams(QueryParams.resource, "2"); // workitem id
                q.SetQueryParams(QueryParams.apiversion, "api-version=6.1-preview.3");

                string uri = q.getQueryAsURI();
                string result = client.GetResponseFromUri(uri).Result;

                File f = new File();
                f.SetFileName("2.txt");
                f.SetFileContent(result);

                Repository<LocalStorageDriver> localrepo = new Repository<LocalStorageDriver>();
                localrepo.CreateFile(@"C:\Tmp\", f); // this will save a file name 2.txt en C:\Tmp folder with the content of the workitem. 
            }
        }
    }

