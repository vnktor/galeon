using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerRoads {
	public class ManagerRoads : ManagerBase {
		private SettingsRoads settingsMap;
		
		protected override void AwakeInherit() {
			this.settingsMap = this.GetSettings<SettingsRoads>();
		}
		
		public ControllerRoadCorner CreateControllerRoadCorner(Vector3 position) {
			return this.CreateController<ControllerRoadCorner>(
				this.settingsMap.GetControllerRoadCornerPrefab(),
				position
			);
		}
		
		public ControllerRoadStraight CreateControllerRoadStraight(Vector3 position) {
			return this.CreateController<ControllerRoadStraight>(
				this.settingsMap.GetControllerRoadStraightPrefab(),
				position
			);
		}
	}
}