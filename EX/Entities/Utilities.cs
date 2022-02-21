using Newtonsoft.Json.Serialization;
using System.Text.Json;
using EX.Controllers;

namespace EX.Entities
{
    public class Utilities
    {
        string database = @$"{Environment.CurrentDirectory}\database.json";
        private readonly ILogger<Utilities> _logger;

        public Utilities(ILogger<Utilities> logger)
        {
            _logger = logger;
            if (!File.Exists(database))
                File.WriteAllText(database, "");
        }

        public List<City> Deserializer()
        {
            _logger.LogInformation($"Trying to read file {database}");
            string data;
            using (StreamReader _reader = new StreamReader(database))
            {
                data = _reader.ReadToEnd();
                if (String.IsNullOrEmpty(data))
                    return new List<City>();
            }
            return JsonSerializer.Deserialize<List<City>>(data);
        }

        public void Serializer(List<City> cities)
        {
            _logger.LogInformation($"Trying to write file {database}");
            try
            {
                using (StreamWriter _writer = new StreamWriter(database, append: false))
                {
                    _writer.Write(JsonSerializer.Serialize(cities));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
