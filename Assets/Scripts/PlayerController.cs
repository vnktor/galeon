using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Roll_a_Ball {
	public class PlayerController : MonoBehaviour {

		public float speed;
		public Text countText;
		public Text winText;

		private Rigidbody rb;
		private int count;

		private void Start() {
			this.rb = GetComponent<Rigidbody>();
			Debug.Log("this.rb" + this.rb);
			this.count = 0;
			SetCountText();
			this.winText.text = "";
		}

		private void FixedUpdate() {
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

			this.rb.AddForce(movement * speed);
		}

		private void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag("Pick Up")) {
				other.gameObject.SetActive(false);
				this.count = this.count + 1;
				SetCountText();
			}
		}

		private void SetCountText() {
			this.countText.text = "Count: " + this.count.ToString();
			if (this.count >= 12) {
				this.winText.text = "You Win!";
			}
		}
	}
}