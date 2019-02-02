using COMIRON.GameFramework.Core;
using UnityEngine.EventSystems;

namespace COMIRON.Managers.ManagerBuildings {
	public abstract class ControllerBuildings : ControllerBase, IPointerClickHandler {
		public event System.Action<ControllerBuildings> OnActionClick;

		private string buildingName;

		public string BuildingName {
			get {
				return buildingName;
			}
			set {
				if (this.buildingName == null) {
					this.buildingName = value;
				}
			}
		}

		public void OnPointerClick(PointerEventData eventData) {
			if (this.OnActionClick != null) {
				this.OnActionClick(this);
			}
		}
	}
}