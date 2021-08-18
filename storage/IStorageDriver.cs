namespace copydevops.storage
{
    public interface IStorageDriver
    {
        public void SaveFile(string path, File file);
        public File GetFile(string path, string filename);
        public string[] GetFileNames(string path);
        public void CreateFolder(string path, string foldername);
    }
}