using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerTrees;
using UnityEngine;

namespace COMIRON.Settings {
	public class SettingsTrees : SettingsBase
	{
		[SerializeField]
		private ControllerTree01 controllerTree01Prefab;
		[SerializeField]
		private ControllerTree02 controllerTree02Prefab;

		protected override void AwakeInherit() {

		}

		public ControllerTree01 GetControllerTree01Prefab() {
			return this.controllerTree01Prefab;
		}

		public ControllerTree02 GetControllerTree02Prefab() {
			return this.controllerTree02Prefab;
		}
	}
}