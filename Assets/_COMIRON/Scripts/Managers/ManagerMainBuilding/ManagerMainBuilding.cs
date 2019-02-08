using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerMainBuilding {
	public class ManagerMainBuilding : ManagerBase {
		private SettingsMainBuilding settingsMainBuilding;
		
		protected override void AwakeInherit() {
			this.settingsMainBuilding = this.GetSettings<SettingsMainBuilding>();
		}
		
		public ControllerMainBuilding CreateControllerMainBuilding(Vector3 position) {
			return this.CreateController<ControllerMainBuilding>(
				this.settingsMainBuilding.GetControllerMainBuildingPrefab(),
				position
			);
		}
	}
}