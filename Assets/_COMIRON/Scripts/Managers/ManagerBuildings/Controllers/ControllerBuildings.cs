using COMIRON.GameFramework.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace COMIRON.Managers.ManagerBuildings {
	public abstract class ControllerBuildings : ControllerBase, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
		public event System.Action<ControllerBuildings> OnActionClick;

		private bool dragged = false;

		private string buildingName;

		public void OnPointerClick(PointerEventData eventData) {
			if (this.OnActionClick != null && !dragged) {
				this.OnActionClick(this);
			}
		}

		public void SetBuildingName(string value) {
			this.buildingName = value;
		}

		public string GetBuildingName() {
			return this.buildingName;
		}

		public void OnDrag(PointerEventData eventData) {
			RaycastHit hit;
			Ray ray = eventData.pressEventCamera.ScreenPointToRay(Input.mousePosition);
			int layerMask = 1 << 9;
			if (Physics.Raycast(ray, out hit, 1000, layerMask)) {
				this.transform.position = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
			}
		}

		public void OnBeginDrag(PointerEventData eventData) {
			this.dragged = true;
		}

		public void OnEndDrag(PointerEventData eventData) {
			this.dragged = false;
		}
	}
}