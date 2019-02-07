using COMIRON.GameFramework.Core;
using UnityEngine.EventSystems;

namespace COMIRON.Managers.ManagerBuildings {
	public abstract class ControllerBuildings : ControllerBase, IPointerClickHandler {
		public event System.Action<ControllerBuildings> OnActionClick;
		
		private string buildingName;
		
		public void OnPointerClick(PointerEventData eventData) {
			if (this.OnActionClick != null) {
				this.OnActionClick(this);
			}
		}
		
		public void SetBuildingName(string value) {
			this.buildingName = value;
		}
		
		public string GetBuildingName() {
			return this.buildingName;
		}
	}
}