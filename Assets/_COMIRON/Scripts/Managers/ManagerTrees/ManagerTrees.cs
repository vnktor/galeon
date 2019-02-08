using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerTrees {
	public class ManagerTrees : ManagerBase {
		private SettingsTrees settingsTrees;

		protected override void AwakeInherit() {
			this.settingsTrees = this.GetSettings<SettingsTrees>();
		}

		public ControllerTree01 CreateControllerTree01(Vector3 position) {
			return this.CreateController<ControllerTree01>(
				this.settingsTrees.GetControllerTree01Prefab(),
				position
			);
		}

		public ControllerTree02 CreateControllerTree02(Vector3 position) {
			return this.CreateController<ControllerTree02>(
				this.settingsTrees.GetControllerTree02Prefab(),
				position
			);
		}	
	}
}