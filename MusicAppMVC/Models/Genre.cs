using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppMVC.Models
{
    public enum Genre
    {
        [Display(Name = "")]
        NONE,
        [Display(Name = "Blues")]
        BLUES,
        [Display(Name = "Classic Rock")]
        CLASSICROCK,
        [Display(Name = "Country")]
        COUNTRY,
        [Display(Name = "Dance")]
        DANCE,
        [Display(Name = "Disco")]
        DISCO,
        [Display(Name = "Funk")]
        FUNK,
        [Display(Name = "Grunge")]
        GRUNGE,
        [Display(Name = "Hip-Hop")]
        HIPHOP,
        [Display(Name = "Jazz")]
        JAZZ,
        [Display(Name = "Metal")]
        METAL,
        [Display(Name = "New Age")]
        NEWAGE,
        [Display(Name = "Oldies")]
        OLDIES,
        [Display(Name = "Other")]
        OTHER,
        [Display(Name = "Pop")]
        POP,
        [Display(Name = "Rhythm and Blues")]
        RHYTHMANDBLUES,
        [Display(Name = "Rap")]
        RAP,
        [Display(Name = "Reggae")]
        REGGAE,
        [Display(Name = "Rock")]
        ROCK,
        [Display(Name = "Techno")]
        TECHNO,
        [Display(Name = "Industrial")]
        INDUSTRIAL,
        [Display(Name = "Alternative")]
        ALTERNATIVE
    }
}
