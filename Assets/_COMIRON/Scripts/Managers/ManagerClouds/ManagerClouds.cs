using System.Collections;
using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;
using System;

namespace COMIRON.Managers.ManagerClouds {
	public class ManagerClouds : ManagerBase {
		private SettingsClouds settingsClouds;

		protected override void AwakeInherit() {
			this.settingsClouds = this.GetSettings<SettingsClouds>();
		}

		public ControllerCloud CreateControllerCloud(Vector3 position) {
			ControllerCloud newControllerCloud = this.CreateController<ControllerCloud>(
				this.settingsClouds.GetControllerCloudPrefab(),
				position
			);
			
			newControllerCloud.name = "Cloud_" + Guid.NewGuid().ToString().Substring(1, 4);
			return newControllerCloud;
		}

		public ControllerCloud[] GetCreatedControllerCloud() {
			return this.GetCreatedObjects<ControllerCloud>();
		}
	}
}