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

		void Start() {
			rb = GetComponent<Rigidbody>();
			this.count = 0;
			SetCountText();
			winText.text = "";
		}

		void FixedUpdate() {
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

			rb.AddForce(movement * speed);
		}

		void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag("Pick Up"))
			{
				other.gameObject.SetActive(false);
				this.count = this.count + 1;
				SetCountText();
			}
		}

		void SetCountText() {
			this.countText.text = "Count: " + this.count.ToString();
			if (this.count >= 12) {
				winText.text = "You Win!";
			}
		}
	}
}