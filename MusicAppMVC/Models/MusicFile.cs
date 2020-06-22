using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicAppMVC.Models
{
    public class MusicFile
    {
        [Key]
        public int Id { get; set; }
        public string FilePath { get; set; }
        public bool IsChecked { get; set; }
        public string AlbumArtPath { get; set; }

        [Required]
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        // Displays the enum as its string value instead of an integer
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Genre Genre { get; set; }
    }
}
