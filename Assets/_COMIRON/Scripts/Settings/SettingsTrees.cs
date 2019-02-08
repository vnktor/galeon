using System.Collections;
using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerTrees;
using UnityEngine;

namespace COMIRON.Settings{
	public class SettingsTrees : SettingsBase{
		[SerializeField]
		private ControllerCtree controllerCtreePrefab;
		[SerializeField]
		private ControllerLtree controllerLtreePrefab;

		protected override void AwakeInherit(){

		}

		public ControllerCtree GetControllerCtreePrefab(){
			return this.controllerCtreePrefab;
		}

		public ControllerLtree GetControllerLtreePrefab(){
			return this.controllerLtreePrefab;
		}
	}
}