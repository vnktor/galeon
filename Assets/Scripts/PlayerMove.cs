using UnityEngine;

namespace RollaBall {
	public class PlayerMove : MonoBehaviour {
		public float speed;
		
		private Rigidbody rb;
		
		private void Start() {
			this.rb = GetComponent<Rigidbody>();
		}
		
		private void FixedUpdate() {
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			
			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			
			this.rb.AddForce(movement * speed);
		}
	}
}