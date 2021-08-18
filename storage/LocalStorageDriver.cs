using System; 
using System.IO;

namespace copydevops.storage
{
    public class LocalStorageDriver : BaseStorageDriver
    {
        public override void SaveFile(string path, File file)
        {


            FileStream fParameter = new FileStream(path + file.GetFileName(), FileMode.Create, FileAccess.Write);  
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);  
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);  
            m_WriterParameter.Write(file.GetFileContent());  
            m_WriterParameter.Flush();  
            m_WriterParameter.Close(); 
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