using System.Collections;
using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using COMIRON.Settings;
using UnityEngine;

namespace COMIRON.Managers.ManagerTrees{
	public class ManagerTrees : ManagerBase{
		private SettingsTrees settingsTrees;

		protected override void AwakeInherit(){
			this.settingsTrees = this.GetSettings<SettingsTrees>();
		}

		public ControllerCtree CreateControllerCtree(Vector3 position){
			return this.CreateController<ControllerCtree>(
				this.settingsTrees.GetControllerCtreePrefab(),
				position
			);
		}

		public ControllerLtree CreateControllerLtree(Vector3 position){
			return this.CreateController<ControllerLtree>(
				this.settingsTrees.GetControllerLtreePrefab(),
				position
			);
		}
	}
}
