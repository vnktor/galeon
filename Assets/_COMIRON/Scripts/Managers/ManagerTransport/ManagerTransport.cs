using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using System.Collections.Generic;
using UnityEngine;

namespace COMIRON.Managers.ManagerTransport {
	public class ManagerTransport : ManagerBase {
		private SettingsTransport settingsTransport;

		protected override void AwakeInherit() {
			this.settingsTransport = this.GetSettings<SettingsTransport>();
		}

		public ControllerCar02 CreateControllerCar02(Vector3 position, string nameCars02, List<Vector3> cornerList) {
			var controllerCar02 = this.CreateController<ControllerCar02>(
				this.settingsTransport.GetControllerCar02Prefab(),
				position
			);
			controllerCar02.SetNameCars(nameCars02);
			controllerCar02.SetCornerList(cornerList);
			return controllerCar02;
		}

		public ControllerCar03 CreateControllerCar03(Vector3 position, string nameCars03, List<Vector3> cornerList) {
			var controllerCar03 = this.CreateController<ControllerCar03>(
				this.settingsTransport.GetControllerCar03Prefab(),
				position
			);
			controllerCar03.SetNameCars(nameCars03);
			controllerCar03.SetCornerList(cornerList);
			return controllerCar03;
		}

		public ControllerCar04 CreateControllerCar04(Vector3 position, string nameCars04, List<Vector3> cornerList) {
			var controllerCar04 = this.CreateController<ControllerCar04>(
				this.settingsTransport.GetControllerCar04Prefab(),
				position
			);
			controllerCar04.SetNameCars(nameCars04);
			controllerCar04.SetCornerList(cornerList);
			return controllerCar04;
		}
	}
}