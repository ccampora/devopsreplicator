using System;

namespace copydevops.storage
{
    public class File
    {
        private string filename { get; set;}
        private string content { get; set; }

        public void SetFileName(string filename)
        {
            this.filename = filename;
        } 
        public void SetFileContent(string content)
        {
            this.content = content;
        }

        public string GetFileName()
        {
            return this.filename;
        }
        public string GetFileContent()
        {
            return this.content;
        }
    }
}