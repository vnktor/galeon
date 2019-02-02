using COMIRON.GameFramework.Ui;
using COMIRON.Managers.ManagerBuildings;
using UnityEngine;
using UnityEngine.UI;

namespace COMIRON.Ui.Panels {
	public class PanelBuildingsInfo : PanelBase {
		public event System.Action OnActionButtonCloseClick;

		[SerializeField]
		private ButtonBase buttonClose;
		[SerializeField]
		private Text text;

		private ControllerBuildings building;

		protected override void InitializeInherit() {
			this.buttonClose.OnActionClick += delegate {
				if (this.OnActionButtonCloseClick != null) {
					this.OnActionButtonCloseClick();
				}
			};
		}

		public void SetBuilding(ControllerBuildings newBuilding) {
			if (this.building == null) {
				this.building = newBuilding;
			}
		}

		protected override void EnableInherit() {
			text.text = building.BuildingName;
		}

		protected override void DisableInherit() {
			
		}
	}
}