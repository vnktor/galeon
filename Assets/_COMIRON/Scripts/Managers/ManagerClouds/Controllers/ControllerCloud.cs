using System.Collections;
using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace COMIRON.Managers.ManagerClouds {
	public class ControllerCloud : ControllerBase, IPointerClickHandler {
		public event System.Action<ControllerCloud> OnActionClick;

		public void OnPointerClick(PointerEventData eventData) {
			if (this.OnActionClick != null) {
				this.OnActionClick(this);
			}
		}

	}
}