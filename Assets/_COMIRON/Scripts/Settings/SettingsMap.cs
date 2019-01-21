using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerMap;
using UnityEngine;

namespace COMIRON.Settings {
	public class SettingsMap : SettingsBase {
		[SerializeField]
		private ControllerGround controllerGroundPrefab;
		
		[Header("Start Position:")]
		[SerializeField, Tooltip("Начальная позиция земли.")]
		private Vector3 groundStartPosition;
		
		[Header("Ground:")]
		[SerializeField, Tooltip("Контроллер земли, количество колонок.")]
		private int groundColumnsCount;
		[SerializeField, Tooltip("Контроллер земли, количество рядов.")]
		private int groundRowsCount;
		
		[SerializeField, Tooltip("Контроллер земли, ширина.")]
		private float groundWidth;
		[SerializeField, Tooltip("Контроллер земли, длина.")]
		private float groundLength;
		
		protected override void AwakeInherit() {
			
		}
		
		public ControllerGround GetControllerGroundPrefab() {
			return this.controllerGroundPrefab;
		}
		
		public Vector3 GetGroundStartPosition() {
			return this.groundStartPosition;
		}
		
		public int GetGroundColumnsCount() {
			return this.groundColumnsCount;
		}
		
		public int GetGroundRowsCount() {
			return this.groundRowsCount;
		}
		
		public float GetGroundWidth() {
			return this.groundWidth;
		}
		
		public float GetGroundLength() {
			return this.groundLength;
		}
	}
}