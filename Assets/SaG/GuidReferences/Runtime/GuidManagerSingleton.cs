using System;
using UnityEngine;

namespace SaG.GuidReferences
{
    /// <summary>
    /// Provides static interface to communicate with GuidManager implementation.
    /// </summary>
    public static class GuidManagerSingleton
    {
        private static IGuidManager _instance = null;
        // Singleton interface
        public static IGuidManager Instance => _instance ?? (_instance = new GuidManager());
        
        // All the public API is static so you need not worry about creating an instance
        public static bool Add(Guid guid, UnityEngine.Object gameObject)
        {
            return Instance.Add(guid, gameObject);
        }

        public static bool Remove(Guid guid)
        {
            return Instance.Remove(guid);
        }
        
        public static UnityEngine.Object ResolveGuid(Guid guid, Action<UnityEngine.Object> onAddCallback, Action onRemoveCallback)
        {
            return Instance.ResolveGuid(guid, onAddCallback, onRemoveCallback);
        }

        public static UnityEngine.Object ResolveGuid(Guid guid, System.Action onRemoveCallback)
        {
            return Instance.ResolveGuid(guid, null, onRemoveCallback);
        }

        public static UnityEngine.Object ResolveGuid(Guid guid)
        {
            return Instance.ResolveGuid(guid, null, null);
        }

        /// <summary>
        /// Sets guid manager implementation. This is useful if you want to create GuidManger instance by yourself.
        /// This is bad design.
        /// </summary>
        /// <param name="guidManager">IGuidManager instance.</param>
        public static void SetInstance(IGuidManager guidManager)
        {
            if (guidManager == null)
                throw new ArgumentNullException(nameof(guidManager));
            _instance = guidManager;
        }
    }
}