using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerMap {
	public class ManagerMap : ManagerBase {
		private SettingsMap settingsMap;
		
		protected override void AwakeInherit() {
			this.settingsMap = this.GetSettings<SettingsMap>();
		}
		
		public ControllerGround CreateControllerGround(Vector3 position) {
			return this.CreateController<ControllerGround>(
				this.settingsMap.GetControllerGroundPrefab(),
				position
			);
		}
	}
}