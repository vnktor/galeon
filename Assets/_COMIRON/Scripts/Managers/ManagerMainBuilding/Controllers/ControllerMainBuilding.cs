using COMIRON.GameFramework.Core;
using UnityEngine.EventSystems;

namespace COMIRON.Managers.ManagerMainBuilding {
	public class ControllerMainBuilding : ControllerBase, IPointerClickHandler {
		public event System.Action<ControllerMainBuilding> OnActionClick;
		
		public void OnPointerClick(PointerEventData eventData) {
			if (this.OnActionClick != null) {
				this.OnActionClick(this);
			}
		}
	}
}