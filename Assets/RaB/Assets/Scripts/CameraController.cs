using System.Collections;
using UnityEngine;

namespace Roll_a_Ball {
	public class CameraController : MonoBehaviour {

		public GameObject player;

		private Vector3 offset;

		void Start() {
			this.offset = this.transform.position - this.player.transform.position;
		}

		void LateUpdate() {
			this.transform.position = this.player.transform.position + this.offset;
		}
	}
}