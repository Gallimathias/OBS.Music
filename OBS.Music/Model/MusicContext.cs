using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OBS.Music.Model;

[Index(nameof(ContextId), IsUnique = true)]
public class MusicContext : IndexdEntity<ulong>
{
    [Required]
    public Guid ContextId { get; set; }

    [InverseProperty(nameof(PlayList.Context))]
    [JsonConverter(typeof(RefListConverter))]
    public ICollection<PlayList>? PlayLists { get; set; }

    [InverseProperty(nameof(Track.Context))]
    [JsonConverter(typeof(RefListConverter))]
    public ICollection<Track>? Tracks { get; set; }
}
