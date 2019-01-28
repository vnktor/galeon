using COMIRON.GameFramework.Ui;
using UnityEngine;

namespace COMIRON.GameFramework.Links {
	public class LinkPanel : LinkBase {
		[SerializeField]
		private PanelBase panel;
		
		public PanelBase GetPanel() {
			return this.panel;
		}
	}
}