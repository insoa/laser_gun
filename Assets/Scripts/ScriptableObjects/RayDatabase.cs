using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "RayDatabase", menuName = "ScriptableObjects/RayDatabase")]
    public sealed class RayDatabase : ScriptableObject {
        public float Power ;
        public float Range;
    }
}
