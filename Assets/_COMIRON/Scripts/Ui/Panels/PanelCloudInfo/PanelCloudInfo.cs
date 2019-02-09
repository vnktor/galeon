using COMIRON.GameFramework.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace COMIRON.Ui.Panels {
	public class PanelCloudInfo : PanelBase {
		public event System.Action OnActionButtonCloseClick;
		public string infoMessage;

		[SerializeField]
		private ButtonBase buttonClose;

		[SerializeField]
		private Text textPanelCloudInfo;

		protected override void InitializeInherit() {
			this.buttonClose.OnActionClick += delegate {
				if (this.OnActionButtonCloseClick != null) {
					this.OnActionButtonCloseClick();
				}
			};
			
		}

		protected override void EnableInherit() {
			this.textPanelCloudInfo.GetComponent<Text>().text = infoMessage;
		}

		protected override void DisableInherit() {

		}
	}
}