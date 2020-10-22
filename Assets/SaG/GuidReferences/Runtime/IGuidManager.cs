using System;
using UnityEngine;

namespace SaG.GuidReferences
{
    public interface IGuidManager
    {
        bool Add(Guid guid, UnityEngine.Object gameObject);

        bool Remove(Guid guid);

        UnityEngine.Object ResolveGuid(Guid guid, Action<UnityEngine.Object> onAddCallback, Action onRemoveCallback);
    }
}