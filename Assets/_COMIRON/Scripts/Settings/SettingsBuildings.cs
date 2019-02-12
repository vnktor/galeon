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
		
		public ControllerHouse GetControllerHousePrefab() {
			return this.controllerHousePrefab;
		}
		
		public ControllerShop GetControllerShopPrefab() {
			return this.controllerShopPrefab;
		}

		public string LoadControllerName(string slotName) {
			return this.GetPref<string>(Buildings.All, null, slotName);
		}

		public void SaveControllerName(string name, string slotName) {
			this.SetPref(Buildings.All, name, slotName);
		}

		enum Buildings {
			All,
			House,
			Shop
		}
	}
}