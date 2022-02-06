using System;
using Enums;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Behaviours {
	public sealed class LaserGunBehaviour : MonoBehaviour {
		[Inject] private RayDatabase _rayDatabase;
		[SerializeField] private Transform _gunBarrel;
		[SerializeField] private float moveSpeed;
		[SerializeField] private LineRenderer _line;

		public int reflections;
		private RaycastHit hit;

		private void FixedUpdate() {
			LaserCast(_gunBarrel.position, _gunBarrel.transform.up);
		}

		public void SetRotation(ERotationButtonType type) {
			transform.rotation *= type switch {
				ERotationButtonType.Right => Quaternion.AngleAxis(moveSpeed, Vector3.up),
				ERotationButtonType.Left => Quaternion.AngleAxis(-moveSpeed, Vector3.up),
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}

		public void SetAngle(EAngleTiltButtonType type) {
			_gunBarrel.transform.rotation *= type switch {
				EAngleTiltButtonType.Up => Quaternion.AngleAxis(moveSpeed, Vector3.left),
				EAngleTiltButtonType.Down => Quaternion.AngleAxis(-moveSpeed, Vector3.left),
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}


		//Работает как нужно, но это плохая реализация, если посидеть подольше нашел бы решения получше
		//не приходилось нормально работать с лучами
		private void LaserCast(Vector3 startPosition, Vector3 direction) {
			var range = _rayDatabase.Range;
			var power = _rayDatabase.Power;
			var ray = new Ray(startPosition, direction);

			_line.positionCount = 1;
			_line.SetPosition(0, transform.position);

			for (var i = 0; i < reflections; i++) {
				if (Physics.Raycast(ray.origin, ray.direction, out hit, range)) {
					_line.positionCount += 1;
					_line.SetPosition(_line.positionCount - 1, hit.point);
					if (hit.collider.CompareTag("Reflective")) {
						if (power > hit.collider.GetComponent<ReflectiveObject>().AbsorptionCoefficient) {
							range -= Vector3.Distance(ray.origin, hit.point);
							ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
						}
					}
					if (!hit.collider.CompareTag("Reflective"))
						break;
				} else {
					_line.positionCount += 1;
					_line.SetPosition(_line.positionCount - 1, ray.origin + ray.direction * range);
				}
			}
		}
	}
}