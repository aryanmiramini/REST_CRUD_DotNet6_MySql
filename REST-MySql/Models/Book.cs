using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace REST_MySql.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Author { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Material  BookMaterial { get; set; }
        public enum Material
        {
            PaperEdition,
            E_Book,
            
        }


    }
   
}
