using UnityEngine;
using UnityEngine.UI;

namespace RollaBoll {
	public class Player_Controller : MonoBehaviour {
		
		private Rigidbody rb;
		
		private int count;
		
		public Transform player;
		
		public Transform animObject;
		
		public Text countText, winText;
		
		void Start() {
			rb = GetComponent<Rigidbody>();
			count = 0;
			winText.text = "";
			setCount ();
		}
		
		private void FixedUpdate() {

			animObject.transform.position = player.transform.position;
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