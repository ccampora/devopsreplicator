using System;

namespace copydevops.storage
{
    public abstract class BaseStorageDriver : IStorageDriver
    {
        public abstract void SaveFile(string path, File file);

        public abstract File GetFile(string path, string filename);

        public abstract string[] GetFileNames(string path);

        public abstract void CreateFolder(string path, string foldername);
    }
}