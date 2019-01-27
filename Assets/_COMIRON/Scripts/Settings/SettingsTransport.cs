using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerTransport;
using UnityEngine;

namespace COMIRON.Settings {
	public class SettingsTransport : SettingsBase
	{
		[SerializeField]
		private ControllerCar02 controllerCar02Prefab;
		[SerializeField]
		private ControllerCar03 controllerCar03Prefab;
		[SerializeField]
		private ControllerCar04 controllerCar04Prefab;

		protected override void AwakeInherit() {

		}

		public ControllerCar02 GetControllerCar02Prefab() {
			return this.controllerCar02Prefab;
		}

		public ControllerCar03 GetControllerCar03Prefab() {
			return this.controllerCar03Prefab;
		}

		public ControllerCar04 GetControllerCar04Prefab() {
			return this.controllerCar04Prefab;
		}
	}
}