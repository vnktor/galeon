using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerRoadSigns;
using UnityEngine;

namespace COMIRON.Settings {
	public class SettingsRoadSigns : SettingsBase {
		[SerializeField]
		private ControllerRoadSign01 ControllerRoadSign01Prefab;
		[SerializeField]
		private ControllerRoadSign02 ControllerRoadSign02Prefab;
		[SerializeField]
		private ControllerRoadSign03 ControllerRoadSign03Prefab;
		[SerializeField]
		private ControllerRoadSign04 ControllerRoadSign04Prefab;
		
		protected override void AwakeInherit() {
		
		}
		
		public ControllerRoadSign01 GetControllerRoadSign01Prefab() {
			return this.ControllerRoadSign01Prefab;
		}
		
		public ControllerRoadSign02 GetControllerRoadSign02Prefab() {
			return this.ControllerRoadSign02Prefab;
		}
		
		public ControllerRoadSign03 GetControllerRoadSign03Prefab() {
			return this.ControllerRoadSign03Prefab;
		}
		
		public ControllerRoadSign04 GetControllerRoadSign04Prefab() {
			return this.ControllerRoadSign04Prefab;
		}
	}
}
