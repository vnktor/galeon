using System.Collections;
using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerBuildings;
using UnityEngine;

namespace COMIRON.Settings {
	public class SettingsBuildings : SettingsBase {
		[SerializeField]
		private ControllerHouse controllerHousePrefab;
		[SerializeField]
		private ControllerShop controllerShopPrefab;

		protected override void AwakeInherit() {

		}

		public ControllerHouse GetControllerHousePrefab(string name) {
			var prefab = this.controllerHousePrefab;
			prefab.buildingName = name;
			return prefab;
		}

		public ControllerShop GetControllerShopPrefab(string name) {
			var prefab = this.controllerShopPrefab;
			prefab.buildingName = name;
			return prefab;
		}
	}
}