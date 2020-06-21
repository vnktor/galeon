using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerBuildings {
	public class ManagerBuildings : ManagerBase {
		private SettingsBuildings settingsBuildings;
		private int controllerCounter;

		protected override void AwakeInherit() {
			this.controllerCounter = 0;
			this.settingsBuildings = this.GetSettings<SettingsBuildings>();
		}

		public ControllerHouse CreateControllerHouse(Vector3 position, string name) {
			var controller = this.CreateController<ControllerHouse>(
				this.settingsBuildings.GetControllerHousePrefab(),
				position
			);
			controller.SetBuildingName(this.GetControllerName(name));
			return controller;
		}

		public ControllerShop CreateControllerShop(Vector3 position, string name) {
			var controller = this.CreateController<ControllerShop>(
				this.settingsBuildings.GetControllerShopPrefab(),
				position
			);
			controller.SetBuildingName(this.GetControllerName(name));
			return controller;
		}

		private string GetControllerName(string newName) {
			var name = this.settingsBuildings.LoadControllerName(this.controllerCounter.ToString());
			if (name == null) {
				this.settingsBuildings.SaveControllerName(newName, this.controllerCounter.ToString());
				name = newName;
			}
			this.controllerCounter++;
			return name;
		}
	}
}
