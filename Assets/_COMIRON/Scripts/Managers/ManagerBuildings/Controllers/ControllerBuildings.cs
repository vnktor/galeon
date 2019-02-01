using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Environments;
using COMIRON.GameFramework.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace COMIRON.Managers.ManagerBuildings {
	public class ControllerBuildings : ControllerBase, IPointerClickHandler {
		public event System.Action<ControllerBuildings> OnActionClick;
		
		public string buildingName;

		public void OnPointerClick(PointerEventData eventData) {
			if (this.OnActionClick != null) {
				this.OnActionClick(this);
			}
		}
	}
}