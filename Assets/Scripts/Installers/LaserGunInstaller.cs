using Behaviours;
using UnityEngine;
using Zenject;

namespace Installers {
	public sealed class LaserGunInstaller : MonoInstaller {
		
		[SerializeField] private LaserGunBehaviour _laserGunBehaviour;

		public override void InstallBindings() {
			var laserGunInstance = Container.InstantiatePrefabForComponent<LaserGunBehaviour>(_laserGunBehaviour);
			Container.Bind<LaserGunBehaviour>().FromInstance(laserGunInstance).AsSingle();
		}
	}
}