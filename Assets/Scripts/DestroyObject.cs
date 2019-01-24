using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roll_a_Ball {
	public class DestroyObject : MonoBehaviour {

		void Update() {
			if (Input.GetMouseButtonDown(0)) {
				Destroy(gameObject);
			}
		}
	}
}