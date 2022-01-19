using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music.Model;

public class StoredFile : IndexdEntity<ulong>
{
    [Required(AllowEmptyStrings = false)]
    public string? OriginName { get; set; }
    public string? Extension { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? StoredPath { get; set; }

    [InverseProperty(nameof(Track.File))]
    public Track? AssignedTrack { get; set; }
}
