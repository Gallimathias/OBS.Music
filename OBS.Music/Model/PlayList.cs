using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music.Model;

[Index(nameof(Name), IsUnique = true)]
public class PlayList : IndexdEntity<ulong>
{
    [Required(AllowEmptyStrings = false)]
    public string? Name { get; set; }

    [InverseProperty(nameof(Track.PlayLists))]
    [JsonConverter(typeof(RefListConverter))]
    public ICollection<Track>? Tracks { get; set; }

    public MusicContext? Context { get; set; }
}
