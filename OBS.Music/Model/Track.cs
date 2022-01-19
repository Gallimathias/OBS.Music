using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music.Model;

public class Track : IndexdEntity<ulong>
{
    public string? Name { get; set; }
    public string? Source { get; set; }
    public string? Licence { get; set; }

    [Required]
    [InverseProperty(nameof(StoredFile.AssignedTrack))]
    public StoredFile? File { get; set; }

    [JsonConverter(typeof(RefListConverter))]
    public ICollection<PlayList>? PlayLists { get; set; }

    public MusicContext? Context { get; set; }
}
