using System;
namespace copydevops.storage
{
    public class DummyStorageDriver : BaseStorageDriver
    {
        public override void SaveFile(string path, File file)
        {
            Console.WriteLine("Creating file " + 
                file.GetFileName() + 
                "with content:" +
                file.GetFileContent());
        }
                public override File GetFile(string path, string filename)
        {
            throw new NotImplementedException();
        }

        public override string[] GetFileNames(string path)
        {
            throw new NotImplementedException();
        }

        public override void CreateFolder(string path, string foldername)
        {
            throw new NotImplementedException();
        }
    }
}