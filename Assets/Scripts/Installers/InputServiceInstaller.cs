using Behaviours;
using UnityEngine;
using Zenject;

namespace Installers {
	public sealed class InputServiceInstaller : MonoInstaller {
		[SerializeField] private InputServiceBehaviour _inputServiceBehaviourPrefab;
		[SerializeField] private Transform _canvas;

		public override void InstallBindings() {
			var inputServiceInstance = Container.InstantiatePrefabForComponent<InputServiceBehaviour>(_inputServiceBehaviourPrefab, _canvas);
			Container.Bind<InputServiceBehaviour>().FromInstance(inputServiceInstance).AsSingle();
		}
	}
}