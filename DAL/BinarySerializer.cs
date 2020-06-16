using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DAL.Interfaces;

namespace DAL
{
    public class BinarySerializer : ISerializer
    {
        private readonly BinaryFormatter _formatter = new BinaryFormatter();

        public void Serialize(string path, object obj)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            _formatter.Serialize(fs, obj);
        }

        public object Deserialize(string path)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            var obj = _formatter.Deserialize(fs);
            return obj;
        }
    }
}