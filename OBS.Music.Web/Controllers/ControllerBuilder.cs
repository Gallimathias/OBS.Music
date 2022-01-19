using NonSucking.Framework.Extension.IoC;

namespace OBS.Music.Web.Controllers;

public partial class ControllerBuilder : IStartUp
{
    public static void Register(ITypeContainer typeContainer)
    {
        typeContainer.Register<MusicContextController>();
    }
}
