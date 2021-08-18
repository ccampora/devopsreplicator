using System;
using copydevops.storage;

namespace copydevops.repository
{
    public class Repository<T> : IRepository<T> 
        where T : IStorageDriver, new()
    {
        T driver = new T();
        public void CreateFile(string path, File file)
        {
            driver.SaveFile(path, file);
        }

        public void CreateFolder(string path, string foldername)
        {
            driver.CreateFolder(path, foldername);
        }
        public File ReadFile(string path, string filename)
        {
            return driver.GetFile(path, filename);
        }
        public string[] ListFiles(string path)
        {
            return driver.GetFileNames(path);
        }
    }
}