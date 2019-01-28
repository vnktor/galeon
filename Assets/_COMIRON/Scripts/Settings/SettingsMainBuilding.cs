using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerMainBuilding;
using UnityEngine;

namespace COMIRON.Settings {
	public class SettingsMainBuilding : SettingsBase {
		[SerializeField]
		private ControllerMainBuilding controllerMainBuilding;
		
		protected override void AwakeInherit() {
			
		}
		
		public ControllerMainBuilding GetControllerMainBuildingPrefab() {
			return this.controllerMainBuilding;
		}
	}
}