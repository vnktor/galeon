using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerBuildings {
	public class ManagerBuildings : ManagerBase {
		private SettingsBuildings settingsBuildings;

		protected override void AwakeInherit() {
			this.settingsBuildings = this.GetSettings<SettingsBuildings>();
		}

		public ControllerHouse CreateControllerHouse(Vector3 position, string name) {
			var controller = this.CreateController<ControllerHouse>(
				this.settingsBuildings.GetControllerHousePrefab(),
				position
			);
			controller.SetBuildingName(name);
			return controller;
		}

		public ControllerShop CreateControllerShop(Vector3 position, string name) {
			var controller = this.CreateController<ControllerShop>(
				this.settingsBuildings.GetControllerShopPrefab(),
				position
			);
			controller.SetBuildingName(name);
			return controller;
		}
	}
}
