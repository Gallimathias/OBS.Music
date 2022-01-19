using NonSucking.Framework.Extension.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music;

public class StartUp : IStartUp
{
    public static void Register(ITypeContainer typeContainer)
    {
        typeContainer.Register<DatabaseContext>();
        typeContainer.Register<StorageProvider>(InstanceBehaviour.Singleton);
    }
}
