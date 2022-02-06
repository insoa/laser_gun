using Enums;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Behaviours {
	public sealed class InputServiceBehaviour : MonoBehaviour {
		
		[Inject] private LaserGunBehaviour _laserGunBehaviour;
		
		[SerializeField] private Button _rotationRightButton;
		[SerializeField] private Button _rotationLeftButton;
		[SerializeField] private Button _angleUpButton;
		[SerializeField] private Button _angleDownButton;
		
		private void Start() {
			_rotationRightButton.onClick.AddListener(() => _laserGunBehaviour.SetRotation(ERotationButtonType.Right));
			_rotationLeftButton.onClick.AddListener(() => _laserGunBehaviour.SetRotation(ERotationButtonType.Left));
			_angleUpButton.onClick.AddListener(() => _laserGunBehaviour.SetAngle(EAngleTiltButtonType.Up));
			_angleDownButton.onClick.AddListener(() => _laserGunBehaviour.SetAngle(EAngleTiltButtonType.Down));
		}
	}
}