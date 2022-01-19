using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music;

public static class GenericCaster<TFrom, TTo>
{
    public static Func<TFrom, TTo> Cast { get; }
    static GenericCaster()
    {
        var param = Expression.Parameter(typeof(TFrom), "tFrom");
        Cast = Expression.Lambda<Func<TFrom, TTo>>(Expression.Convert(param, typeof(TTo)), param).Compile();
    }
}
