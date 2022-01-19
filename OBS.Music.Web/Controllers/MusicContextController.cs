using Microsoft.AspNetCore.Mvc;
using OBS.Music.Model;

namespace OBS.Music.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MusicContextController : EntityController<MusicContext, ulong>
{
    public MusicContextController(StorageProvider storageProvider) : base(storageProvider)
    {
    }

    [HttpGet("[action]")]
    public IActionResult New()
    {
        var newContext = new MusicContext
        {
            ContextId = Guid.NewGuid()
        };

        return AddOrUpdate(newContext);
    }
}
