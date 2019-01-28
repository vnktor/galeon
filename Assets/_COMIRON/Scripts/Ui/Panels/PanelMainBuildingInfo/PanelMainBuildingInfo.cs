using COMIRON.GameFramework.Ui;
using UnityEngine;

namespace COMIRON.Ui.Panels {
	public class PanelMainBuildingInfo : PanelBase {
		public event System.Action OnActionButtonCloseClick;
		
		[SerializeField]
		private ButtonBase buttonClose;
		
		protected override void InitializeInherit() {
			this.buttonClose.OnActionClick += delegate {
				if (this.OnActionButtonCloseClick != null) {
					this.OnActionButtonCloseClick();
				}
			};
		}
		
		protected override void EnableInherit() {
			
		}
		
		protected override void DisableInherit() {
			
		}
	}
}