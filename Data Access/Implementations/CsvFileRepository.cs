using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using StudentManagement.Data_Access.Abstractions;


namespace StudentManagement.Data_Access.Implementations
{
    public class CsvFileRepository<T> : AbstractFileRepository<T> where T : class, new()
    {

        private readonly CsvConfiguration _config;

        public CsvFileRepository(string filePath)
            : base(filePath)
        {
            _config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };
        }

        protected override async Task<IEnumerable<T>> ReadFromFileAsync()
        {
            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, _config);
            return await csv.GetRecordsAsync<T>().ToListAsync();
        }

        protected override async Task WriteToFileAsync(List<T> entities)
        {
            using var writer = new StreamWriter(_filePath);
            using var csv = new CsvWriter(writer, _config);
            await csv.WriteRecordsAsync(entities);
        }
    }
}
