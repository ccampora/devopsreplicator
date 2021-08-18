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
                client.Connect();

                // Example 1: Get workitem ID 2
                QueryBuilder q = new QueryBuilder();
                q.SetQueryParams(QueryParams.organization, "your organization");
                q.SetQueryParams(QueryParams.project, "your project");
                q.SetQueryParams(QueryParams.area, "wit/workitems");
                q.SetQueryParams(QueryParams.resource, "workitem id");
                q.SetQueryParams(QueryParams.apiversion, "api-version=6.1-preview.3");

                string uri = q.getQueryAsURI();
                string result = client.GetResponseFromUri(uri).Result;

                File f = new File();
                f.SetFileName("2.txt");
                f.SetFileContent(result);

                Repository<LocalStorageDriver> localrepo = new Repository<LocalStorageDriver>();
                localrepo.CreateFile(@"C:\Tmp\", f); // this will save a file name 2.txt en C:\Tmp folder with the content of the workitem. 
            
                // Example 2: Create a new query and retrieve all workitems
                QueryRequestBody body;
                body.name = "All workitems";
                body.wiql = "Select [System.Id], [System.Title], [System.State] From WorkItems";


                q.SetQueryParams(QueryParams.area, "wit/queries");
                q.SetQueryParams(QueryParams.resource, "Shared Queries");
                q.SetQueryParams(QueryParams.apiversion, "api-version=6.0");
                q.SetQueryParams(QueryParams.requestbody, body);

                uri = q.getQueryAsURI();
                result = client.GetResponseFromQuery(q).Result;

                f = new File();
                f.SetFileName("3.txt");
                f.SetFileContent(result);
                localrepo.CreateFile(@"C:\Tmp\", f);
            }
        }
    }

run using `dotnet run`
