using System.Collections;
using UnityEngine;

namespace Roll_a_Ball {
	public class Rotator : MonoBehaviour {

		void Update() {
			this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
		}
	}
}