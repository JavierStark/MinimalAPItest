using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MinimalAPItest
{
    public class Item : IModel
    {
        [Key]
        public string Id { get; set; }
        [JsonProperty("Object")]
        public string? Name { get; set; }

        [JsonPropertyName("Object Level")]
        public int ObjectLevel { get; set; }

        public string Type { get; set; }

        public string Class { get; set; }

        public string Element { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Constitution { get; set; }

        public int Speed { get; set; }

        public int Luck { get; set; }

        [JsonPropertyName("Equipment Power")]
        public int EquipmentPower { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }
    }
}