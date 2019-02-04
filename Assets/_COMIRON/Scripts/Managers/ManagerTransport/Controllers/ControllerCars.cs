using COMIRON.GameFramework.Core;
using UnityEngine.EventSystems;

namespace COMIRON.Managers.ManagerTransport
{
	public abstract class ControllerCars : ControllerBase, IPointerClickHandler {
		public event System.Action<ControllerCars> OnActionClick;

		private string nameCars;

		//public string NameCars { get; set; }
		public void SetNameCars(string name) {
			this.nameCars = name;
		}

		public string GetNameCars() {
			return this.nameCars;
		}


		public void OnPointerClick(PointerEventData eventData) {
			if (this.OnActionClick != null) {
				this.OnActionClick(this);
			}
		}
	}
}