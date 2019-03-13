using COMIRON.GameFramework.Ui;
using COMIRON.Managers.ManagerRoadSigns;
using UnityEngine;
using UnityEngine.UI;

namespace COMIRON.Ui.Panels {
	public class PanelRoadSignsInfo : PanelBase {
		public event System.Action OnActionButtonCloseClick;
		
		[SerializeField]
		private ButtonBase buttonClose;
		[SerializeField]
		private Text infoContainer;
		
		private ControllerRoadSigns sign;
		
		protected override void InitializeInherit() {
			this.buttonClose.OnActionClick += delegate {
				if (this.OnActionButtonCloseClick != null) {
					this.OnActionButtonCloseClick();
				}
			};
		}
		
		public void SetSign(ControllerRoadSigns newSign) {
			if (this.sign == null) {
				this.sign = newSign;
			}
		}
		
		protected override void EnableInherit() {
			this.infoContainer.text = sign.GetSignName();
		}
		
		protected override void DisableInherit() {
		}
	}
}