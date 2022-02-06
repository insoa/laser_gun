using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers {
   
    [CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
    public sealed class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller> {
        
        [SerializeField] private RayDatabase _rayDatabase;
        
        public override void InstallBindings() {
            Container.BindInstance(_rayDatabase);
        }
    }
}