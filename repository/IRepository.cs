using System;
using copydevops.storage;

namespace copydevops.repository
{
    interface IRepository<T> 
        where T : IStorageDriver
    {
        /// <summary>
        /// Creates a File in the specified path
        /// </summary>
        /// <param name="path">path where to create the file</param>
        /// <param name="file">File object instance</param>
        public void CreateFile(string path, File file);
        /// <summary>
        /// Create a new folder
        /// </summary>
        /// <param name="path">path where to create the folder</param>
        /// <param name="foldername">name of the folder</param>
        public void CreateFolder(string path, string foldername); 
        /// <summary>
        /// Reads and return a File object. 
        /// </summary>
        /// <param name="path">path to read</param>
        /// <param name="filename">name of the file</param>
        /// <returns>File object instance</returns>
        public File ReadFile( string path, string filename);
        /// <summary>
        /// List all files and folders in folder on non-recursive manner
        /// </summary>
        /// <param name="path">path to read</param>
        /// <returns></returns>
        public string[] ListFiles(string path);
    }
}