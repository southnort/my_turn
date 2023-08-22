using System.Collections;
using System.Collections.Generic;

namespace Game.Entities
{
    internal interface IEntity
    {
        T Get<T>();

        bool TryGet<T>(out T element);
    }
}
