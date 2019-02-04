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
	}
}