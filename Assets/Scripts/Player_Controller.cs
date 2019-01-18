using UnityEngine;
using UnityEngine.UI;

namespace RollaBoll {
	public class Player_Controller : MonoBehaviour {
		public float speed;
		
		private Rigidbody rb;
		
		private int count;
// Text fields
		public Text countText, winText;
		
		void Start() {
			rb = GetComponent<Rigidbody>();
			count = 0;
			winText.text = "";
			setCount ();
		}
		
		private void FixedUpdate() {
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			
			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			
			this.rb.AddForce(movement * speed);
		}
		
		private void OnTriggerEnter (Collider gold) { 
			if (gold.tag == "Point") {
			Destroy (gold.gameObject);
			this.count++;
			setCount();
		}
	}
		
		private void setCount () {
			this.countText.text = "Gold: " + count.ToString ();
			if (this.count >= 11)
				this.winText.text = "You Win!";
			}
		}
	}