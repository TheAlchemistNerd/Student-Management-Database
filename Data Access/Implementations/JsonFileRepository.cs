using System.Text.Json;
using StudentManagement.Data_Access.Abstractions;

namespace StudentManagement.Data_Access.Implementations
{
    public class JsonFileRepository <T>: AbstractFileRepository<T> where T : class, new()
    {   
        public JsonFileRepository(string filePath) 
            : base(filePath)
        {
    
        }

        protected override async Task<IEnumerable<T>> ReadFromFileAsync()
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ??
                new List<T>();
        }

        protected override async Task WriteToFileAsync(List<T> entities)
        {

            var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
            var json = JsonSerializer.Serialize(entities, options);
            await File.WriteAllTextAsync(_filePath, json);
        }
        
    }
}
