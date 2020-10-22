using UnityEngine;
using UnityEngine.Profiling;

namespace SaG.GuidReferences.Samples
{
    public class TestCrossScene : MonoBehaviour
    {
        [GuidReferenceType(typeof(GameObject))]
        public GuidReference crossSceneReference = new GuidReference();

        [GuidReferenceType(typeof(Light))]
        public GuidReference lightReference = new GuidReference();

        public Light l;

        public BehaviourToGuidDictionary dict = new BehaviourToGuidDictionary();
        public SerializableGuid g;

        private Renderer cachedRenderer;

        void Awake()
        {
            // set up a callback when the target is destroyed so we can remove references to the destroyed object
            crossSceneReference.Removed += ClearCache;
            lightReference.Added += light => (light as Light).color = Color.red;
        }

        void Update () 
        {
            if (lightReference.reference != null)
                l = lightReference.reference as Light;

            // simple example looking for our reference and spinning both if we get one.
            // due to caching, this only causes a dictionary lookup the first time we call it, so you can comfortably poll. 
            if (crossSceneReference.reference != null)
            {
                transform.Rotate(new Vector3(0, 1, 0), 10.0f * Time.deltaTime);

                if (cachedRenderer == null)
                {
                    cachedRenderer = crossSceneReference.reference as Renderer;
                }

                if (cachedRenderer != null)
                {
                    cachedRenderer.gameObject.transform.Rotate(new Vector3(0, 1, 0), 10.0f * Time.deltaTime, Space.World);
                }

            }

            // added a performance test if you want to see. Most cost is in the profiling tags.
            //TestPerformance();
        }

        void ClearCache()
        {
            cachedRenderer = null;
        }

        void TestPerformance()
        {
            UnityEngine.Object derefTest = null;

            for (int i = 0; i < 10000; ++i)
            {
                Profiler.BeginSample("Guid Resolution");
                derefTest = crossSceneReference.reference;
                Profiler.EndSample();
            }
        
        }
   
    }
}
