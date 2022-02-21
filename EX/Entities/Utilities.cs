using Newtonsoft.Json.Serialization;
using System.Text.Json;
using EX.Controllers;

namespace EX.Entities
{
    public class Utilities
    {
        string database = Environment.CurrentDirectory + "\\database.json";
        private readonly ILogger<Utilities> _logger;

        public Utilities(ILogger<Utilities> logger)
        {
            _logger = logger;
            if (!File.Exists(database))
                File.WriteAllText(database, "");
        }

        public List<City> Deserializer()
        {
            using (StreamReader _reader = new StreamReader(database))
            {
                _logger.LogInformation($"Trying to read file {database}");
                string data = _reader.ReadToEnd();
                if (String.IsNullOrEmpty(data))
                    return new List<City>();
            }
            return JsonSerializer.Deserialize<List<City>>(database);
        }

        public void Serializer(City city)
        {
            _logger.LogInformation($"Trying to write file {database}");
            try
            {
                using (StreamWriter _writer = new StreamWriter(database, false))
                {
                    _writer.Write(JsonSerializer.Serialize(city));
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
