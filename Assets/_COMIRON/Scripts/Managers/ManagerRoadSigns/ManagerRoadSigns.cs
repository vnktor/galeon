using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerRoadSigns {
	public class ManagerRoadSigns : ManagerBase {
		private SettingsRoadSigns settingsRoadSigns;
		
		protected override void AwakeInherit() {
			this.settingsRoadSigns = this.GetSettings<SettingsRoadSigns>();
		}
		
		public ControllerRoadSign01 CreateControllerRoadSign01(Vector3 position, string name) {
			var controller = this.CreateController<ControllerRoadSign01>(
				this.settingsRoadSigns.GetControllerRoadSign01Prefab(),
				position
			);
			controller.SetSignName(name);
			return controller;
		}
		
		public ControllerRoadSign02 CreateControllerRoadSign02(Vector3 position, string name) {
			var controller = this.CreateController<ControllerRoadSign02>(
				this.settingsRoadSigns.GetControllerRoadSign02Prefab(),
				position
			);
			controller.SetSignName(name);
			return controller;
		}
		
		public ControllerRoadSign03 CreateControllerRoadSign03(Vector3 position, string name)
		{
			var controller = this.CreateController<ControllerRoadSign03>(
				this.settingsRoadSigns.GetControllerRoadSign03Prefab(),
				position
			);
			controller.SetSignName(name);
			return controller;
		}
		
		public ControllerRoadSign04 CreateControllerRoadSign04(Vector3 position, string name)
		{
			var controller = this.CreateController<ControllerRoadSign04>(
				this.settingsRoadSigns.GetControllerRoadSign04Prefab(),
				position
			);
			controller.SetSignName(name);
			return controller;
		}
	}
}
