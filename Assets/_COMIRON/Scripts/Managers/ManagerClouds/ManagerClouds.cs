using System.Collections;
using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerClouds
{
	public class ManagerClouds : ManagerBase {
		private SettingsClouds settingsClouds;

		protected override void AwakeInherit() {
			this.settingsClouds = this.GetSettings<SettingsClouds>();
		}

		public ControllerCloud CreateControllerCloud(Vector3 position) {
			return this.CreateController<ControllerCloud>(
				this.settingsClouds.GetControllerCloudPrefab(),
				position
			);
		}
	}
}