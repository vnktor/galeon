using COMIRON.GameFramework.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace COMIRON.Ui.Panels {
	public class PanelCloudInfo : PanelBase {
		public event System.Action OnActionButtonCloseClick;
		public string InfoMessage;

		[SerializeField]
		private ButtonBase buttonClose;

		[SerializeField]
		private Text textInfo;

		protected override void InitializeInherit() {
			this.buttonClose.OnActionClick += delegate {
				if (this.OnActionButtonCloseClick != null) {
					this.OnActionButtonCloseClick();
				}
			};
			
		}

		protected override void EnableInherit() {
			this.textInfo.GetComponent<Text>().text = InfoMessage;
		}

		protected override void DisableInherit() {

		}
	}
}