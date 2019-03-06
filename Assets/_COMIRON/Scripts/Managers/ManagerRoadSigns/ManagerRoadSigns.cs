using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerRoadSigns {
	public class ManagerRoadSigns : ManagerBase {
		private SettingsRoadSigns SettingsRoadSigns;
		
		protected override void AwakeInherit() {
			this.SettingsRoadSigns = this.GetSettings<SettingsRoadSigns>();
		}
		
		public ControllerRoadSign01 CreateControllerRoadSign01(Vector3 position) {
			return this.CreateController<ControllerRoadSign01>(
				this.SettingsRoadSigns.GetControllerRoadSign01Prefab(),
				position
			);
		}
		
		public ControllerRoadSign02 CreateControllerRoadSign02(Vector3 position) {
			return this.CreateController<ControllerRoadSign02>(
				this.SettingsRoadSigns.GetControllerRoadSign02Prefab(),
				position
			);
		}
		
		public ControllerRoadSign03 CreateControllerRoadSign03(Vector3 position) {
			return this.CreateController<ControllerRoadSign03>(
				this.SettingsRoadSigns.GetControllerRoadSign03Prefab(),
				position
			);
		}
		
		public ControllerRoadSign03 CreateControllerRoadSign04(Vector3 position) {
			return this.CreateController<ControllerRoadSign03>(
				this.SettingsRoadSigns.GetControllerRoadSign03Prefab(),
				position
			);
		}
	}
}
