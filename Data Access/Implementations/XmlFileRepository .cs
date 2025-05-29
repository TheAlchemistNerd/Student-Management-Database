using System.Xml.Serialization;
using StudentManagement.Data_Access.Abstractions;

namespace StudentManagement.Data_Access.Implementations
{
    public class XmlFileRepository <T> : AbstractFileRepository<T> where T : class, new()
    {
        private readonly XmlSerializer _serializer;
        public XmlFileRepository(string filePath)
            : base(filePath)
        {
            _serializer = new XmlSerializer(typeof(List<T>));
        }

        protected override async Task<IEnumerable<T>> ReadFromFileAsync()
        {
            using var stream = new FileStream(_filePath, FileMode.Open);
            return (List<T>)_serializer.Deserialize(stream)!;
        }

        protected override async Task WriteToFileAsync(List<T> entities)
        {
            using var stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            _serializer.Serialize(stream, entities);
            await Task.CompletedTask; //XmlSerializer is synchronous
        }
    }
}
