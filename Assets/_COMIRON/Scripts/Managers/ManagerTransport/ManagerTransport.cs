using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerTransport {
	public class ManagerTransport : ManagerBase {
		private SettingsTransport settingsTransport;

		protected override void AwakeInherit() {
			this.settingsTransport = this.GetSettings<SettingsTransport>();
		}

		public ControllerCar02 CreateControllerCar02(Vector3 position) {
			return this.CreateController<ControllerCar02>(
				this.settingsTransport.GetControllerCar02Prefab(),
				position
			);
		}

		public ControllerCar03 CreateControllerCar03(Vector3 position) {
			return this.CreateController<ControllerCar03>(
				this.settingsTransport.GetControllerCar03Prefab(),
				position
			);
		}

		public ControllerCar04 CreateControllerCar04(Vector3 position) {
			return this.CreateController<ControllerCar04>(
				this.settingsTransport.GetControllerCar04Prefab(),
				position
			);
		}
	}
}