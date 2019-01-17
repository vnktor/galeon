using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	private void Start(){
		this.rb = GetComponent<Rigidbody>();
		this.count = 0;
		SetCountText();
		this.winText.text = "";
	}

	private void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		this.rb.AddForce(movement * this.speed);
	}

	private void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("PickUp")){
			other.gameObject.SetActive(false);
			this.count++;
			SetCountText();
		}
	}

	private void SetCountText(){
		this.countText.text = "Count: " + this.count.ToString();
		if (this.count >= 12){
			this.winText.text = "You Win!!!";
		}
	}
}