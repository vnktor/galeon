using UnityEngine;
using UnityEngine.UI;

namespace RollaBoll {
	public class Player_Controller : MonoBehaviour {
		
		private int count;

		[SerializeField]
		private Transform player;
		[SerializeField]
		private Transform animObject;
		
		public Text countText, winText;
		
		private void Start() {
			this.count = 0;
			this.winText.text = "";
			this.setcount ();
		}
		
		private void FixedUpdate() {
			animObject.transform.position = player.transform.position;
		}
		
		private void OnTriggerEnter (Collider gold) { 
			if (gold.tag == "Point") {
				GameObject.Destroy(gold.gameObject);
				this.count++;
			setcount();
		}
	}
		
		private void setcount () {
			this.countText.text = "Gold: " + count.ToString ();
			if (this.count >= 11) {
				this.winText.text = "You Win!";
			}
		}
	}
}