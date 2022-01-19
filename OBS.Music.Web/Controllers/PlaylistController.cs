using Microsoft.AspNetCore.Mvc;
using OBS.Music.Model;
using System.Net;

namespace OBS.Music.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaylistController : EntityController<PlayList, ulong>
{
    public PlaylistController(StorageProvider storageProvider) : base(storageProvider)
    {
    }

    public IActionResult Randomize(ulong playListId)
    {
        var playList = storageProvider.Find<PlayList, ulong>(playListId);

        if (playList is null)
            return StatusCode((int)HttpStatusCode.NotFound);

        return Ok(Randomizer.Randomize(playList));
    }
}
