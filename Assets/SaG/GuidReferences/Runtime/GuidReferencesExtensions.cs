using System;
using UnityEngine;

namespace SaG.GuidReferences
{
    public static class GuidReferencesExtensions
    {
        public static UnityEngine.Object ResolveGuid(this IGuidManager guidManager, Guid guid) =>
            guidManager.ResolveGuid(guid, null, null);
        
        public static UnityEngine.Object ResolveGuid(this IGuidManager guidManager, Guid guid, Action<UnityEngine.Object> onAddedCallback) =>
            guidManager.ResolveGuid(guid, onAddedCallback, null);
        
        public static UnityEngine.Object ResolveGuid(this IGuidManager guidManager, Guid guid, Action onRemovedCallback) =>
            guidManager.ResolveGuid(guid, null, onRemovedCallback);
    }
}