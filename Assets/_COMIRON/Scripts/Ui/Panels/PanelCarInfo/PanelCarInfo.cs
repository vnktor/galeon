using COMIRON.GameFramework.Ui;
using COMIRON.Managers.ManagerTransport;
using UnityEngine;
using UnityEngine.UI;

namespace COMIRON.Ui.Panels {
	public class PanelCarInfo : PanelBase {
		public event System.Action OnActionButtonCloseClick;

		[SerializeField]
		private ButtonBase buttonClose;

		[SerializeField]
		private Text CarNameText;

		private ControllerCars car;

		protected override void InitializeInherit() {
			this.buttonClose.OnActionClick += delegate {
				if (this.OnActionButtonCloseClick != null) {
					this.OnActionButtonCloseClick();
				}
			};
		}

		public void SetCar(ControllerCars conrollerCar) {
			if (this.car == null) {
				this.car = conrollerCar;
			}
		}

		protected override void EnableInherit() {
			this.CarNameText.text = car.GetNameCars();
		}

		protected override void DisableInherit() {

		}
	}
}