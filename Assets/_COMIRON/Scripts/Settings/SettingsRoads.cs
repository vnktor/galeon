using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerRoads;
using UnityEngine;

namespace COMIRON.Settings {
	public class SettingsRoads : SettingsBase {
		[SerializeField]
		private ControllerRoadCorner controllerRoadCornerPrefab;
		[SerializeField]
		private ControllerRoadStraight controllerRoadStraightPrefab;
		
		protected override void AwakeInherit() {
			
		}
		
		public ControllerRoadCorner GetControllerRoadCornerPrefab() {
			return this.controllerRoadCornerPrefab;
		}
		
		public ControllerRoadStraight GetControllerRoadStraightPrefab() {
			return this.controllerRoadStraightPrefab;
		}
	}
}