using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AAIY.Data_Access
{
    class LocalFiles
    {
        private const string _FolderName = "AAIY";

        public static void Create(Object toSave, string fileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Byte[] toWrite = null;

            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, toSave);
                toWrite = ms.ToArray();
            }

            using (var fs = File.Create(Path.Combine(dir, _FolderName, fileName)))
            {
                fs.Write(toWrite, 0, toWrite.Length);

            }
        }

        public static Object Read(string fileName)
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var rawFile = File.ReadAllBytes(Path.Combine(dir, _FolderName, fileName));

            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(rawFile, 0, rawFile.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        public static void Delete(string fileName)
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            File.Delete(Path.Combine(dir, _FolderName, fileName));
        }
    }
}
