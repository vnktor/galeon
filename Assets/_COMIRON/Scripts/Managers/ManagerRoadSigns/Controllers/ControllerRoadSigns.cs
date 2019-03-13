using COMIRON.GameFramework.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace COMIRON.Managers.ManagerRoadSigns {
	public abstract class ControllerRoadSigns : ControllerBase, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
		public event System.Action<ControllerRoadSigns> OnActionClick;
		
		private bool dragged = false;
		
		private string signName;
		
		public void OnPointerClick(PointerEventData eventData) {
			if (this.OnActionClick != null && !dragged) {
				this.OnActionClick(this);
			}
		}
		
		public void SetSignName(string value) {
			this.signName = value;
		}
		
		public string GetSignName() {
			return this.signName;
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