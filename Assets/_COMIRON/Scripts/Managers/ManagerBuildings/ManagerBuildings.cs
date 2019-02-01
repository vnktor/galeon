using System.Collections;
using System.Collections.Generic;
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
			return this.CreateController<ControllerHouse>(
				this.settingsBuildings.GetControllerHousePrefab(name),
				position
			);
		}

		public ControllerShop CreateControllerShop(Vector3 position, string name) {
			return this.CreateController<ControllerShop>(
				this.settingsBuildings.GetControllerShopPrefab(name),
				position
			);
		}
	}
}
