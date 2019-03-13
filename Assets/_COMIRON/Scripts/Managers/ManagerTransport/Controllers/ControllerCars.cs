using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using UnityEngine.EventSystems;
using UnityEngine;

namespace COMIRON.Managers.ManagerTransport {
	public abstract class ControllerCars : ControllerBase, IPointerClickHandler {
		public event System.Action<ControllerCars> OnActionClick;
		private string nameCars;
		private List<Vector3> cornerList;
		private int cornerIndex;
		private bool onCorner = false;
		private float radiusCorners = 4.05f;

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

		public void SetCornerList(List<Vector3> cList) {
			this.cornerList = cList;
		}

		private void Start() {
			for (int i = 0; i < this.cornerList.Count; i++) {
				if (this.cornerList[i] == this.transform.position) {
					this.cornerIndex = i;
				}
			}
		}

		private void Update() {
			if (Vector3.Distance(this.transform.position, GetNextCorner()) < this.radiusCorners) {
				this.onCorner = true;
			} else if (Vector3.Distance(this.transform.position, GetNextCorner()) >= this.radiusCorners && this.onCorner) {
				this.SetNextCorner();
			}

			if (onCorner) { 
				float t = 2 * Mathf.PI * this.radiusCorners/(4 * 5f);
				this.transform.rotation *= Quaternion.Euler(0, 90f / t * Time.deltaTime, 0);
				this.transform.Translate(0,0,5f * Time.deltaTime);
			} else {
				this.transform.localPosition = Vector3.MoveTowards(
					this.transform.localPosition,
					this.GetNextCorner(),
					5f * Time.deltaTime
				);
			}
		}
		
		private Vector3 GetNextCorner() {
			if (this.cornerIndex == 3) {
				return this.cornerList[0];
			} else {
				return this.cornerList[this.cornerIndex + 1];
			}
		}

		private void SetNextCorner() {
			this.cornerIndex++;
			if (this.cornerIndex > 3) {
				this.cornerIndex = 0;
			}
			this.onCorner = false;
		}
	}
}